using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Lab1.Models.Collections
{
    public class V5DataCollection : V5Data
    {
        // Prop
        public Dictionary<System.Numerics.Vector2, System.Numerics.Vector2> dictionary { get; set; }

        // Constructor
        public V5DataCollection(string info, DateTime date) : base(info, date)
        {
            dictionary = new Dictionary<Vector2, Vector2>();
        }

        // Methods
        public void InitRandom(int nItems, float xmax, float ymax, float minValue, float maxValue)
        {
            Random rand = new Random();
            float ran1, ran2, ran3, ran4, x2, y2, x1, y1;
            Vector2 key, value;
            for (int i = 0; i < nItems; i++)
            {
                ran1 = (float)rand.NextDouble();
                ran2 = (float)rand.NextDouble();
                ran3 = (float)rand.NextDouble();
                ran4 = (float)rand.NextDouble();
                x1 = minValue * ran1 + maxValue * (1 - ran1);
                y1 = minValue * ran2 + maxValue * (1 - ran2);
                x2 = xmax * ran3;
                y2 = ymax * ran4;
                key = new Vector2(x2, y2);
                value = new Vector2(x1, y1);
                dictionary.Add(key, value);
            }
        }

        public override Vector2[] NearEqual(float eps)
        {
            List<Vector2> list = new List<Vector2>();
            foreach (KeyValuePair<Vector2, Vector2> pair in dictionary)
            {
                Vector2 elements = pair.Value;
                if (Math.Abs(elements.X - elements.Y) <= eps)
                    list.Add(elements);

            }
            Vector2[] array = list.ToArray();
            return array;
        }

        public override string ToString()

        {
            string str = "V5DataCollection(s): " + Info + " " + MeasureDate.ToString() + "\nNumber of elements: " + dictionary.Count + "\n";
            return str;
        }

        public override string ToLongString()
        {
            string str = "V5DataCollection(ls):" + Info + " " + MeasureDate.ToString() + "\nNumber of elements: " + dictionary.Count + "\n";
            foreach (KeyValuePair<Vector2, Vector2> pair in dictionary)
            {
                str += "V5DC: " + pair.Key + " " + pair.Value + "\n";
            }
            return str;
        }
    }
}
