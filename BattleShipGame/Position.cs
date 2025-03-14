﻿using System;

namespace BattleshipGame
{
    public class Position
    {
        public int X { get; }
        public int Y { get; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            return obj is Position position && X == position.X && Y == position.Y;
        }

        public override int GetHashCode() => HashCode.Combine(X, Y);
    }
}
