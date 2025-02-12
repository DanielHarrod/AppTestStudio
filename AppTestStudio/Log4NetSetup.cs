//AppTestStudio 
//Copyright(C) 2016-2025 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Repository;
using log4net.Repository.Hierarchy;
using System.Reflection;

namespace AppTestStudio
{
    // I want to use the log4net.config to provide some customization
    // but I need a few changes that are not configurable very easily.
    //
    // 1.) Need to instantiate logs based on a template for runtime threads
    // 2.) Need to write all the logs to the project folder.
    internal static class Log4NetSetup
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        // used to store the template for runtime thread logs.
        private static log4net.Appender.RollingFileAppender template;

        // used to store the template threashold.
        private static Level threashold = Level.Info;

        private static String WorkspaceFolder = "";

        public static List<string> ConfigurationMessages { get; private set; }

        public static void Initialize(String workspaceFolder)
        {
            WorkspaceFolder = workspaceFolder;
            // Load file configuration into log4net
            XmlConfigurator.Configure(new System.IO.FileInfo("log4net.config"));
            log.Info("Test");

            ConfigurationMessages = new List<string>();
            ILogger logger = log.Logger;

            Boolean IsErrorInTemplate = false;
            if (logger.Repository.ConfigurationMessages.Count > 0)
            {
                foreach (var item in logger.Repository.ConfigurationMessages)
                {
                    ConfigurationMessages.Add(item.ToString());
                    if (item.ToString().Contains("ATSRollingLogFileTemplate"))
                    {
                        IsErrorInTemplate = true;
                    }
                }
            }

            // the rest isn't going to work if there's a template error.
            if (IsErrorInTemplate)
            {
                return;
            }

            // Finds the "ATSRollingLogFileTemplate" Appender.
            // Updates the log file path  to the ATS Project folder.
            // ATSRollingLogFileTemplate is used for cloning for runtime threads.
            String TemplateName = "ATSRollingLogFileTemplate";

            IAppender[] appenders = LogManager.GetLogger(TemplateName).Logger.Repository.GetAppenders();
            foreach (IAppender appender in appenders)
            {
                RollingFileAppender rfa = appender as RollingFileAppender;


                rfa.File = rfa.File.Replace(System.IO.Path.GetDirectoryName(Application.ExecutablePath), WorkspaceFolder);

                if (appender.Name == TemplateName)
                {
                    // Store the Template for cloning.
                    template = appender as RollingFileAppender;
                }
                else
                {
                    // We are using the other appenders
                    rfa.ActivateOptions();
                }
            }

            // find the Threashold used
            foreach (ILog log in LogManager.GetCurrentLoggers())
            {
                if (log.Logger.Name == "ATSRollingLogFileTemplate")
                {
                    threashold = (log.Logger as Logger).EffectiveLevel;
                    break;
                }
            }

            // We aren't using the ATSRollingLogFileTemplate for anything except to clone instances with, remove it from the logger..            
            IAppenderAttachable? appenderAttachable = log.Logger as IAppenderAttachable;
            appenderAttachable?.RemoveAppender(template);
        }

        // Call when starting a new thread to initialize a log file for the thread.
        public static void AddNewAppender(String Name)
        {
            // We only need one log file for each thread.
            foreach (var item in LogManager.GetAllRepositories())
            {
                if (item.Name == Name)
                {
                    // No need to create since it already exists, we don't remove repositories, just stop using them.
                    return;
                }
            }
            if (template != null)
            {
                // light cloning.
                RollingFileAppender rfa = new RollingFileAppender();

                rfa.AppendToFile = template.AppendToFile;
                rfa.CountDirection = template.CountDirection;
                rfa.CurrentSizeRollBackups = template.CurrentSizeRollBackups;
                rfa.DatePattern = template.DatePattern;
                rfa.DateTimeStrategy = template.DateTimeStrategy;
                rfa.Encoding = template.Encoding;
                rfa.File = template.File.Replace("{ProjectName}", Name);
                rfa.ImmediateFlush = template.ImmediateFlush;
                rfa.Layout = template.Layout;
                rfa.MaxFileSize = template.MaxFileSize;
                rfa.MaxSizeRollBackups = template.MaxSizeRollBackups;
                rfa.Name = Name;
                rfa.PreserveLogFileNameExtension = template.PreserveLogFileNameExtension;
                rfa.StaticLogFileName = template.StaticLogFileName;
                rfa.Threshold = template.Threshold;
                rfa.ActivateOptions();

                ILoggerRepository rep = LoggerManager.CreateRepository(Name);
                rep.Threshold = threashold;
                BasicConfigurator.Configure(rep, rfa);
            }
        }
    }
}
