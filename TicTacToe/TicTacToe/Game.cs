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

            while (!gameOver)
            {
                Console.Clear();
                grid.PlaceMarker();

            }

        }

    }
}
