using System;

namespace ConnectFourGAME
{
    class Board
    {
        private char[,] grid = new char[6, 7];

        public Board()
        {
            for (int r = 0; r < 6; r++)
                for (int c = 0; c < 7; c++)
                    grid[r, c] = ' ';
        }

        public void PrintBoard()
        {
            Console.WriteLine();
            for (int r = 0; r < 6; r++)
            {
                Console.Write("|");
                for (int c = 0; c < 7; c++)
                    Console.Write($"{grid[r, c]}|");
                Console.WriteLine();
            }
            Console.WriteLine(" 1 2 3 4 5 6 7\n");
        }

        public bool PlaceDisc(int col, char symbol, out int row)
        {
            for (int r = 5; r >= 0; r--)
            {
                if (grid[r, col] == ' ')
                {
                    grid[r, col] = symbol;
                    row = r;
                    return true;
                }
            }
            row = -1;
            return false;
        }

        public bool IsColumnFull(int col)
        {
            return grid[0, col] != ' ';
        }

        public bool IsFull()
        {
            for (int c = 0; c < 7; c++)
                if (!IsColumnFull(c)) return false;
            return true;
        }

        public bool CheckWin(int row, int col, char symbol)
        {
            return CheckDirection(row, col, symbol, 1, 0) ||
                   CheckDirection(row, col, symbol, 0, 1) ||
                   CheckDirection(row, col, symbol, 1, 1) ||
                   CheckDirection(row, col, symbol, 1, -1);
        }

        private bool CheckDirection(int row, int col, char symbol, int dr, int dc)
        {
            int count = 1;
            for (int i = 1; i < 4; i++)
            {
                int r = row + dr * i, c = col + dc * i;
                if (r >= 0 && r < 6 && c >= 0 && c < 7 && grid[r, c] == symbol)
                    count++;
                else break;
            }
            for (int i = 1; i < 4; i++)
            {
                int r = row - dr * i, c = col - dc * i;
                if (r >= 0 && r < 6 && c >= 0 && c < 7 && grid[r, c] == symbol)
                    count++;
                else break;
            }
            return count >= 4;
        }
    }
}
