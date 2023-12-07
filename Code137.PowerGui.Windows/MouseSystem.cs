using Code137.PowerGui.Domain.Enum;
using Code137.PowerGui.Domain.Model;
using Code137.PowerGui.Domain.WindowsModel.Enum;
using Code137.PowerGui.Windows.External;
using static Code137.PowerGui.Windows.External.Structs;

namespace Code137.PowerGui.Windows
{
    public class MouseSystem
    {
        public static void Click(MKeys key)
        {
            Press(key);
            Release(key);

            //if (key == MKeys.Left)
            //{
            //    Api.MouseEvent((int)EnumMouseKeys.LeftPress, 0, 0, 0, 0);
            //    Api.MouseEvent((int)EnumMouseKeys.LeftDrop, 0, 0, 0, 0);
            //}
            //else if (key == MKeys.Right)
            //{
            //    Api.MouseEvent((int)EnumMouseKeys.RightPress, 0, 0, 0, 0);
            //    Api.MouseEvent((int)EnumMouseKeys.RightDrop, 0, 0, 0, 0);
            //}
            //else if (key == MKeys.Middle)
            //{
            //    Api.MouseEvent((int)EnumMouseKeys.MiddlePress, 0, 0, 0, 0);
            //    Api.MouseEvent((int)EnumMouseKeys.MiddleDrop, 0, 0, 0, 0);
            //}
        }

        public static void Double(MKeys key)
        {
            Click(key);

            Thread.Sleep(200);

            Click(key);
        }

        public static void Press(MKeys key)
        {
            if (key == MKeys.Left)
            {
                Api.MouseEvent((int)EnumMouseKeys.LeftPress, 0, 0, 0, 0);
            }
            else if (key == MKeys.Right)
            {
                Api.MouseEvent((int)EnumMouseKeys.RightPress, 0, 0, 0, 0);
            }
            else if (key == MKeys.Middle)
            {
                Api.MouseEvent((int)EnumMouseKeys.MiddlePress, 0, 0, 0, 0);
            }
        }

        public static void Release(MKeys key)
        {
            if (key == MKeys.Left)
            {
                if (Api.GetAsyncKeyState(1) == -32767)
                {
                    Api.MouseEvent((int)EnumMouseKeys.LeftDrop, 0, 0, 0, 0);
                }
            }
            else if (key == MKeys.Right)
            {
                if (Api.GetAsyncKeyState(2) == -32767)
                {
                    Api.MouseEvent((int)EnumMouseKeys.RightDrop, 0, 0, 0, 0);
                }
            }
            else if (key == MKeys.Middle)
            {
                if (Api.GetAsyncKeyState(4) == -32767)
                {
                    Api.MouseEvent((int)EnumMouseKeys.MiddleDrop, 0, 0, 0, 0);
                }
            }
        }

        public static void ReleaseAll()
        {
            //Api.MouseEvet((int)EnumMouseKeys.LeftDrop, 0, 0, 0, 0);
            //Api.MouseEvet((int)EnumMouseKeys.RightDrop, 0, 0, 0, 0);
            //Api.MouseEvet((int)EnumMouseKeys.MiddleDrop, 0, 0, 0, 0);

            foreach (var keys in Enum.GetNames(typeof(MKeys)))
                Api.MouseEvent((int)Enum.Parse(typeof(MKeys), keys), 0, 0, 0, 0);
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
