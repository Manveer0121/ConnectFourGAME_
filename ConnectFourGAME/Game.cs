using System;

namespace ConnectFourGAME
{
    class Game
    {
        private Board board;
        private Player[] players;
        private int currentPlayer;

        public Game(Player p1, Player p2)
        {
            board = new Board();
            players = new Player[] { p1, p2 };
            currentPlayer = 0;
        }

        public void Start()
        {
            bool playAgain;
            do
            {
                board = new Board();
                currentPlayer = 0;
                PlayGame();
                Console.Write("Play again? (y/n): ");
                playAgain = Console.ReadLine().ToLower() == "y";
            } while (playAgain);
        }

        private void PlayGame()
        {
            bool gameWon = false;
            board.PrintBoard();

            while (!board.IsFull())
            {
                Player player = players[currentPlayer];
                int col = player.GetMove(board);

                if (board.PlaceDisc(col, player.Symbol, out int row))
                {
                    board.PrintBoard();

                    if (board.CheckWin(row, col, player.Symbol))
                    {
                        Console.WriteLine($"{player.Name} ({player.Symbol}) wins!");
                        gameWon = true;
                        break;
                    }

                    currentPlayer = 1 - currentPlayer;
                }
            }

            if (!gameWon)
                Console.WriteLine("It's a tie!");
        }
    }
}
