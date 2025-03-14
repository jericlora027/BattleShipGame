using System;
using System.Collections.Generic;
using BattleshipGame;
using BattleShipGame.Enums;
using Xunit;

namespace BattleshipGame.Tests
{
    public class BattleshipTests
    {
        [Fact]
        public void Player_ShouldLose_WhenAllShipsAreSunk()
        {
            var player = new Player("Test Player");
            var shipPositions = new List<Position> { new Position(0, 0), new Position(0, 1) };
            player.Board.AddShip(new Ship(shipPositions));

            player.Board.Attack(new Position(0, 0));
            player.Board.Attack(new Position(0, 1));

            Assert.True(player.HasLost());
        }

        [Fact]
        public void Attack_ShouldReturn_HitOnValidShip()
        {
            var player = new Player("Test Player");
            player.Board.AddShip(new Ship(new List<Position> { new Position(1, 1) }));

            var result = player.Board.Attack(new Position(1, 1));

            Assert.Equal(AttackResult.Hit, result);
        }

        [Fact]
        public void Attack_ShouldReturn_MissOnEmptyPosition()
        {
            var player = new Player("Test Player");

            var result = player.Board.Attack(new Position(5, 5));

            Assert.Equal(AttackResult.Miss, result);
        }

        [Fact]
        public void Player_ShouldRecord_AttackResults()
        {
            var player = new Player("Test Player");
            player.Board.AddShip(new Ship(new List<Position> { new Position(2, 2) }));

            player.RecordAttack(player.Board.Attack(new Position(2, 2))); // this will Hit
            player.RecordAttack(player.Board.Attack(new Position(3, 3))); // this will Miss

            Assert.Equal(1, player.Hits);
            Assert.Equal(1, player.Misses);
        }

        [Fact]
        public void Board_ShouldNotAllow_OverlappingShips()
        {
            var player = new Player("Test Player");
            player.Board.AddShip(new Ship(new List<Position> { new Position(1, 1), new Position(1, 2) }));

            Assert.Throws<InvalidOperationException>(() =>
                player.Board.AddShip(new Ship(new List<Position> { new Position(1, 2), new Position(1, 3) }))
            );
        }
    }
}
