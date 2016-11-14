using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Game
    {


        public void Start()
        {

            Grid grid = new Grid();
            bool gameOver = false;

            grid.GameOverReached += (sender, e) =>
            {
                Console.WriteLine(Environment.NewLine + "Draw!");
            };

            while (!gameOver)
            {
                Console.Clear();
                grid.PlaceMarker();
                gameOver = grid.isGameOver();
                grid.Round++;
            }

            Console.Clear();
            grid.PrintGrid();
            if (grid.gameWon)
            {
                Console.WriteLine("Game over! Player {0} won", grid.ActivePlayer);
            }
        }

    }
}
