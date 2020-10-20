using Lab1.Models;
using Lab1.Models.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Lab1
{

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("№ 1\n");
            Grid2D item = new Grid2D(3, 3, 3, 3);
            V5DataOnGrid obj = new V5DataOnGrid("", DateTime.Now, item);
            obj.InitRandom(1, 5);
            Console.WriteLine(obj.ToLongString());
            V5DataCollection obj1 = (V5DataCollection)obj;
            Console.WriteLine(obj1.ToLongString());

            Console.WriteLine("№ 2\n");
            V5MainCollection obj2 = new V5MainCollection();
            obj2.AddDefaults();
            Console.WriteLine(obj2.ToString());

            Console.WriteLine("№ 3\n");
            Vector2[] array;

            foreach (V5Data ob in obj2)
            {
                array = ob.NearEqual(2);
                for (int i = 0; i < array.Length; i++)
                {
                    Console.WriteLine(array[i].X + " " + array[i].Y + "\n");
                }
            }
            Console.WriteLine(obj2.ToString());
        }
    }
}


