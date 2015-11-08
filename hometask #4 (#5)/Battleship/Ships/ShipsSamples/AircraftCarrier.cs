using Battleship.Ships.ShipAttributes;

namespace Battleship.Ships.ShipsSamples
{
    public class AircraftCarrier : Ship
    {
        public AircraftCarrier(uint x, uint y) : base(x, y)
        {
        }
        public AircraftCarrier(uint x, uint y, Direction direction) : base(x, y, direction, 4)
        {
        }
    }
}