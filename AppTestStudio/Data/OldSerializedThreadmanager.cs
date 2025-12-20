//AppTestStudio 
//Copyright(C) 2016-2025 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

using System.Xml.Serialization;

namespace AppTestStudio.Data
{
    [XmlRoot("ThreadManager")]
    public class OldSerializedThreadmanager
    {
        public long ClickCount;
        public long WaithLength;
        public long ScreenShots;
        public long GoHome;
        public long GoContinue;
        public long GoChild;
        public long RNG;
        public long AppLaunches;
    }
}
