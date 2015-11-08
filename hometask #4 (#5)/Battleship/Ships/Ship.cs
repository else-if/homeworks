using System;
using Battleship.Ships.ShipAttributes;
using Battleship.Ships.ShipParsers;

namespace Battleship.Ships
{
    public class Ship
    {
        public static Ship Parse(string notation)
        {
            return Parse(notation, new CommonShipParser());
        }
        public static Ship Parse(string notation, IShipParser shipParser)
        {
            return shipParser.Parse(notation);
        }

        public static bool TryParse(string notation, out Ship pos)
        {
            bool result = true;
            pos = null;

            try
            {
                pos = Parse(notation);
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        public ShipPosition ShipPosition { get; }
        public uint Length { get; }
        public uint X => ShipPosition.X;
        public uint Y => ShipPosition.Y;
        public Direction Direction => ShipPosition.ShipDirection;

        public Ship(uint x, uint y, Direction direction = Direction.Vertical, uint length = 1)
        {
            ShipPosition = new ShipPosition(x, y, direction);
            Length = length;
        }

        protected virtual bool Equals(Ship other)
        {
            return ShipPosition.Equals(other.ShipPosition) && Length == other.Length;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Ship)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ShipPosition.GetHashCode();
            }
        }

        public bool FitsInSquare(byte squareHeight, byte squareWidth)
        {
            if (squareHeight < X || squareWidth < Y) return false;

            if ((Direction == Direction.Horizontal) && (squareWidth < X + Length - 1)) return false;
            if ((Direction == Direction.Vertical) && (squareHeight < Y + Length - 1)) return false;

            return true;
        }

        public bool OverlapsWith(Ship ship)
        {
            uint xEnd = Direction == Direction.Vertical ? X : X + Length - 1;
            uint yEnd = Direction == Direction.Vertical ? Y + Length - 1 : Y;
            uint xOtherShipEnd = ship.Direction == Direction.Vertical ? ship.X : ship.X + ship.Length - 1;
            uint yOtherShipEnd = ship.Direction == Direction.Vertical ? ship.Y + ship.Length - 1 : ship.Y;

            return ((ship.X >= X - 1) && (ship.X <= xEnd + 1)
                    && (ship.Y >= Y - 1) && (ship.Y <= yEnd + 1))
                   || ((xOtherShipEnd >= X - 1) && (xOtherShipEnd <= xEnd + 1)
                       && (yOtherShipEnd >= Y - 1) && (yOtherShipEnd <= yEnd + 1));
        }

        public override string ToString()
        {
            return $"{(char)('A' + X - 1)}{Y}x{Length}{(char)Direction}";
        }
    }
    
}
