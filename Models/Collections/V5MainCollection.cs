using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Models.Collections
{
    class V5MainCollection : IEnumerable
    {
        //Prop
        IEnumerable<V5Data> DataEn;
        private List<V5Data> DataList;

        float fl1 = 1, fl2 = 1;
        int in1 = 10, in2 = 10;

        Grid2D item;

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
            int NumOfElements = rnd.Next(3, 5), n;
            Grid2D item;
            V5DataCollection obj1;
            V5DataOnGrid obj2;
            int bin;
            DataList = new List<V5Data>();
            for (int i = 0; i < NumOfElements; i++)
            {
                bin = rnd.Next(0, 2);
                item = new Grid2D(1, 1, 2, 2);
                if (bin == 0)
                {
                    obj2 = new V5DataOnGrid("", DateTime.Now, item);
                    obj2.InitRandom(1, 4);
                    DataList.Add(obj2);
                }
                else
                {
                    n = rnd.Next(1, 20);
                    obj1 = new V5DataCollection("", DateTime.Now);
                    obj1.InitRandom(n, 4, 5, 1, 4);
                    DataList.Add(obj1);
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
    }
}
