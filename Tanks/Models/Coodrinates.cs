using PropertyChanged;

namespace Tanks.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Coordinates
    {
        public Coordinates(Coordinates coordinates) : this(coordinates.X, coordinates.Y) { }
        public Coordinates(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get;private set;}
        public int Y { get;private set; }

        public void Swap(Coordinates coords)
        {
            Coordinates current = new Coordinates(this);
            Coordinates input = new Coordinates(coords);

            this.X = input.X;
            this.Y = input.Y;

            coords.X = current.X;
            coords.Y = current.Y;
        }


        public override bool Equals(object obj)
        {
            var coordinates = (Coordinates)obj;
            return
                coordinates != null && (coordinates.X == this.X &&
                                             coordinates.Y == this.Y);
        }

        public override string ToString()
        {
            return "X: " + this.X + " Y: " + this.Y;
        }
    }
}
