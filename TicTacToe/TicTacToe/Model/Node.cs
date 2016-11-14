using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Node : INode
    {
        public int Player { get; set; }
        public bool Taken { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        public string Marker { get; set; }
    }
}
