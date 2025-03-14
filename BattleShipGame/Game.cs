using BattleshipGame;

public class Game
{
    private Player _player1;
    private Player _player2;

    public Game(Player player1, Player player2)
    {
        _player1 = player1;
        _player2 = player2;
    }

    // loop players turn and tally of final score
    public void Play()
    {
        Player currentPlayer = _player1;
        Player opponent = _player2;

        while (!_player1.HasLost() && !_player2.HasLost())
        {
            Console.WriteLine();
            Console.WriteLine($"{currentPlayer.Name}'s turn:");
            Console.Write("Enter attack coordinates (x y) or 'xx' to end the game: ");
            var input = Console.ReadLine().Split(' ');

            if (input.Length == 1 && input[0].ToLower() == "xx")
            {
                Console.WriteLine("Game force ended.");
                break;
            }

            if (input.Length == 2 && int.TryParse(input[0], out int x) && int.TryParse(input[1], out int y))
            {
                var result = opponent.Board.Attack(new Position(x, y));
                Console.WriteLine($"Attack result: {result}");
                currentPlayer.RecordAttack(result);

                if (opponent.HasLost())
                {
                    Console.WriteLine($"{currentPlayer.Name} wins! Congratulations, {currentPlayer.Name}!");
                    break;
                }

                // Switch turns
                (currentPlayer, opponent) = (opponent, currentPlayer);
            }
            else
            {
                Console.WriteLine("Invalid input. Try again.");
            }
        }

        // Tally of Score
        Console.WriteLine("Game Over!");
        Console.WriteLine($"{_player1.Name} Hits: {_player1.Hits}, Misses: {_player1.Misses}");
        Console.WriteLine($"{_player2.Name} Hits: {_player2.Hits}, Misses: {_player2.Misses}");
    }
}