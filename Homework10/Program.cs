using System;

namespace HomeWork10
{
    class Program
    {
        static string FirstCheck(string a)
        {
            if (a != "0" && a != "1" && a != "2" && a != "3")
            {
                Console.WriteLine("Ввод числа должен совершаться без пробелов и т.п.");
                Console.WriteLine("Попробуйте еще раз");
                a = Console.ReadLine();
                a = FirstCheck(a);
            }
            return a;


        }
        static void Main(string[] args)
        {
            Console.WriteLine("Доюро пожаловать в прорамму репетитор");
            Console.WriteLine("Если хотите узнать функционал программы введите цифру 0, если хотите выбрать одну из функций введите :");
            Console.WriteLine("1 - Для запуска симулятора геометрии. 2 - Для запуска проверки знаний. 3 - Для запуски зазубривания теории ");
            string a = Console.ReadLine();
            a = FirstCheck(a);
            if(a == "0")
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
            }

        }
    }
}