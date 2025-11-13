//AppTestStudio 
//Copyright(C) 2016-2025 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTestStudio
{
    internal class MouseSolutionMessage
    {
        public IntPtr WindowHandle;
        public int Message;
        public int wParam;
        public int lParam;
        public int AfterDelay;
        
        // Time when Message was executed
        public DateTime ExecutionTime { get; set; }

        public int CalcX {
            get {
                return lParam & 0xFFFF;
            }
        }

        public int CalcY
        {
            get
            {
                return (lParam >> 16) & 0xFFFF;
            }
        }

        public String MessageName()
        {
            switch (Message)
            {
                case 0X0010: // WM_CLOSE
                    return "Close";
                    case 0x0002: // WM_DESTROY
                        return "Destroy";
                    case 0x0003: // WM_MOVE
                        return "Move";
                    case 0x0005: // WM_SIZE

                        return "Size";
                    case 0x000F: // WM_PAINT
                        return "Paint";
                    case 0x0014: // WM_ERASEBKGND
                        return "EraseBackground";
                    case 0x0016: // WM_ACTIVATEAPP
                        return "ActivateApp";
                    case 0x0018: // WM_SHOWWINDOW
                        return "ShowWindow";
                    case 0x001A: // WM_WININICHANGE
                        return "WinIniChange";
                    case 0x001B: // WM_DEVMODECHANGE
                        return "DevModeChange";
                    case 0x001C: // WM_ACTIVATE
                        return "Activate";
                    case 0x001D: // WM_SETFOCUS
                        return "SetFocus";
                    case 0x001E: // WM_KILLFOCUS
                        return "KillFocus";
                    case 0x0020: // WM_SETCURSOR
                        return "SetCursor";
                    case 0x0021: // WM_MOUSEACTIVATE
                        return "MouseActivate";
                    case 0X0022: // WM_CHILDACTIVATE
                        return "ChildActivate";
                    case 0x0024: // WM_QUEUESYNC
                        return "QueueSync";
                    case 0x0026: // WM_GETMINMAXINFO
                        return "GetMinMaxInfo";
                    case 0X0028: // WM_PAINTICON
                        return "PaintIcon";
                    case 0x0029: // WM_ICONERASEBKGND
                        return "IconEraseBackground";
                    case 0x002A: // WM_NEXTDLGCTL
                        return "NextDlgCtl";
                    case 0x002B: // WM_SPOOLERSTATUS
                        return "SpoolerStatus";
                    case 0x002C: // WM_DRAWITEM
                        return "DrawItem";
                    case 0x002D: // WM_MEASUREITEM
                        return "MeasureItem";
                    case 0x002E: // WM_DELETEITEM
                        return "DeleteItem";
                    case 0x002F: // WM_VKEYTOITEM
                        return "VKeyToItem";
                    case 0x0030: // WM_CHARTOITEM
                        return "CharToItem";
                    case 0x0031: // WM_SETFONT
                        return "SetFont";
                    case 0x0032: // WM_GETFONT
                        return "GetFont";
                    case 0x0033: // WM_SETHOTKEY
                        return "SetHotKey";
                    case 0x0034: // WM_GETHOTKEY
                        return "GetHotKey";
                    case 0x0037: // WM_QUERYDRAGICON
                        return "QueryDragIcon";
                    case 0x0039: // WM_COMPAREITEM
                        return "CompareItem";
                    case 0x003D: // WM_GETOBJECT
                        return "GetObject";
                    case 0x0041: // WM_COMPACTING
                        return "Compacting";
                    case 0x0044: // WM_COMMNOTIFY
                        return "CommNotify";
                    case 0x0046: // WM_WINDOWPOSCHANGING
                        return "WindowPosChanging";
                    case 0x0047: // WM_WINDOWPOSCHANGED
                        return "WindowPosChanged";
                    case 0x0048: // WM_POWER
                        return "Power";
                    case 0x004A: // WM_COPYDATA
                        return "CopyData";
                    case 0x004B: // WM_CANCELJOURNAL
                        return "CancelJournal";
                    case 0x004E: // WM_NOTIFY
                        return "Notify";
                    case 0x0050: // WM_INPUTLANGCHANGEREQUEST
                        return "InputLangChangeRequest";
                    case 0x0051: // WM_INPUTLANGCHANGE
                        return "InputLangChange";
                    case 0x0052: // WM_TCARD
                        return "TCard";
                    case 0x0053: // WM_HELP
                        return "Help";
                    case 0x0054: // WM_USERCHANGED
                        return "UserChanged";
                    case 0x0055: // WM_NOTIFYFORMAT
                        return "NotifyFormat";
                    case 0x007B: // WM_CONTEXTMENU
                        return "ContextMenu";
                    case 0x007C: // WM_STYLECHANGING
                        return "StyleChanging";
                    case 0x007D: // WM_STYLECHANGED
                        return "StyleChanged";
                    case 0x007E: // WM_DISPLAYCHANGE
                        return "DisplayChange";
                    case 0x007F: // WM_GETICON
                        return "GetIcon";
                    case 0x0080: // WM_SETICON
                        return "SetIcon";
                    case 0X0081: // WM_NCCREATE
                        return "NCCreate";
                    case 0x0082: // WM_NCDESTROY
                        return "NCDestroy";
                    case 0x0083: // WM_NCCALCSIZE
                        return "NCCalcSize";
                    case 0x0084: // WM_NCHITTEST
                        return "NCHitTest";
                    case 0x0085: // WM_NCPAINT
                        return "NCPaint";
                    case 0x0086: // WM_NCACTIVATE
                        return "NCActivate";
                    case 0x0087: // WM_GETDLGCODE
                        return "GetDlgCode";
                    case 0x00A0: // WM_NCMOUSEMOVE
                        return "NCMouseMove";
                    case 0x00A1: // WM_NCLBUTTONDOWN
                        return "NCLeftButtonDown";
                    case 0x00A2: // WM_NCLBUTTONUP
                        return "NCLeftButtonUp";
                    case 0x00A3: // WM_NCLBUTTONDBLCLK
                        return "NCLeftButtonDoubleClick";
                    case 0x00A4: // WM_NCRBUTTONDOWN
                        return "NCRightButtonDown";
                    case 0x00A5: // WM_NCRBUTTONUP
                        return "NCRightButtonUp";
                    case 0x00A6: // WM_NCRBUTTONDBLCLK
                        return "NCRightButtonDoubleClick";
                    case 0x00A7: // WM_NCMBUTTONDOWN
                        return "NCMiddleButtonDown";
                    case 0x00A8: // WM_NCMBUTTONUP
                        return "NCMiddleButtonUp";
                    case 0x00A9: // WM_NCMBUTTONDBLCLK
                        return "NCMiddleButtonDoubleClick";
                    case 0x00AB: // WM_NCXBUTTONDOWN
                        return "NCXButtonDown";
                    case 0x00AC: // WM_NCXBUTTONUP
                        return "NCXButtonUp";
                    case 0x00AD: // WM_NCXBUTTONDBLCLK
                        return "NCXButtonDoubleClick";
                    case 0x00FE: // WM_INPUT_DEVICE_CHANGE
                        return "InputDeviceChange";
                    case 0x00FF: // WM_INPUT
                        return "Input";
                    case 0x0100: // WM_KEYDOWN
                        return "KeyDown";
                    case 0x0101: // WM_KEYUP
                        return "KeyUp";
                    case 0x0102: // WM_CHAR
                        return "Char";
                    case 0x0103: // WM_DEADCHAR
                        return "DeadChar";
                    case 0x0104: // WM_SYSKEYDOWN
                        return "SysKeyDown";
                    case 0x0105: // WM_SYSKEYUP
                        return "SysKeyUp";
                    case 0x0106: // WM_SYSCHAR
                        return "SysChar";
                    case 0x0107: // WM_SYSDEADCHAR
                        return "SysDeadChar";
                    case 0x0109: // WM_UNICHAR
                        return "UniChar";
                    case 0x010A: // WM_KEYLAST
                        return "KeyLast";
                    case 0x010D: // WM_IME_STARTCOMPOSITION
                        return "IMEStartComposition";
                    case 0x010E: // WM_IME_ENDCOMPOSITION
                        return "IMEEndComposition";
                    case 0x010F: // WM_IME_COMPOSITION
                        return "IMEComposition";
                    case 0x0110: // WM_INITDIALOG
                        return "InitDialog";
                    case 0x0111: // WM_COMMAND
                        return "Command";
                    case 0x0112: // WM_SYSCOMMAND
                        return "SysCommand";
                    case 0x0113: // WM_TIMER
                        return "Timer";
                    case 0x0114: // WM_HSCROLL
                        return "HScroll";
                    case 0x0115: // WM_VSCROLL
                        return "VScroll";
                    case 0x0116: // WM_INITMENU
                        return "InitMenu";
                    case 0x0117: // WM_INITMENUPOPUP
                        return "InitMenuPopup";
                    case 0x0119: // WM_MENUSELECT
                        return "MenuSelect";
                    case 0x011A: // WM_MENUCHAR
                        return "MenuChar";
                    case 0x011F: // WM_ENTERIDLE
                        return "EnterIdle";
                    case 0x0120: // WM_MENURBUTTONUP
                        return "MenuRightButtonUp";
                    case 0x0121: // WM_MENUDRAG
                        return "MenuDrag";
                    case 0x0122: // WM_MENUGETOBJECT
                        return "MenuGetObject";
                    case 0x0123: // WM_UNINITMENUPOPUP
                        return "UninitMenuPopup";
                    case 0x0124: // WM_MENUCOMMAND
                        return "MenuCommand";
                    case 0x0126: // WM_CHANGEUISTATE
                        return "ChangeUIState";
                    case 0x0127: // WM_UPDATEUISTATE
                        return "UpdateUIState";
                    case 0x0128: // WM_QUERYUISTATE
                        return "QueryUIState";
                    case 0x0132: // WM_CTLCOLORMSGBOX
                        return "CtlColorMsgBox";
                    case 0x0133: // WM_CTLCOLOREDIT
                        return "CtlColorEdit";
                    case 0x0134: // WM_CTLCOLORLISTBOX
                        return "CtlColorListBox";
                    case 0x0135: // WM_CTLCOLORBTN
                        return "CtlColorBtn";
                    case 0x0136: // WM_CTLCOLORDLG
                        return "CtlColorDlg";
                    case 0x0137: // WM_CTLCOLORSCROLLBAR
                        return "CtlColorScrollBar";
                    case 0x0138: // WM_CTLCOLORSTATIC
                        return "CtlColorStatic";
                    case 0x0139: // WM_MOUSEMOVE
                        return "MouseMove";
                    case 0x0140: // WM_MOUSEHOVER
                        return "MouseHover";
                    case 0x0141: // WM_MOUSELEAVE
                        return "MouseLeave";
                    case 0x0142: // WM_NCMOUSEHOVER
                        return "NCMouseHover";
                    case 0x0143: // WM_NCMOUSELEAVE
                        return "NCMouseLeave";
                    case 0x0144: // WM_WTSSESSION_CHANGE
                        return "WTSSessionChange";
                    case 0x0145: // WM_TABLET_FIRST
                        return "TabletFirst";
                    case 0x0146: // WM_TABLET_LAST
                        return "TabletLast";
                    case 0x0147: // WM_TABLET_FIRST
                        return "TabletFirst";
                    case 0x0148: // WM_TABLET_LAST
                        return "TabletLast";
                    case 0x0149: // WM_CUT
                        return "Cut";
                    case 0x014A: // WM_COPY
                        return "Copy";
                    case 0x0200: // WM_MOUSEMOVE
                        return "MouseMove";
                    case 0x0201: // WM_LBUTTONDOWN
                        return "LeftButtonDown";
                    case 0x0202: // WM_LBUTTONUP
                        return "LeftButtonUp";
                    case 0x0203: // WM_LBUTTONDBLCLK
                        return "LeftButtonDoubleClick";
                    case 0x0204: // WM_RBUTTONDOWN
                        return "RightButtonDown";
                    case 0x0205: // WM_RBUTTONUP
                        return "RightButtonUp";
                    case 0x0206: // WM_RBUTTONDBLCLK
                        return "RightButtonDoubleClick";
                    case 0x0207: // WM_MBUTTONDOWN
                        return "MiddleButtonDown";
                    case 0x0208: // WM_MBUTTONUP
                        return "MiddleButtonUp";
                    case 0x0209: // WM_MBUTTONDBLCLK
                        return "MiddleButtonDoubleClick";
                    case 0x020A: // WM_MOUSEWHEEL
                        return "MouseWheel";
                    case 0x020B: // WM_XBUTTONDOWN
                        return "XButtonDown";
                    case 0x020C: // WM_XBUTTONUP
                        return "XButtonUp";
                    case 0x020D: // WM_XBUTTONDBLCLK
                        return "XButtonDoubleClick";
                    case 0x020E: // WM_MOUSEHWHEEL
                        return "MouseHWheel";

                default:
                    break;
            }

            return "Unknown";

        }
    }
}
