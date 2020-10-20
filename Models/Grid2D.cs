using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Models
{
    struct Grid2D
    {
        // Prop
        public float StepX { get; set; }
        public int NodesX { get; set; }
        public float StepY { get; set; }
        public int NodesY { get; set; }

        // Constructor
        public Grid2D(float stx, int kntx, float sty, int knty)
        {
            StepX = stx;
            NodesX = kntx;
            StepY = sty;
            NodesY = knty;
        }

        // Methods (over)
        public override string ToString()

        {
            return "\nSteps for x: " + StepX.ToString() + " Nodes for x: " + NodesX.ToString() + " Steps for y: " + StepY.ToString() + " Nodes for y: " + NodesY.ToString();
        }
    }
}
