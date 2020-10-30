// This code is distributed under MIT license. 
// Copyright (c) 2016-2020 Daniel Harrod
// See LICENSE or https://mit-license.org/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace AppTestStudio
{
    public static class Extensions
    {

        public static String ToEnumString( this WindowNameFilterType filter)
        {
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

        public static Bitmap CloneMe(this Bitmap bmp)
        {
            return (Bitmap)bmp.Clone();
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

        public static long ToLong(this double d)
        {
            return (long)d;
        }

        // Compare Colors and return if the colors match
        // Returns Qualifying Points, how many points to return true
        public static Boolean CompareColorWithPoints(this Color aColor, Color bColor, int Points, ref int QualifyingPoints)
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

                if (RPoints > QualifyingPoints)
                {
                    QualifyingPoints = RPoints;
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

                if (GPoints > QualifyingPoints)
                {
                    QualifyingPoints = GPoints;
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

                if (BPoints > QualifyingPoints)
                {
                    QualifyingPoints = BPoints;
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
    }
}
