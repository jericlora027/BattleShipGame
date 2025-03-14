using BattleShipGame.Enums;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BattleshipGame
{
    public class Board
    {
        private readonly List<Ship> _ships = new();
        private readonly HashSet<Position> _attacks = new();

        public void AddShip(Ship ship)
        {
            if (IsValidShipPlacement(ship))
            {
                _ships.Add(ship);
            }
            else
            {
                throw new InvalidOperationException("Invalid ship placement.");
            }
        }

        public AttackResult Attack(Position position)
        {
            if (_attacks.Contains(position))
            {
                return AttackResult.AlreadyHit;
            }

            _attacks.Add(position);

            foreach (var ship in _ships)
            {
                if (ship.RegisterHit(position))
                {
                    return AttackResult.Hit;
                }
            }
            return AttackResult.Miss;
        }

        public bool AllShipsSunk() => _ships.All(ship => ship.IsSunk());

        private bool IsValidShipPlacement(Ship ship)
        {
            return ship.Positions.All(pos => pos.X >= 0 && pos.X < 10 && pos.Y >= 0 && pos.Y < 10) &&
                   _ships.All(existing => !existing.Positions.Intersect(ship.Positions).Any());
        }
    }
}
