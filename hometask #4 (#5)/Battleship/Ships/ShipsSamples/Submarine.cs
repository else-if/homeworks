using Battleship.Ships.ShipAttributes;

namespace Battleship.Ships.ShipsSamples
{
    public class Submarine : Ship
    {
        public Submarine(uint x, uint y) : base(x, y)
        {
        }
        public Submarine(uint x, uint y, Direction direction) : base(x, y, direction, 3)
        {
        }
    }
}