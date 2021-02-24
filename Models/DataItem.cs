using System;
using System.Numerics;
using Lab1.Extensions;

namespace Lab1.Models
{
    public struct DataItem : IComparable<DataItem>
    {
        public Vector2 Coordinate { get; set; }
        public Vector2 Value { get; set; }

        public DataItem(Vector2 coord, Vector2 val)
        {
            Coordinate = coord;
            Value = val;
        }

        public override string ToString()
        {
            return Coordinate + " " + Value;
        }

        public string ToString(string format)
        {
            return Coordinate.ToString(format) + " " + Value.ToString(format);
        }

        public int CompareTo(DataItem other)
        {
            if (Coordinate.CustomLength() > other.Coordinate.CustomLength()) return 1;
            if (Coordinate.CustomLength() < other.Coordinate.CustomLength()) return -1;
            return 0;
        }
    }
}
