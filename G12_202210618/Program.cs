using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace G12_202210618
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            const int constanta = 15;

            MyList list = new MyList();

            for (int i = 0; i < constanta; i++)
            {
                string tt = "Kakha" + (i + 1);
                list.Add(tt);
            }

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            //var tte = list.Count;
            //var tty = list.Capacity;
            

            //list.Insert(5, "kakha3");

            //list.Remove(5);

            //list.RemoveAt(5);

            //var containseValue = list.Contains(5);
            //var containseValue1 = list.Contains(2);

            //list.Insert(5, 3);

            //var findeIndex = list.IndexOf(3);
            //var findeIndexFromValue = list.IndexOf(3, 4);
            //var findeIndexFromValue1 = list.IndexOf(50, 4);
            //var findeIndexFromValue2 = list.IndexOf(30);

            //var qwree=list.Count;
            //var qwree1 = list.Capacity;


            

            //Console.WriteLine($"\n Count  {list.Count} \n Capasity {list.Capacity}");
            //Console.WriteLine();
            
        }
    }
}
