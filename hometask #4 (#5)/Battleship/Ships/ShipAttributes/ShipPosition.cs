namespace Battleship.Ships.ShipAttributes
{
    public class ShipPosition
    {
        public uint X { get; }
        public uint Y { get; }
        public Direction ShipDirection { get; }
        
        public ShipPosition(uint x, uint y, Direction direction)
        {
            X = x;
            Y = y;
            ShipDirection = direction;
        }

        protected bool Equals(ShipPosition other)
        {
            return X == other.X && Y == other.Y && ShipDirection == other.ShipDirection;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ShipPosition)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int)X;
                hashCode = (hashCode * 397) ^ (int)Y;
                hashCode = (hashCode * 397) ^ (int)ShipDirection;
                return hashCode;
            }
        }
    }
}