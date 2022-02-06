using System;
using OneRefList;
using TwoRefList;

namespace Lists
{
    class Program
    {
        public static void OneRefMain()
        {
            OneRefList<int> lst = new(1, 5, 1, 9, 9, 9, 3);
            Console.WriteLine("Length is: " + lst.Length);
            Console.WriteLine("Initial list: " + lst.ToString());
            lst.Add(0);

            Console.WriteLine(lst[0].data);
            lst.RemoveAt(0);
            Console.WriteLine(lst[0].data);
            lst.PopFront();
            Console.WriteLine(lst[0].data);

            Console.WriteLine(lst[3].data);
            lst.Insert(3, 100);
            Console.WriteLine(lst[3].data);
        }

        public static void TwoRefMain()
        {
            OneRefList<float> lst = new(1, 1, 2.1f, 3.3f, 11.1f);
            Console.WriteLine("Length is: " + lst.Length);
            Console.WriteLine("Initial list: " + lst.ToString());
            lst.Add(0);

            Console.WriteLine(lst[0].data);
            lst.RemoveAt(0);
            Console.WriteLine(lst[0].data);
            lst.PopFront();
            Console.WriteLine(lst[0].data);

            Console.WriteLine(lst[2].data);
            lst.Insert(2, 100f);
            Console.WriteLine(lst[2].data);
        }

        static void Main(string[] args)
        {
            OneRefMain();
            Console.WriteLine("\n");
            TwoRefMain();
        }
    }
}
