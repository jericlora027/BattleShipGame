using BattleshipGame;

public static class ShipSetup
{
    // Ship setup a putting a coordinates  1 6 1 H
    public static void SetupPlayerShips(Player player)
    {
        Console.WriteLine();
        Console.WriteLine($"{player.Name}, set up your ships:");

        bool addingShips = true;
        while (addingShips)
        {
            Console.Write("Enter ship start (x y), length, and orientation (H/V): ");
            var input = Console.ReadLine().Split(' ');

            if (input.Length == 4 &&
                int.TryParse(input[0], out int x) &&
                int.TryParse(input[1], out int y) &&
                int.TryParse(input[2], out int length) &&
                (input[3].ToUpper() == "H" || input[3].ToUpper() == "V"))
            {
                var positions = new List<Position>();
                for (int i = 0; i < length; i++)
                {
                    positions.Add(input[3].ToUpper() == "H" ? new Position(x + i, y) : new Position(x, y + i));
                }

                try
                {
                    player.Board.AddShip(new Ship(positions));
                    Console.WriteLine("Ship added!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }else if (input.Length == 1 && input[0].ToLower() == "xx")
            {
                Console.WriteLine();
                Console.WriteLine("Game manually ended.");
                System.Environment.Exit(0);
            }
            
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }

            Console.Write("Add another ship? (y/n): ");
            if (Console.ReadLine().Trim().ToLower() != "y")
            {
                addingShips = false;
            }
        }
    }
}

