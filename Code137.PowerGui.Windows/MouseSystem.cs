using Code137.PowerGui.Domain.Enum;
using Code137.PowerGui.Domain.Model;
using Code137.PowerGui.Domain.WindowsModel.Enum;
using Code137.PowerGui.Windows.External;
using static Code137.PowerGui.Windows.External.Structs;

namespace Code137.PowerGui.Windows
{
    public class MouseSystem
    {
        public static void Click(MKeys key = MKeys.Left)
        {
            if (key == MKeys.Left)
            {
                Api.MouseEvet((int)EnumMouseKeys.LeftPress, 0, 0, 0, 0);
                Api.MouseEvet((int)EnumMouseKeys.LeftDrop, 0, 0, 0, 0);
            }
            else if (key == MKeys.Right)
            {
                Api.MouseEvet((int)EnumMouseKeys.RightPress, 0, 0, 0, 0);
                Api.MouseEvet((int)EnumMouseKeys.RightDrop, 0, 0, 0, 0);
            }
            else if (key == MKeys.Middle)
            {
                Api.MouseEvet((int)EnumMouseKeys.MiddlePress, 0, 0, 0, 0);
                Api.MouseEvet((int)EnumMouseKeys.MiddleDrop, 0, 0, 0, 0);
            }
        }

        public static void Double(MKeys key = MKeys.Left)
        {
            if (key == MKeys.Left)
            {
                Api.MouseEvet((int)EnumMouseKeys.LeftPress, 0, 0, 0, 0);
                Api.MouseEvet((int)EnumMouseKeys.LeftDrop, 0, 0, 0, 0);

                Thread.Sleep(200);

                Api.MouseEvet((int)EnumMouseKeys.LeftPress, 0, 0, 0, 0);
                Api.MouseEvet((int)EnumMouseKeys.LeftDrop, 0, 0, 0, 0);
            }
            else if (key == MKeys.Right)
            {
                Api.MouseEvet((int)EnumMouseKeys.RightPress, 0, 0, 0, 0);
                Api.MouseEvet((int)EnumMouseKeys.RightDrop, 0, 0, 0, 0);

                Thread.Sleep(200);

                Api.MouseEvet((int)EnumMouseKeys.RightPress, 0, 0, 0, 0);
                Api.MouseEvet((int)EnumMouseKeys.RightDrop, 0, 0, 0, 0);
            }
            else if (key == MKeys.Middle)
            {
                Api.MouseEvet((int)EnumMouseKeys.MiddlePress, 0, 0, 0, 0);
                Api.MouseEvet((int)EnumMouseKeys.MiddleDrop, 0, 0, 0, 0);

                Thread.Sleep(200);

                Api.MouseEvet((int)EnumMouseKeys.MiddlePress, 0, 0, 0, 0);
                Api.MouseEvet((int)EnumMouseKeys.MiddleDrop, 0, 0, 0, 0);
            }
        }

        public static void Press(MKeys key)
        {
            if (key == MKeys.Left)
            {
                Api.MouseEvet((int)EnumMouseKeys.LeftPress, 0, 0, 0, 0);
            }
            else if (key == MKeys.Right)
            {
                Api.MouseEvet((int)EnumMouseKeys.RightPress, 0, 0, 0, 0);
            }
            else if (key == MKeys.Middle)
            {
                Api.MouseEvet((int)EnumMouseKeys.MiddlePress, 0, 0, 0, 0);
            }
        }

        public static void Release(MKeys key)
        {
            if (key == MKeys.Left)
            {
                if (Api.GetAsyncKeyState(1) == -32767)
                {
                    Api.MouseEvet((int)EnumMouseKeys.LeftDrop, 0, 0, 0, 0);
                }
            }
            else if (key == MKeys.Right)
            {
                if (Api.GetAsyncKeyState(2) == -32767)
                {
                    Api.MouseEvet((int)EnumMouseKeys.RightDrop, 0, 0, 0, 0);
                }
            }
            else if (key == MKeys.Middle)
            {
                if (Api.GetAsyncKeyState(4) == -32767)
                {
                    Api.MouseEvet((int)EnumMouseKeys.MiddleDrop, 0, 0, 0, 0);
                }
            }
        }

        public static void ReleaseAll()
        {
            Api.MouseEvet((int)EnumMouseKeys.LeftDrop, 0, 0, 0, 0);
            Api.MouseEvet((int)EnumMouseKeys.RightDrop, 0, 0, 0, 0);
            Api.MouseEvet((int)EnumMouseKeys.MiddleDrop, 0, 0, 0, 0);
        }

        public static void SetPosition(int x, int y)
        {
            Api.SetCursorPos(x, y);
        }

        public static Position GetPosition()
        {
            Position mouse = new Position();

            CursorPosition lpPoint;
            Api.GetCursorPos(out lpPoint);

            mouse.X = lpPoint.X;
            mouse.Y = lpPoint.Y;

            return mouse;
        }
    }
}
