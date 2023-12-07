using Code137.PowerGui.Domain.Enum;
using Code137.PowerGui.Domain.Model;

namespace Code137.PowerGui.Samples;

public class Program
{
    public static void Main(string[] args)
    {
        Gui.Message("Test", "Content message.");

        Gui.MouseClick(MKeys.Right);

        Gui.MousePress(MKeys.Left);

        Gui.Sleep(5);

        Gui.MouseRelease(MKeys.Left);

        Gui.Sleep(2);

        Gui.MouseClick(MKeys.Right);

        Gui.Sleep(2);

        Gui.MouseClick(MKeys.Left);

        Gui.Sleep(2);

        Gui.MouseReleaseKeys();

        Gui.SetCursorPosition(500, 500);

        Gui.Sleep(2);

        var pos = Gui.GetCursorPosition();

        Gui.Sleep(2);

        var mpColor = Gui.GetMousePixelColor();

        Gui.Sleep(2);

        var pColor = Gui.GetPixelColor(new Position(400, 450));

        Gui.Sleep(2);

        Gui.Write("Test write message.");

        Gui.Sleep(2);

        Gui.KeyboardClick(KKeys.G);

        Gui.Sleep(2);

        Gui.KeyboardPress(KKeys.G);

        Gui.Sleep(3);

        Gui.KeyboardRelease(KKeys.G);

        Gui.KeyboardPress(KKeys.G);

        Gui.Sleep(2);

        Gui.KeyboardReleaseKeys();

        Gui.Sleep(2);

        while (true)
        {
            var key = Gui.GetKeyPress();

            if (!string.IsNullOrEmpty(key))
                Console.WriteLine(key);

            if (key == "T")
                break;
        }
    }
}
