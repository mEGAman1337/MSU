using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Lab1.Models.Collections
{
    class V5DataOnGrid : V5Data
    {
        // Prop
        public Grid2D GridData { get; set; }
        public Vector2[,] NodeScore { get; set; }

        // Contructor
        public V5DataOnGrid(string info, DateTime date, Grid2D grid) : base(info, date)
        {
            GridData = grid;
            NodeScore = new Vector2[GridData.NodesX, GridData.NodesY];
        }

        // Methods (5)
        public void InitRandom(float minValue, float maxValue)
        {
            Random rand = new Random();
            float rand1, rand2, minv, maxv;
            for (int i = 0; i < GridData.NodesX; i++)
            {
                for (int j = 0; j < GridData.NodesY; j++)
                {
                    rand1 = (float)rand.NextDouble();
                    rand2 = (float)rand.NextDouble();
                    minv = minValue * rand1 + maxValue * (1 - rand1);
                    maxv = minValue * rand2 + maxValue * (1 - rand2);
                    NodeScore[i, j] = new Vector2(minv, maxv);
                }
            }
        }

        // All pairs <eps
        public override Vector2[] NearEqual(float eps)
        {
            List<Vector2> list = new List<Vector2>();
            for (int i = 0; i < GridData.NodesX; i++)
                for (int j = 0; j < GridData.NodesY; j++)
                    if (Math.Abs(NodeScore[i, j].X - NodeScore[i, j].Y) <= eps)
                        list.Add(NodeScore[i, j]);
            Vector2[] array = list.ToArray();
            return array;
        }

        public override string ToString()

        {
            string str = "V5DataOnGrid(s):\n" + Info + " " + MeasureDate.ToString() + " " + GridData.ToString() + "\n";
            return str;
        }

        public override string ToLongString()
        {
            string str = "V5DataOnGrid(ls):\n" + Info + " " + MeasureDate.ToString() + " " + GridData.ToString() + "\n";
            for (int i = 0; i < GridData.NodesX; i++)
                for (int j = 0; j < GridData.NodesY; j++)
                {
                    str += "Score for node " + "[" + i + "," + j + "] " + " is " + "(" + NodeScore[i, j].X + "," + NodeScore[i, j].Y + ")\n";
                }

            return str;
        }

        public static explicit operator V5DataCollection(V5DataOnGrid x)
        {
            int i, j;
            Vector2 key, value;
            V5DataCollection Result;
            Result = new V5DataCollection(x.Info, x.MeasureDate);
            for (i = 0; i < x.GridData.NodesX; i++)
                for (j = 0; j < x.GridData.NodesY; j++)
                {
                    key = new Vector2(i, j);
                    value = new Vector2(x.NodeScore[i, j].X, x.NodeScore[i, j].Y);
                    Result.dictionary.Add(key, value);
                }
            return Result;
        }
    }
}
