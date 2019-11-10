using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tic_tac_toe.Models
{
    public class Position
    {
        public int PlayerId { get; set; }
        public int X_Coordinate { get; set; }

        public int Y_Coordinate { get; set; }
    }
}
