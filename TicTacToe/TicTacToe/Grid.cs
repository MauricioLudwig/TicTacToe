using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Grid
    {
        public List<INode> Nodes { get; set; }
        private int activePlayer;
        public int ActivePlayer
        {
            get { return activePlayer; }
            set
            {
                if (value > 2)
                    activePlayer = 1;
                else
                    activePlayer = value;
            }
        }

        public Grid()
        {
            Nodes = new List<INode>()
            {
                new Node { Marker = "X", Row = 1, Col = 1, Player = 0, Taken = false},
                new Node { Marker = "X", Row = 1, Col = 2, Player = 0, Taken = false},
                new Node { Marker = "X", Row = 1, Col = 3, Player = 0, Taken = false},
                new Node { Marker = "X", Row = 2, Col = 1, Player = 0, Taken = false},
                new Node { Marker = "X", Row = 2, Col = 2, Player = 0, Taken = false},
                new Node { Marker = "X", Row = 2, Col = 3, Player = 0, Taken = false},
                new Node { Marker = "X", Row = 3, Col = 1, Player = 0, Taken = false},
                new Node { Marker = "X", Row = 3, Col = 2, Player = 0, Taken = false},
                new Node { Marker = "X", Row = 3, Col = 3, Player = 0, Taken = false}
            };

            ActivePlayer = 1;
        }

        public void PlaceMarker()
        {
            var mTaken = true;

            while (mTaken)
            {
                Console.Clear();
                PrintGrid();

                Console.Write("Row:    ");
                int rowInput = int.Parse(Console.ReadLine());
                Console.Write("Column: ");
                int colInput = int.Parse(Console.ReadLine());

                var y = Nodes
                    .Where(node => (node.Row == rowInput && node.Col == colInput));

                var tempList = Nodes
                    .Where(node => node.Taken == false);

                Console.WriteLine(y);

                Console.ReadKey();

                var index = tempList
                    .Where(node => (node.Row == rowInput && node.Col == colInput));

                foreach (var x in index)
                {
                    x.Player = ActivePlayer;
                    x.Taken = true;
                    x.Marker = x.Player.ToString();
                }

            }

            ActivePlayer++;
            Console.ReadKey();
        }

        public void PrintGrid()
        {

            int i = 1;

            foreach (var node in Nodes)
            {
                Console.Write(node.Marker + " ");
                if (i % 3 == 0)
                    Console.WriteLine();
                i++;
            }
        }
    }
}
