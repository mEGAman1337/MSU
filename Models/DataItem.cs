using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Lab1.Models
{
    public struct DataItem
    {
        public Vector2 coordinate { get; set; }
        public Vector2 value { get; set; }

        public DataItem(Vector2 coord, Vector2 val)
        {
            coordinate = coord;
            value = val;
        }

        public override string ToString()
        {
            return coordinate.ToString() + " " + value.ToString();
        }

        public string ToString(string format)
        {
            return coordinate.ToString(format) + " " + value.ToString(format);
        }
    }
}
