namespace Battleship.Ships.ShipParsers
{
    public interface IShipParser
    {
        Ship Parse(string notation);
    }
}