using System;

namespace ConnectFourGAME
{
    class Program
    {
        static void Main()
        {
            Console.Write("Play against computer? (y/n): ");
            bool vsComputer = Console.ReadLine().ToLower() == "y";

            Player player1 = new HumanPlayer("Player 1", 'X');
            Player player2 = vsComputer
                ? new ComputerPlayer("Computer", 'O')
                : new HumanPlayer("Player 2", 'O');

            Game game = new Game(player1, player2);
            game.Start();
        }
    }
}
