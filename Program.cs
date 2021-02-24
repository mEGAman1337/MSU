using Lab1.Models;
using Lab1.Models.Collections;
using System;
using System.Numerics;

namespace Lab1
{

    public class Program
    {
        public static Random Random = new Random();

        public static void Main()
        {
            V5DataCollection task1 = new V5DataCollection("", DateTime.Now, Constants.V5DataFileName);
            Console.WriteLine(task1.ToLongString("e4"));

            V5MainCollection task2 = new V5MainCollection();
            task2.AddDefaults();
            Console.WriteLine(task2.ToString());

            Vector2 point;
            point.X = 1;
            point.Y = 1;

            Console.WriteLine("MaxDistance");
            Console.WriteLine(task2.MaxDistance(point).ToString("e4"));

            Console.WriteLine("MaxDistanceItem");
            foreach (DataItem s1 in task2.MaxDistanceItems(point))
                Console.WriteLine(s1.ToString("e4"));

            Console.WriteLine("DataItems");

                foreach (DataItem s2 in task2.DataItems)
                {
                    Console.WriteLine(s2.ToString());
                }
            

        }
    }
}


