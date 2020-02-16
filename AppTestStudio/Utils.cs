using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTestStudio
{
    public static class Utils
    {
        public static void SetIcons(GameNode Node)
        {
            switch (Node.GameNodeType)
            {
                case GameNodeType.Workspace:
                    Node.ImageIndex = IconNames.AppRoot();
                    Node.SelectedImageIndex = IconNames.AppRoot();

                    break;
                case GameNodeType.Games:
                    break;
                case GameNodeType.Game:
                    break;
                case GameNodeType.Events:
                    Node.ImageIndex = IconNames.Home();
                    Node.SelectedImageIndex = IconNames.Home();
                    break;
                case GameNodeType.Event:
                    Node.ImageIndex = IconNames.Event();
                    Node.SelectedImageIndex = IconNames.Event();
                    break;
                case GameNodeType.Action:
                    GameNodeAction ActionNode = Node as GameNodeAction;
                    if (ActionNode.IsSomething())
                    {
                        switch (ActionNode.ActionType)
                        {
                            case ActionType.Action:
                                switch (ActionNode.Mode)
                                {
                                    case Mode.RangeClick:
                                        Node.ImageIndex = IconNames.DependencyArrow();
                                        Node.SelectedImageIndex = IconNames.DependencyArrow();
                                        break;
                                    case Mode.ClickDragRelease:
                                        Node.ImageIndex = IconNames.ButtonClick();
                                        Node.SelectedImageIndex = IconNames.ButtonClick();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case ActionType.Event:
                                if (ActionNode.IsColorPoint)
                                {
                                    Node.ImageIndex = IconNames.Event();
                                    Node.SelectedImageIndex = IconNames.Event();
                                }
                                else
                                {
                                    Node.ImageIndex = IconNames.SearchAndApps();
                                    Node.SelectedImageIndex = IconNames.SearchAndApps();
                                }
                                break;
                            case ActionType.RNG:
                                Node.ImageIndex = IconNames.RNG();
                                Node.SelectedImageIndex = IconNames.RNG();
                                break;
                            case ActionType.RNGContainer:
                                Node.ImageIndex = IconNames.RNGContainer();
                                Node.SelectedImageIndex = IconNames.RNGContainer();
                                break;
                            default:
                                Node.ImageIndex = IconNames.Event();
                                Node.SelectedImageIndex = IconNames.Event();
                                break;
                        }
                    }
                    break;
                case GameNodeType.Objects:
                    Node.ImageIndex = IconNames.EditMulitpleObjects();
                Node.SelectedImageIndex = IconNames.EditMulitpleObjects();
                    break;
                case GameNodeType.ObjectScreenshot:
                    Node.ImageIndex = IconNames.RectangularScreenshot();
                Node.SelectedImageIndex = IconNames.RectangularScreenshot();
                    break;
                case GameNodeType.Object:
                    Node.ImageIndex = IconNames.RectangularSelection();
                    Node.SelectedImageIndex = IconNames.RectangularSelection();
                    break;
                default:
                    Node.ImageIndex = IconNames.VideoGameController();
                    Node.SelectedImageIndex = IconNames.VideoGameController();
                    break;
            }

        }
    }
}
