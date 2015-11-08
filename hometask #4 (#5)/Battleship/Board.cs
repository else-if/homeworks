using System;
using System.Collections.Generic;
using System.Linq;
using Battleship.Exceptions;
using Battleship.Ships;
using Battleship.Ships.ShipAttributes;
using Battleship.Ships.ShipsSamples;

namespace Battleship
{
    public class Board
    {
        private const int MaxX = 10;
        private const int MaxY = 10;

        private readonly List<Ship> _ships;

        public Board()
        {
            _ships = new List<Ship>();
        }

        public void Add(Ship ship)
        {
            if(ship==null) throw new ArgumentNullException();

            uint xEnd = ship.Direction == Direction.Vertical ? ship.X : ship.X + ship.Length - 1;
            uint yEnd = ship.Direction == Direction.Vertical ? ship.Y + ship.Length - 1 : ship.Y;

            if ((ship.X < 1) || (ship.X > MaxX) || (ship.Y < 1) || (ship.Y > MaxY)
                || (xEnd < 1) || (xEnd > MaxX) || (yEnd < 1) || (yEnd > MaxY))
                throw new ArgumentOutOfRangeException();

            foreach (var settedShip in _ships)
            {
                if (settedShip.OverlapsWith(ship))
                    throw new ShipOverlapException($"Ship {settedShip} overlaps with {ship}");
            }
            _ships.Add(ship);
        }

        public void Add(string notation)
        {
            Add(Ship.Parse(notation));
        }

        public List<Ship> GetAll()
        {
            return _ships.ToList();
        }

        public void Validate()
        {
            if ((_ships.Count(s => s is PatrolBoat) != 4)
                || (_ships.Count(s => s is Cruiser) != 3)
                || (_ships.Count(s => s is Submarine) != 2)
                || (_ships.Count(s => s is AircraftCarrier) != 1))
                throw new BoardIsNotReadyException(
                    "There is not sufficient count of ships.We need: PatrolBoat(4), Cruiser(3), Submarine(2), AircraftCarrier(1)");
        }
    }
}