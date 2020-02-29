// This code is distributed under MIT license. 
// Copyright (c) 2016-2020 Daniel Harrod
// See LICENSE or https://mit-license.org/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTestStudio
{

    public enum GameNodeType
    {
        Workspace,
        Games,
        Game,
        Events,
        Event,
        Action,
        Objects,
        ObjectScreenshot,
        Object
    }

    public enum AfterCompletionType
    {
        Continue,
        Home,
        Parent,
        Stop,
        ContinueProcess
    }

    public enum ActionType
    {
        Action,
        Event,
        RNG,
        RNGContainer
    }

    public enum WaitType
    {
        Iteration,
        Time,
        Session
    }

    public enum Mode
    {
        RangeClick,
        ClickDragRelease
    }

    public enum DragTargetMode
    {
        Relative,
        Absolute                
    }

    public static class IconNames
    {
        public static int VideoGameController()
        {
            return 0;
        }
        public static int OrangeComputer()
        {
            return 1;
        }
        public static int AngularLightningBolt()
        {
            return 2;
        }
        public static int ArrowToCircle()
        {
            return 3;
        }
        public static int RNGContainer()
        {
            return 4;
        }
        public static int RNG()
        {
            return 5;
        }
        public static int AngularLightningBoltNo()
        {
            return 6;
        }
        public static int AngularLightningBoltYes()
        {
            return 7;
        }
        public static int HelpIcon()
        {
            return 8;
        }
        public static int Mobile()
        {
            return 9;
        }
        public static int Mobiles()
        {
            return 10;
        }
        public static int EncapsulateField()
        {
            return 11;
        }
        public static int EditMulitpleObjects()
        {
            return 12;
        }
        public static int RectangularScreenshot()
        {
            return 13;
        }
        public static int RectangularSelection()
        {
            return 14;
        }
        public static int Event()
        {
            return 15;
        }
        public static int ButtonClick()
        {
            return 16;
        }
        public static int Home()
        {
            return 17;
        }
        public static int Application()
        {
            return 18;
        }
        public static int AppRoot()
        {
            return 19;
        }
        public static int SearchAndApps()
        {
            return 20;
        }
        public static int DependencyArrow()
        {
            return 21;
        }
    }
}
