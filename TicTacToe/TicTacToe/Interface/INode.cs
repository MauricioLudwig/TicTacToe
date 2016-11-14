using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public interface INode
    {
        int Player { get; set; }
        bool Taken { get; set; }
        int Row { get; set; }
        int Col { get; set; }
        string Marker { get; set; }
    }
}
