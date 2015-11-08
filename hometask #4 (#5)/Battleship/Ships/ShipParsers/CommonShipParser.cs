using System;
using System.Text.RegularExpressions;
using Battleship.Exceptions;
using Battleship.Ships.ShipAttributes;
using Battleship.Ships.ShipsSamples;

namespace Battleship.Ships.ShipParsers
{
    public class CommonShipParser:IShipParser
    {
        public Ship Parse(string notation)
        {
            if (notation == null) throw new ArgumentException();

            var pattern = @"^([A-J])(10|[1-9])(x[1-4])?(-|\|)?$";
            var regEx = new Regex(pattern);

            var match = regEx.Match(notation);

            if (!match.Success) throw new NotAShipException();

            uint x = (uint)(match.Groups[1].Value[0] - 'A' + 1);
            uint y = uint.Parse(match.Groups[2].Value);

            var direction = Direction.Horizontal;

            switch (match.Groups[4].Value)
            {
                case "-":
                    direction = Direction.Horizontal;
                    break;
                case "|":
                    direction = Direction.Vertical;
                    break;
            }
            
            Ship result = null;

            switch (match.Groups[3].Value)
            {
                case "":
                case "x1":
                    result = new PatrolBoat(x, y, direction);
                    break;
                case "x2":
                    result = new Cruiser(x, y, direction);
                    break;
                case "x3":
                    result = new Submarine(x, y, direction);
                    break;
                case "x4":
                    result = new AircraftCarrier(x, y, direction);
                    break;
            }

            return result;
        }
    }
}