using Battleship.Ships.ShipAttributes;

namespace Battleship.Ships.ShipsSamples
{
    public class Cruiser : Ship
    {
        public Cruiser(uint x, uint y) : base(x, y)
        {
        }
        public Cruiser(uint x, uint y, Direction direction) : base(x, y, direction, 2)
        {
        }
    }
}