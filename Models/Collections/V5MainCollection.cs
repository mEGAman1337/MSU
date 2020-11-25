using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Lab1.Models.Collections
{
    class V5MainCollection : IEnumerable
    {
        //Prop
        private List<V5Data> DataList;

        public V5MainCollection()
        {
            DataList = new List<V5Data>();
        }

        public IEnumerable<DataItem> DataItems
        {
            get
            {
                return from data in DataList
                       from item in data.DataItems
                       orderby item
                       select item;
            }
        }


        public IEnumerator GetEnumerator()
        {
            return DataList.GetEnumerator();
        }

        public int Count()
        {
            return DataList.Count;
        }

        public void Add(V5Data item)
        {
            DataList.Add(item);
        }

        public bool Remove(string id, DateTime date)
        {
            bool f = false;
            for (int i = 0; i < DataList.Count; i++)
            {
                if (String.Equals(DataList[i].Info, id) == true && DataList[i].MeasureDate.CompareTo(date) == 0)
                {
                    DataList.RemoveAt(i);
                    i--;
                    f = true;
                }
            }
            return f;
        }

        public void AddDefaults()
        {
            Random rnd = new Random();
            int NumOfElements = rnd.Next(1, 5), n;
            Grid2D item;
            V5DataCollection f1;
            V5DataOnGrid f2;
            int k;
            DataList = new List<V5Data>();

            f1 = new V5DataCollection("", DateTime.Now);
            f1.InitRandom(0, 0, 0, 0, 0);
            DataList.Add(f1);

            item = new Grid2D(0, 0, 0, 0);
            f2 = new V5DataOnGrid("", DateTime.Now, item);
            f2.InitRandom(0, 0);
            DataList.Add(f2);

            for (int i = 0; i < NumOfElements; i++)
            {
                k = rnd.Next(0, 2);
                item = new Grid2D(4, 4, 4, 4);
                if (k == 0)
                {
                    f2 = new V5DataOnGrid("", DateTime.Now, item);
                    f2.InitRandom(1, 4);
                    DataList.Add(f2);
                }
                else
                {
                    n = rnd.Next(1, 20);
                    f1 = new V5DataCollection("", DateTime.Now);
                    f1.InitRandom(n, 4, 5, 6, 5);
                    DataList.Add(f1);
                }
            }
        }

        public override string ToString()
        {
            string str = "";
            foreach (V5Data item in DataList)
            {
                str += item.ToString();
            }
            return str;
        }

        public  string ToLongString(string format)
        {
            string str = "";
            foreach (V5Data item in DataList)
            {
                str += item.ToString(format);
            }
            return str;
        }

        public float MaxDistance(Vector2 v)
        {
            var res = from data in DataList
                        from item in data.DataItems
                        select Vector2.Distance(v, item.coordinate);
            return res.Max();
        }

        public IEnumerable<DataItem> MaxDistanceItems (Vector2 v)
        {
            var res = from data in DataList
                        from item in data.DataItems
                        where Vector2.Distance(v, item.coordinate) == MaxDistance(v)
                        select item;
            return res;
        }
    }
}
