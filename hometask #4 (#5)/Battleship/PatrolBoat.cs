using System;

namespace Battleship
{
    public class PatrolBoat : Ship
    {
        public PatrolBoat(uint x, uint y) : base(x, y, Direction.None, 1)
        {
        }
        public PatrolBoat(uint x, uint y, Direction direction) : base(x, y, direction, 1)
        {
        }

        protected override bool Equals(Ship other)
        {
            //doesn't check direction
            return ShipPosition.X == other.ShipPosition.X && 
                ShipPosition.Y == other.ShipPosition.Y && 
                Length == other.Length;
        }
    }
}