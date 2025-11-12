//AppTestStudio 
//Copyright (C) 2016-2025 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

using AppTestStudio.solution;

namespace AppTestStudio
{
    public static class Extensions
    {
        public static T ParseEnum<T>(this string text)
        {
            return (T)Enum.Parse(typeof(T), text);
        }

        public static String ToEnumString( this WindowNameFilterType filter)
        {
            // could have called filter.ToString() - need to test before using.
            String Result = "";
            switch (filter)
            {
                case WindowNameFilterType.Equals:
                    Result = "Equals";
                    break;
                case WindowNameFilterType.StartsWith:
                    Result = "StartsWith";
                    break;
                case WindowNameFilterType.Contains:
                    Result = "Contains";
                    break;
                default:
                    Result = "Equals";
                    break;
            }

            return Result;
        }

        public static Rectangle SetFullScreenFromDefault(this Rectangle rec)
        {
            Rectangle newRectangle = new Rectangle();
            newRectangle.Width = rec.X;
            newRectangle.Height = rec.Y;
            newRectangle.X = 0;
            newRectangle.Y = 0;
            return newRectangle;
        }

        public static Boolean IsFullScreenMask(this Rectangle rec)
        {
            if( rec.Height == 0 && rec.Width == 0)
            {
                return true;
            }
            return false;
        }

        public static Bitmap CloneMe(this Bitmap bmp)
        {
            if (bmp.IsSomething())
            {
                return (Bitmap)bmp.Clone();
            }
            else
            {
                return null;
            }
        }
        public static Boolean IsSomething(this Object obj)
        {
            if (obj is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static Boolean IsNothing(this Object obj)
        {
            if (obj is null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int ToInt(this double d)
        {
            return (int)d;
        }
        public static int ToInt(this float d)
        {
            return (int)d;
        }
        public static int ToInt(this decimal d)
        {
            return (int)d;
        }
        public static int ToInt(this long d)
        {
            return (int)d;
        }

        public static int ToInt(this short d)
        {
            return (int)d;
        }

        public static int ToInt(this object d)
        {
            int result = 0;
            int.TryParse(d.ToString(), out result);
            return result;
        }

        public static long ToLong(this double d)
        {
            return (long)d;
        }
        public static long ToLong(this decimal d)
        {
            return (long)d;
        }

        public static ushort ToUShort(this int d)
        {
            return (ushort)d;
        }

        public static short ToShort(this int d)
        {
            return (short)d;
        }

        // Compare Colors and return if the colors match
        // Returns Qualifying Points, how many points to return true
        internal static Boolean CompareColorWithPoints(this Color aColor, Color bColor, int Points, EventSolution solution)
        {
            Boolean TestFailed = false;
            long MinR = bColor.R - Points;
            long MaxR = bColor.R + Points;
            long MinG = bColor.G - Points;
            long MaxG = bColor.G + Points;
            long MinB = bColor.B - Points;
            long MaxB = bColor.B + Points;
            if (aColor.R >= MinR && aColor.R <= MaxR)
            {
                // Good
            }
            else
            {
                TestFailed = true;
                int RPoints = 0;
                if (aColor.R > bColor.R)
                {
                    RPoints = aColor.R - bColor.R;
                }
                else
                {
                    RPoints = bColor.R - aColor.R;
                }
                RPoints = aColor.R - bColor.R;

                if (RPoints > solution.QualifyingPoints)
                {
                    solution.QualifyingPoints = RPoints;
                }
            }

            if (aColor.G >= MinG && aColor.G <= MaxG)
            {
                //good
            }
            else
            {
                TestFailed = true;
                int GPoints = 0;
                if (aColor.G > bColor.G)
                {
                    GPoints = aColor.G - bColor.G;
                }
                else
                {

                    GPoints = bColor.G - aColor.G;
                }

                if (GPoints > solution.QualifyingPoints)
                {
                    solution.QualifyingPoints = GPoints;
                }
            }


            if (aColor.B >= MinB && aColor.B <= MaxB)
            {
                //good
            }
            else
            {
                TestFailed = true;
                int BPoints = 0;
                if (aColor.G > bColor.G)
                {
                    BPoints = aColor.G - bColor.G;
                }
                else
                {

                    BPoints = bColor.G - aColor.G;
                }

                if (BPoints > solution.QualifyingPoints)
                {
                    solution.QualifyingPoints = BPoints;
                }

            }

            if (TestFailed)
            {
                return false;
            }
            return true;
        }
        public static String Right(this String value, int length)
        {
            return value.Substring(value.Length - length);
        }

        public static bool IsNumeric(this String input)
        {
            long test;
            return long.TryParse(input, out test);
        }

        public static int ToInt(this String input)
        {
            int test;
            int.TryParse(input, out test);
            return test;
        }


        public static long ToLong(this String input)
        {
            long test;
            long.TryParse(input, out test);
            return test;
        }

        public static String ToRGBString(this Color aColor)
        {
            return String.Format("R={0}, G={1}, B={2}", aColor.R, aColor.G, aColor.B);
        }

        public static String ToX(this Boolean obj)
        {
            if (obj)
            {
                return "X";
            }
            return "";
        }

        public static Color FromRGBString( this Color aColor, String s)
        {
            s = s.Replace("R=", "").Replace("G=", "").Replace("B=", "");
            String[] Keys = { ", " };
            String[] Results = s.Split(Keys,StringSplitOptions.RemoveEmptyEntries);

            return Color.FromArgb(Convert.ToInt32(Results[0]), Convert.ToInt32(Results[1]), Convert.ToInt32(Results[2]));
        }

        public static String ToHex(this Color aColor)
        {
            return String.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", aColor.A, aColor.R, aColor.G, aColor.B);
        }

        public static void MoveUp(this TreeNode node)
        {
            TreeNode Parent = node.Parent;
            TreeView tv = node.TreeView;
            if (Parent.IsSomething())
            {
                int index = Parent.Nodes.IndexOf(node);
                if (index > 0)
                {
                    Parent.Nodes.RemoveAt(index);
                    Parent.Nodes.Insert(index - 1, node);
                }
            }
            else if (node.TreeView.Nodes.Contains(node)) //root node
            {
                int index = tv.Nodes.IndexOf(node);
                if (index > 0)
                {
                    tv.Nodes.RemoveAt(index);
                    tv.Nodes.Insert(index - 1, node);
                }
            }
        }

        public static void MoveDown(this TreeNode node)
        {
            TreeNode Parent = node.Parent;
            TreeView tv = node.TreeView;
            if (Parent.IsSomething())
            {
                int index = Parent.Nodes.IndexOf(node);
                if (index < Parent.Nodes.Count - 1)
                {
                    Parent.Nodes.RemoveAt(index);
                    Parent.Nodes.Insert(index + 1, node);
                }
            }
            else if (tv.IsSomething() && tv.Nodes.Contains(node)) //root node
            {
                int index = tv.Nodes.IndexOf(node);
                if (index < tv.Nodes.Count - 1)
                {
                    tv.Nodes.RemoveAt(index);
                    tv.Nodes.Insert(index + 1, node);
                }
            }
        }
    }
}
