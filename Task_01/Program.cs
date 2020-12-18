/* В библиотеке классов Cinderella определите абстрактный класс Something.  
 * От класса Something  унаследуйте два класса: Lentil, Ashes. В Классе Lentil 
 * определите поле Weight, принимающее для каждого нового экземпляра класса 
 * случайное вещественное значение в интервале [0, 2]. В классе Ashes определите 
 * поле Volume, принимающее для каждого нового экземпляра класса случайное 
 * вещественное значение в интервале [0, 1]​.
 * 
 * В основной программе создайте массив N (N ввести с клавиатуры) экземпляров 
 * классов Lentil и Ashes (принадлежность очередного элемента массива к первому 
 * или второму классу определите при помощи датчика случайных чисел). 
 * Выведите массив на экран. Из элементов массива сформируйте и выведите на экран 
 * два списка экземпляров Lentil  и Ashes. ​
 * 
 * Double выводить с точностьюдо двух знаков после запятой!
 * 
 * 
 * Формат входных данных : 
 * -------test_1-------
 * -1
 * -------test_2-------
 * 4
 * 0,57 
 * 1,42 
 * 0,91 
 * 1,12
 * --------------------
 * 
 * Формат выходных данных : 
 * -------test_1-------
 * Incorrect input!
 * -------test_2-------
 * 0,57 1,42 0,91 1,12
 * 0,57 0,91
 * 1,42 1,12
 * --------------------
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_01
{
    class Program
    {
        private static readonly Random rnd = new Random();
        static void Main(string[] args)
        {
            int n;
            //добавьте проверку на некорректную длинну массива
            if (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.WriteLine("Incorrect input!");
                return;
            }
    
            Something[] array = CreateArray(n);
            PrintArray(array);
            PrintSeparately(array);
        }

        static Something[] CreateArray(int n)
        {
            Something[] array = new Something[n];

            /*Заполните массив array n элементами (Lentil/Ashes) 
             *вводом чисел с клавиатуры (array[i] = new Lentil(1.06);)
             *В случае некорретного значения вывести "Incorrect input!" и продолжить ввод,
             * пропустив этот элемент.
             * ...*/

            double number;
            for (int elem = 0; elem < n; ++elem)
            {
                if (rnd.Next() % 2 == 0)
                {
                    if (!double.TryParse(Console.ReadLine(), out number) ||
                        number < 0 || number > 2)
                        Console.WriteLine("Incorrect input!");
                    else { array[elem] = new Lentil(number); }
                }
                else
                {
                    if (!double.TryParse(Console.ReadLine(), out number) ||
                        number < 0 || number > 1)
                        Console.WriteLine("Incorrect input!");
                    else { array[elem] = new Ashes(number); }
                }
            }

            return array;
        }

        static void PrintArray(Something[] array)
        {
            /*Выведите массив на экран в одну строку, 
             * разделяя элементы пробелами. Не забудьте переопредлить ToString().
             * ...*/
            foreach (Something elem in array)
                Console.Write(elem + " ");
            Console.Write("\n");
        }

        static void PrintSeparately(Something[] array)
        {
            /*выведите в одну строку элементы типа Lentil, 
             * затем с новой строки элементы типа Ashes.
             * Также через пробел!*/
            string lentils = "";
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] is Lentil)
                {
                    lentils += $"{array[i]} ";
                }
            }
            Console.WriteLine(lentils);
            //вывод элементов Ashes реализуйте самостоятельно
            //...
            string ashes = "";
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] is Ashes)
                {
                    ashes += $"{array[i]} ";
                }
            }
            Console.WriteLine(ashes);
            /*Реализация для примера, которая забанена в рамках данного дз.
             *var lentilsCollection = array.Where(x => x is Lentil);
             *Console.WriteLine(String.Join(" ", lentilsCollection));*/
        }
    }

    abstract class Something
    {
    }

    class Lentil : Something
    {
        private double weight;

        public Lentil(double weight)
        {
            Weight = weight;
        }

        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;
            }
        }

        public override string ToString() => weight.ToString();
    }

    //реализуйте класс Ashes по аналогии с Lentil, используя auto-свойства!
    class Ashes : Something
    {
        private double volume;

        public Ashes(double number)
        {
            Volume = number;
        }

        public double Volume
        {
            get
            {
                return volume;
            }
            set
            {
                volume = value;
            }
        }

        public override string ToString() => volume.ToString();
    }
}
