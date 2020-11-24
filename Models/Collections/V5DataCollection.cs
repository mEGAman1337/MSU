using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;

namespace Lab1.Models.Collections
{
    public class V5DataCollection : V5Data, IEnumerable<DataItem>
    {
        // Prop
        public override List<DataItem> DataItems { get; set; }
        public Dictionary<System.Numerics.Vector2, System.Numerics.Vector2> dictionary { get; set; }

        // Constructor
        public V5DataCollection(string info, DateTime date) : base(info, date)
        {
            dictionary = new Dictionary<Vector2, Vector2>();
            DataItems = new List<DataItem>();
        }

        //Данные представлены в виде 4 колонок
        //x (x coord), y (y coord), xVal (value in x), yVal (value in y)
        public V5DataCollection(string info, DateTime date, string filename) : base(info, date)
        {
            try
            {
                dictionary = new Dictionary<Vector2, Vector2>();
                using (StreamReader sr = new StreamReader(filename))
                {
                    string str1, str2;
                    Vector2 key, value;
                    float x, y, xVal, yVal;
                    while ((str1 = sr.ReadLine()) != null)
                    {
                        str2 = str1;

                        //Делим пробелами
                        string[] pool = str2.Split(new char[] { ' ' });

                        x = float.Parse(pool[0]);
                        y = float.Parse(pool[1]);
                        xVal = float.Parse(pool[2]);
                        yVal = float.Parse(pool[3]);

                        key = new Vector2(x, y);
                        value = new Vector2(xVal, yVal);
                        Console.WriteLine(value);
                        dictionary.Add(key, value);
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("Cannot read file: " + exc.Message);
            }
        }

        // Methods
        public void InitRandom(int nItems, float xmax, float ymax, float minValue, float maxValue)
        {
            Random rand = new Random();
            float ran1, ran2, ran3, ran4, x2, y2, x1, y1;
            Vector2 keyD, valueD; //local table fix
            DataItem loc;
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

                keyD = new Vector2(x2, y2);
                valueD = new Vector2(x1, y1);

                loc = new DataItem(keyD, valueD);
                DataItems.Add(loc);

                dictionary.Add(keyD, valueD);
            }
        }

        public override Vector2[] NearEqual(float eps)
        {
            List<Vector2> list = new List<Vector2>();
            foreach (KeyValuePair<Vector2, Vector2> pair in dictionary)
            {
                Vector2 addition = pair.Value;
                if (Math.Abs(addition.X - addition.Y) <= eps)
                    list.Add(addition);

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

        public string ToLongString(string format)
        {
            string str = "V5DataCollection(ls):" + Info + " " + MeasureDate.ToString(format) + "\nNumber of elements: " + dictionary.Count + "\n";
            foreach (KeyValuePair<Vector2, Vector2> pair in dictionary)
            {
                str += pair.Key + " " + pair.Value.ToString(format) + "\n";
            }
            return str;
        }

        public IEnumerator<DataItem> GetEnumerator()
        {
            List<DataItem> list = new List<DataItem>();
            Vector2 val, coord;
            DataItem addition;

            foreach (KeyValuePair<Vector2, Vector2> pair in dictionary)
            {
                val = pair.Value;
                coord = pair.Key;
                addition = new DataItem(coord, val);
                list.Add(addition);
            }
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            List<DataItem> list = new List<DataItem>();
            Vector2 value, coordinate;
            DataItem tmp;

            foreach (KeyValuePair<Vector2, Vector2> pair in dictionary)
            {
                coordinate = pair.Key;
                value = pair.Value;
                tmp = new DataItem(coordinate, value);
                list.Add(tmp);
            }
            return list.GetEnumerator();
        }

    }
}
