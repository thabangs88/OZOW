using Questions.Library.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.Library.Model
{
    public class Cell
    {
        public string Name { get; set; }
        public CellState LiveState { get; set; }
        public PopulationState GenerationState { get; set; }
        public int NoNeighbours { get; set; }
        public Point Poistion { get; set; }
    }
}
