using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Grid
    {
        public bool gameWon { get; set; } = false;
        public event EventHandler GameOverReached;
        public int Threshold { get; set; }
        public int Round { get; set; }
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
            Threshold = Nodes.Count;
            Round = 1;
        }

        public void PlaceMarker()
        {

            var loop = true;

            while (loop)
            {
                Console.Clear();
                PrintGrid();

                Console.Write("Row:    ");
                int rowInput = ChooseRowOrColumn();
                Console.Write(Environment.NewLine + "Column: ");
                int colInput = ChooseRowOrColumn();

                var index = Nodes
                    .Where(node => (node.Row == rowInput && node.Col == colInput));

                foreach (var x in index)
                {
                    if (!x.Taken)
                    {
                        x.Player = ActivePlayer;
                        x.Taken = true;
                        x.Marker = x.Player.ToString();
                        loop = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(Environment.NewLine + "Already taken! Press enter.");
                        Console.ResetColor();
                        Console.ReadKey();
                    }
                }

            }
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

            Console.WriteLine(Environment.NewLine + "Player: {0}" + Environment.NewLine, ActivePlayer);
        }
        private int ChooseRowOrColumn()
        {
            var input = Console.ReadKey(false).Key;
            switch (input)
            {
                case ConsoleKey.D1:
                    return 1;
                case ConsoleKey.D2:
                    return 2;
                case ConsoleKey.D3:
                    return 3;
                default:
                    Console.WriteLine("Invalid input. Press key to continue.");
                    Console.ReadKey();
                    return -1;
            }
        }

        public bool isGameOver()
        {

            bool gameOver = false;

            for (int x = 0; x < 9; x += 3)
            {
                if (Nodes[x].Marker == ActivePlayer.ToString() && Nodes[x + 1].Marker == ActivePlayer.ToString() && Nodes[x + 2].Marker == ActivePlayer.ToString())
                {
                    gameOver = true;
                    gameWon = true;
                }
            }

            for (int y = 0; y < 3; y++)
            {
                if (Nodes[y].Marker == ActivePlayer.ToString() && Nodes[y + 3].Marker == ActivePlayer.ToString() && Nodes[y + 6].Marker == ActivePlayer.ToString())
                {
                    gameOver = true;
                    gameWon = true;
                }
            }

            if (Nodes[0].Marker == ActivePlayer.ToString() && Nodes[4].Marker == ActivePlayer.ToString() && Nodes[8].Marker == ActivePlayer.ToString())
            {
                gameOver = true;
                gameWon = true;
            }
            if (Nodes[2].Marker == ActivePlayer.ToString() && Nodes[4].Marker == ActivePlayer.ToString() && Nodes[6].Marker == ActivePlayer.ToString())
            {
                gameOver = true;
                gameWon = true;
            }

            if (!gameOver)
                ActivePlayer++;

            if (Round >= Threshold && gameWon == false)
            {
                OnGameOverReached(EventArgs.Empty);
                gameOver = true;
                Console.ReadKey();
            }

            return gameOver;
        }

        protected virtual void OnGameOverReached(EventArgs e)
        {
            GameOverReached?.Invoke(this, e);
        }
    }
}
