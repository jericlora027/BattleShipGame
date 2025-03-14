using System;
using System.Collections.Generic;

namespace BattleshipGame
{
     class Program
    {
        // Summary this Battleship game. 2 players, alternating turns, and final score tally.
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Battleship!\n");
            Console.WriteLine("Sample Coordinate Ship Entry: 1 8 2 H");
            Console.WriteLine("Sample Attack Entry: 1 8");
            Console.WriteLine("Input: xx [Enter]  - to end the game. \n");

  
            var player1 = new Player("Player 1");
            var player2 = new Player("Player 2");

            ShipSetup.SetupPlayerShips(player1);
            ShipSetup.SetupPlayerShips(player2);

            var game = new Game(player1, player2);
            game.Play();
        }
    }
}