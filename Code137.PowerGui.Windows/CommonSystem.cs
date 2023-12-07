using Code137.PowerGui.Windows.External;

namespace Code137.PowerGui.Windows
{
    public class CommonSystem
    {
        public static void MessageBox(string title, string message) => Api.MessageBox(0, message, title, 0);
    }
}
