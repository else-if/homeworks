using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Battleship
{
    public class Ship
    {
        public ShipPosition ShipPosition { get; }
        public uint Length { get; }

        public Ship(uint x, uint y) : this(x, y, Direction.Vertical, 1)
        {
        }

        public Ship(uint x, uint y, Direction direction) : this(x, y, direction, 1)
        {
        }

        public Ship(uint x, uint y, Direction direction, uint length)
        {
            ShipPosition = new ShipPosition(x, y, direction);
            Length = length;
        }

        protected virtual bool Equals(Ship other)
        {
            return ShipPosition.Equals(other.ShipPosition) && Length == this.Length;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Ship)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ShipPosition.GetHashCode();
            }
        }

    }
}
