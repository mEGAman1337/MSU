using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Lab1.Models.Collections
{
    class V5MainCollection : IEnumerable
    {
        //Prop
        private List<V5Data> _dataList;

        public V5MainCollection()
        {
            _dataList = new List<V5Data>();
        }

        public IEnumerable<DataItem> DataItems =>
            from data in _dataList
            from item in data.DataItems
            orderby item
            select item;


        public IEnumerator GetEnumerator()
        {
            return _dataList.GetEnumerator();
        }

        public int Count()
        {
            return _dataList.Count;
        }

        public void Add(V5Data item)
        {
            _dataList.Add(item);
        }

        public bool Remove(string id, DateTime date)
        {
            bool f = false;
            for (int i = 0; i < _dataList.Count; i++)
            {
                if (String.Equals(_dataList[i].Info, id) == true && _dataList[i].MeasureDate.CompareTo(date) == 0)
                {
                    _dataList.RemoveAt(i);
                    i--;
                    f = true;
                }
            }
            return f;
        }

        public void AddDefaults()
        {
            var random = Program.Random;

            int numOfElements = random.Next(1, 5), n;
            Grid2D item;
            V5DataCollection f1;
            V5DataOnGrid f2;
            int k;
            _dataList = new List<V5Data>();

            f1 = new V5DataCollection("", DateTime.Now);
            f1.InitRandom(3, 4, 5, 0, 6);
            _dataList.Add(f1);

            item = new Grid2D(0, 10, 0, 10);
            f2 = new V5DataOnGrid("", DateTime.Now, item);
            f2.InitRandom(0, 10);
            _dataList.Add(f2);

            for (int i = 0; i < numOfElements; i++)
            {
                k = random.Next(0, 2);
                item = new Grid2D(4, 4, 4, 4);
                if (k == 0)
                {
                    f2 = new V5DataOnGrid("", DateTime.Now, item);
                    f2.InitRandom(1, 4);
                    _dataList.Add(f2);
                }
                else
                {
                    n = random.Next(1, 20);
                    f1 = new V5DataCollection("", DateTime.Now);
                    f1.InitRandom(n, 4, 5, 6, 5);
                    _dataList.Add(f1);
                }
            }
        }

        public override string ToString()
        {
            string str = "";
            foreach (V5Data item in _dataList)
            {
                str += item.ToString();
            }
            return str;
        }

        public  string ToLongString(string format)
        {
            string str = "";
            foreach (V5Data item in _dataList)
            {
                str += item.ToString(format);
            }
            return str;
        }

        public float MaxDistance(Vector2 v)
        {
            var res = from data in _dataList
                        from item in data.DataItems
                        select Vector2.Distance(v, item.Coordinate);
            return res.Max();
        }

        public IEnumerable<DataItem> MaxDistanceItems (Vector2 v)
        {
            var res = from data in _dataList
                        from item in data.DataItems
                        where Vector2.Distance(v, item.Coordinate) == MaxDistance(v)
                        select item;
            return res;
        }
    }
}
