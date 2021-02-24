using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace Lab1.Models.Collections
{
    public class V5DataCollection : V5Data, IEnumerable<DataItem>
    {
        public Dictionary<Vector2, Vector2> Dictionary { get; set; }

        // Constructor
        public V5DataCollection(string info, DateTime date) : base(info, date)
        {
            Dictionary = new Dictionary<Vector2, Vector2>();
            DataItems = new List<DataItem>();
        }

        /*
         * Данные хранятся в файле 'V5Data.txt'
         * Каждая строка является описанием одного объекта типа 'KeyValuePair<Vector2, Vector2>'
         * Значения записаны через пробел, чтение происходит построчно после применения операции string.Split(' ')
         * x (x coord), y (y coord), xVal (value in x), yVal (value in y)
         */
        public V5DataCollection(string info, DateTime date, string filename) : base(info, date)
        {
            try
            {
                Dictionary = new Dictionary<Vector2, Vector2>();
                using (StreamReader sr = new StreamReader(filename))
                {
                    string str1, str2;
                    Vector2 key, value;
                    float x, y, xVal, yVal;
                    while ((str1 = sr.ReadLine()) != null)
                    {
                        str2 = str1;

                        //Делим пробелами
                        string[] pool = str2.Split(' ');

                        x = float.Parse(pool[0]);
                        y = float.Parse(pool[1]);
                        xVal = float.Parse(pool[2]);
                        yVal = float.Parse(pool[3]);

                        key = new Vector2(x, y);
                        value = new Vector2(xVal, yVal);
                        Console.WriteLine(value);
                        Dictionary.Add(key, value);
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("Cannot read file: " + exc.Message);
                Console.WriteLine("Exiting program due to fatal error in reading file...");
                throw;
            }
        }

        // Methods
        public void InitRandom(int nItems, float xmax, float ymax, float minValue, float maxValue)
        {
            var random = Program.Random;

            float ran1, ran2, ran3, ran4, x2, y2, x1, y1;
            Vector2 keyD, valueD; //local table fix
            DataItem loc;
            for (int i = 0; i < nItems; i++)
            {
                ran1 = (float)random.NextDouble();
                ran2 = (float)random.NextDouble();
                ran3 = (float)random.NextDouble();
                ran4 = (float)random.NextDouble();

                x1 = minValue * ran1 + maxValue * (1 - ran1);
                y1 = minValue * ran2 + maxValue * (1 - ran2);
                x2 = xmax * ran3;
                y2 = ymax * ran4;

                keyD = new Vector2(x2, y2);
                valueD = new Vector2(x1, y1);

                loc = new DataItem(keyD, valueD);
                DataItems.Add(loc);

                if (!Dictionary.ContainsKey(keyD))
                {
                    Dictionary.Add(keyD, valueD);
                }
            }
        }

        public override Vector2[] NearEqual(float eps)
        {
            List<Vector2> list = new List<Vector2>();
            foreach (KeyValuePair<Vector2, Vector2> pair in Dictionary)
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
            string str = "V5DataCollection(s): " + Info + " " + MeasureDate + "\nNumber of elements: " + Dictionary.Count + "\n";
            return str;
        }

        public override string ToLongString()
        {
            string str = "V5DataCollection(ls):" + Info + " " + MeasureDate + "\nNumber of elements: " + Dictionary.Count + "\n";
            foreach (KeyValuePair<Vector2, Vector2> pair in Dictionary)
            {
                str += "V5DC: " + pair.Key + " " + pair.Value + "\n";
            }
            return str;
        }

        public string ToLongString(string format)
        {
            string str = "V5DataCollection(ls):" + Info + " " + MeasureDate.ToString(format) + "\nNumber of elements: " + Dictionary.Count + "\n";
            foreach (KeyValuePair<Vector2, Vector2> pair in Dictionary)
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

            foreach (KeyValuePair<Vector2, Vector2> pair in Dictionary)
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

            foreach (KeyValuePair<Vector2, Vector2> pair in Dictionary)
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
