using System;

namespace ConnectFourGAME
{
    class ComputerPlayer : Player
    {
        public ComputerPlayer(string name, char symbol) : base(name, symbol) { }

        public override int GetMove(Board board)
        {
            for (int col = 0; col < 7; col++)
            {
                if (!board.IsColumnFull(col))
                {
                    Console.WriteLine($"{Name} ({Symbol}) chooses column {col + 1}");
                    return col;
                }
            }
            return -1;
        }
    }
}
