using BattleshipGame;
using BattleShipGame.Enums;

public class Player
{
    public string Name { get; }
    public Board Board { get; }
    public int Hits { get; private set; } = 0;
    public int Misses { get; private set; } = 0;

    public Player(string name)
    {
        Name = name;
        Board = new Board();
    }

    public bool HasLost() => Board.AllShipsSunk();

    public void RecordAttack(AttackResult result)
    {
        if (result == AttackResult.Hit) Hits++;
        if (result == AttackResult.Miss) Misses++;
    }
}