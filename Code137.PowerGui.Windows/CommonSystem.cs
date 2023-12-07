using Code137.PowerGui.Domain.Model;
using Code137.PowerGui.Windows.External;
using System.Drawing;
using System.Drawing.Imaging;

namespace Code137.PowerGui.Windows
{
    public class CommonSystem
    {
        private static Bitmap bitmap = new Bitmap(1, 1, PixelFormat.Format32bppArgb);

        public static void MessageBox(string title, string message) => Api.MessageBox(0, message, title, 0);

        public static PixelColor GetPixelColor(int x, int y)
        {
            Point point = new Point(x, y);

            using (Graphics gdest = Graphics.FromImage(bitmap))
            {
                using (Graphics gsrc = Graphics.FromHwnd(IntPtr.Zero))
                {
                    IntPtr hSrcDC = gsrc.GetHdc();
                    IntPtr hDC = gdest.GetHdc();

                    int retval = Api.BitBlt(hDC, 0, 0, 1, 1, hSrcDC, point.X, point.Y, (int)CopyPixelOperation.SourceCopy);

                    gdest.ReleaseHdc();
                    gsrc.ReleaseHdc();
                }
            }

            Color color = bitmap.GetPixel(0, 0);

            PixelColor pColor = new PixelColor(x, y, color.R, color.G, color.B, color.A);

            return pColor;
        }
    }
}
