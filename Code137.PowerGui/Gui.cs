using Code137.PowerGui.Domain.Enum;
using Code137.PowerGui.Domain.Model;
using Code137.PowerGui.Windows;

namespace Code137.PowerGui
{
    public class Gui
    {
        #region Mouse
        public static void MouseClick(MKeys key = MKeys.Left)
        {
            try
            {
                MouseSystem.Click(key);
            }
            catch (Exception ex)
            {
                throw new Exception($"Mouse click error. Message: {ex.Message}");
            }
        }

        public static void MouseDoubleClick(MKeys key = MKeys.Left)
        {
            try
            {
                MouseSystem.Double(key);
            }
            catch (Exception ex)
            {
                throw new Exception($"Mouse double click error. Message: {ex.Message}");
            }
        }

        public static void MousePress(MKeys key = MKeys.Left)
        {
            try
            {
                MouseSystem.Press(key);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error pressing mouse. Message: {ex.Message}");
            }
        }

        public static void MouseRelease(MKeys key)
        {
            try
            {
                MouseSystem.Release(key);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error releasing mouse key: {Enum.GetName(key)}. Message: {ex.Message}");
            }
        }

        public static void MouseReleaseKeys()
        {
            try
            {
                MouseSystem.ReleaseAll();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error releasing all mouse keys. Message: {ex.Message}");
            }
        }

        public static void SetCursorPosition(int x, int y)
        {
            try
            {
                MouseSystem.SetPosition(x, y);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error setting cursor position. Message: {ex.Message}");
            }
        }

        public static Position GetCursorPosition()
        {
            try
            {
                return MouseSystem.GetPosition();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting cursor position. Message: {ex.Message}");
            }
        }
        #endregion

        #region Keyboard
        public static void Write(string text)
        {
            try
            {
                KeyboardSystem.Write(text);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error write. Message: {ex.Message}");
            }
        }

        public static void KeyboardClick(KKeys key)
        {
            try
            {
                KeyboardSystem.Click(key);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error when clicking key. Message: {ex.Message}");
            }
        }

        public static void KeyboardPress(KKeys key)
        {
            try
            {
                KeyboardSystem.Press(key);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error when pressing keyboard key. Message: {ex.Message}");
            }
        }

        public static void KeyboardRelease(KKeys key)
        {
            try
            {
                KeyboardSystem.Release(key);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error releasing keyboard key: {Enum.GetName(key)}. Message: {ex.Message}");
            }
        }

        public static void KeyboardReleaseKeys()
        {
            try
            {
                KeyboardSystem.ReleaseAll();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error releasing all keyboard keys. Message: {ex.Message}");
            }
        }

        public static string GetKeyPress()
        {
            try
            {
                return KeyboardSystem.GetKeyPress();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting key pressed: {ex.Message}");
            }
        }
        #endregion

        public static void ReleaseAllKeys()
        {
            MouseReleaseKeys();
            KeyboardReleaseKeys();
        }

        public static void Sleep(double time)
        {
            try
            {
                time = Math.Round(time, 2) * 1000;

                int formatTime = int.Parse(time.ToString());

                Thread.Sleep(formatTime);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error suspending application. Message: {ex.Message}");
            }
        }

        public static void Message(string title, string message)
        {
            try
            {
                CommonSystem.MessageBox(title, message);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in message box. Message: {ex.Message}");
            }
        }

        public static PixelColor GetMousePixelColor()
        {
            try
            {
                return CommonSystem.GetPixelColor(GetCursorPosition());
            }
            catch (Exception ex)
            {
                throw new Exception($"Error finding pixel color. Message: {ex.Message}");
            }
        }

        public static PixelColor GetPixelColor(Position position)
        {
            try
            {
                return CommonSystem.GetPixelColor(position);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error finding pixel color. Message: {ex.Message}");
            }
        }
    }
}
