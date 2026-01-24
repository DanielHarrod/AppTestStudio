//AppTestStudio 
//Copyright(C) 2016-2026 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

// Portions of this file were generated with GitHub Copilot.
// Generated: 2025-12-23
// Tool: GitHub Copilot (https://github.com/features/copilot)
namespace AppTestStudio
{


    public static class WindowFinder
    {
        public static IntPtr GetWindowHandleByWindowName(
            string windowNameFilter,
            WindowNameFilterType matchType)
        {
            IntPtr result = IntPtr.Zero;

            NativeMethods.EnumWindows(delegate (IntPtr hWnd, ref IntPtr lParam)
            {
                int length = NativeMethods.GetWindowTextLength(hWnd);
                if (length == 0)
                    return true; // skip windows with no title

                var sb = new System.Text.StringBuilder(length + 1);
                NativeMethods.GetWindowText(hWnd, sb, sb.Capacity);

                string title = sb.ToString();

                bool match = matchType switch
                {
                    WindowNameFilterType.Equals => title.Equals(windowNameFilter, StringComparison.OrdinalIgnoreCase),
                    WindowNameFilterType.StartsWith => title.StartsWith(windowNameFilter, StringComparison.OrdinalIgnoreCase),
                    WindowNameFilterType.Contains => title.Contains(windowNameFilter, StringComparison.OrdinalIgnoreCase),
                    _ => false
                };

                if (match)
                {
                    result = hWnd;
                    return false; // stop enumeration
                }

                return true; // continue
            }, IntPtr.Zero);

            return result;
        }
    }
}
