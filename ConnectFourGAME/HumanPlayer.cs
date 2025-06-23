using System;

namespace ConnectFourGAME
{
    class HumanPlayer : Player
    {
        public HumanPlayer(string name, char symbol) : base(name, symbol) { }

        public override int GetMove(Board board)
        {
            int column;
            bool validInput;

            do
            {
                Console.Write($"{Name} ({Symbol}), choose a column (1–7): ");
                string input = Console.ReadLine();
                validInput = int.TryParse(input, out column) &&
                             column >= 1 &&
                             column <= 7 &&
                             !board.IsColumnFull(column - 1);

                if (!validInput)
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 7, and make sure the column is not full.");
            }
            while (!validInput);

            return column - 1;
        }
    }
}
