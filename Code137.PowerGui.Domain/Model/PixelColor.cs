namespace Code137.PowerGui.Domain.Model
{
    public class PixelColor
    {
        public Position Pos { get; set; }
        public byte R { get; private set; }
        public byte G { get; private set; }
        public byte B { get; private set; }
        public byte A { get; private set; }

        public PixelColor()
        {
            Pos = new Position();
            R = 0;
            G = 0;
            B = 0;
            A = 0;
        }
    }
}
