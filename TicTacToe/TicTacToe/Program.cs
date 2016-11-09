using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        // Tic Tac Toe
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();

            Console.ReadKey();
        }
    }
}
