using Sorting;
using System;

namespace Task2
{
   
    class Program
    {
        
        static void Main(string[] args)
        {
            int[][] arr = {
                            new int[4]{1,2,3,4},
                            new int[4]{10,30,20,10},
                            new int[4]{1,100,3,2},
                            new int[4]{99,10,3,7}
                           };
            Console.WriteLine("Массив:");
            Print(arr);
            Console.WriteLine("Выберите порядок сортировки:" +
                "\n1-По сумме элементов строк" +
                "\n2-По максимальному элементу в строке" +
                "\n3-По минимальному элементу в строке");
            char key = Console.ReadKey().KeyChar;
            SortDelegate myDelegate;
            switch (key)
            {
                case '1':
                    myDelegate = new SumSorting().Sort;
                    break;
                case '2':
                    myDelegate = new MaxSorting().Sort;
                    break;
                case '3': 
                    myDelegate = new MinSorting().Sort;
                    break;
                default:
                    myDelegate = new BaseSorting().Sort;
                    break;
            }
            Context context = new Context(myDelegate);
            Console.WriteLine("Выберите вариант сортировки:" +
                "\n1-По возрастанию" +
                "\n2-По убыванию");
            key = Console.ReadKey().KeyChar;
            bool isReversed = false;
            if (key == '1')
                isReversed = false;
            else if (key == '2')
                isReversed = true;
            Console.WriteLine("Результат сортировки");
            context.Sort(ref arr, isReversed);
            Print(arr);
        }

        public static void Print(int[][] array)
        {
            foreach (int[] i in array)
            {
                Console.Write("[");
                foreach (int j in i)
                {
                    Console.Write("{0} ", j);
                }
                Console.Write("]\n");
            }
        }
    }
}
