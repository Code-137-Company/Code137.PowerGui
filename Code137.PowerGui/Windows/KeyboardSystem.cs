using Code137.PowerGui.Domain.Enum;
using Code137.PowerGui.Domain.WindowsModel;
using Code137.PowerGui.Windows.External;
using System.Text.RegularExpressions;

namespace Code137.PowerGui.Windows
{
    public class KeyboardSystem
    {
        private static readonly uint KEYEVENF_KEYUP = 0x0002;

        private static List<KKeys> Keys = new List<KKeys>();
        private static List<Keys> PressedKeys = new List<Keys>();

        public static void Write(string text)
        {
            char[] values = text.ToCharArray();

            foreach (char value in values)
            {
                if (Regex.IsMatch(value.ToString(), @"[a-z0-9]"))
                {
                    var hex = Convert.ToInt32(char.Parse(value.ToString().ToUpper()));

                    Api.KeyboardEvent((byte)hex, 0, 0, nuint.Zero);
                    Api.KeyboardEvent((byte)hex, 0, KEYEVENF_KEYUP, nuint.Zero);
                }
                else if (!Regex.IsMatch(value.ToString(), @"[A-Z]"))
                {
                    List<byte> list = ShurtcutList.Shortcut(value);

                    if (list != null && list.Count > 0)
                    {
                        foreach (byte b in list)
                        {
                            Api.KeyboardEvent((byte)b, 0, 0, nuint.Zero);
                        }

                        foreach (byte b in list)
                        {
                            Api.KeyboardEvent((byte)b, 0, KEYEVENF_KEYUP, nuint.Zero);
                        }

                        if (list.Contains((byte)KKeys.Caps))
                        {
                            Api.KeyboardEvent((byte)KKeys.Caps, 0, 0, nuint.Zero);
                            Api.KeyboardEvent((byte)KKeys.Caps, 0, KEYEVENF_KEYUP, nuint.Zero);
                        }
                    }
                }
                else
                {
                    Api.KeyboardEvent((byte)KKeys.Shift, 0, 0, nuint.Zero);

                    var hex = Convert.ToInt32(char.Parse(value.ToString().ToUpper()));

                    Api.KeyboardEvent((byte)hex, 0, 0, nuint.Zero);
                    Api.KeyboardEvent((byte)hex, 0, KEYEVENF_KEYUP, nuint.Zero);

                    Api.KeyboardEvent((byte)KKeys.Shift, 0, KEYEVENF_KEYUP, nuint.Zero);
                }
            }
        }

        public static void Click(KKeys key)
        {
            Press(key);

            Thread.Sleep(150);

            Release(key);

            //Api.KeyboardEvent((byte)key, 0, 0, nuint.Zero);

            //Thread.Sleep(150);

            //Api.KeyboardEvent((byte)key, 0, KEYEVENF_KEYUP, nuint.Zero);
        }

        public static void Press(KKeys key)
        {
            Api.KeyboardEvent((byte)key, 0, 0, nuint.Zero);
            Keys.Add(key);
        }

        public static void Release(KKeys key)
        {
            Api.KeyboardEvent((byte)key, 0, KEYEVENF_KEYUP, nuint.Zero);
            Keys.Remove(key);
        }

        public static void ReleaseAll()
        {
            foreach (KKeys key in Keys)
            {
                Api.KeyboardEvent((byte)key, 0, KEYEVENF_KEYUP, nuint.Zero);
            }

            Keys.Clear();
        }

        public static Keys GetKeyPress()
        {
            var keys = (Keys[])Enum.GetValues(typeof(Keys));

            foreach (var key in keys)
            {
                var keyPress = Api.GetAsyncKeyState((int)key);

                if ((keyPress & 0x8000) != 0)
                {
                    if (PressedKeys.Contains(key))
                        continue;

                    PressedKeys.Add(key);

                    return key;
                }
            }

            foreach (var key in PressedKeys)
            {
                var keyPress = Api.GetAsyncKeyState((int)key);

                if ((keyPress & 0x8000) == 0)
                {
                    PressedKeys.Remove(key);

                    return Domain.Enum.Keys.None;
                }
            }

            return Domain.Enum.Keys.None;
        }
    }
}
