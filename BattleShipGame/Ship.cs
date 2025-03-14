using System.Collections.Generic;
using System.Linq;

namespace BattleshipGame
{
    public class Ship
    {
        public List<Position> Positions { get; }
        private HashSet<Position> Hits { get; }
        public bool IsAtPosition(Position position) => Positions.Contains(position);
        public bool IsAlreadyHit(Position position) => Hits.Contains(position);

        public Ship(IEnumerable<Position> positions)
        {
            Positions = positions.ToList();
            Hits = new HashSet<Position>();
        }

        public bool RegisterHit(Position position)
        {
            if (IsAtPosition(position) && !IsAlreadyHit(position))
            {
                Hits.Add(position);
                return true;
            }
            return false;
        }

        public bool IsSunk() => Hits.Count == Positions.Count;
    }
}
