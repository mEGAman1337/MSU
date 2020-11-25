using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text;

namespace Lab1.Models
{
    public struct DataItem : IComparable<DataItem>
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



        public int CompareTo([AllowNull] DataItem other)
        {
            if (coordinate.Length() < other.coordinate.Length())
                return -1;
            if (coordinate.Length() == other.coordinate.Length())
                return 0;
            if (coordinate.Length() > other.coordinate.Length())
                return 1;
            else
                return -1;

        }
    }
}
