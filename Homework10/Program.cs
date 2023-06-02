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

                Console.WriteLine("1)В модуле Симулятор геометрии у вас есть следующий функционал");
                Console.WriteLine("Exit – выход");
                Console.WriteLine("GetAll – получить все фигуры на плоскости");
                Console.WriteLine("FarthestRectangle – возвращает наиболее удалённый от центра координат прямоугольник");
                Console.WriteLine("Perimeter – периметр прямоугольника");
                Console.WriteLine("Area – площадь прямоугольника");
                Console.WriteLine("Get – вывести координаты прямоугольника");
                Console.WriteLine("Move – подвинуть прямоугольник по осям X и Y на заданные сдвиги");
                Console.WriteLine("Rotate – повернуть прямоугольник на заданный градус");
                Console.WriteLine("2)В модуле Проверка знаний");
                Console.WriteLine("Вы можете создать вариант контрольной работы из пула вопроссов заданных в текстовом файле");
                Console.WriteLine("Вы можете загрузить свой файл или использовать стандартный Пул");
                Console.WriteLine("Для того чтобы использовать свой файл нужно указать путь к файлу");
                Console.WriteLine("Сгенерированный вариант вы можете сохранить в папку, находящуюся в папке с программой");
                Console.WriteLine("В вашем файле с вопрсами они должны иметь следующий вид");
                Console.WriteLine("Вопрос/Ответ/Подсказка(Конец строки)");
                Console.WriteLine("3)В модуле Зазубривание теории");
                Console.WriteLine(" Пользователю показывается название формулы, он её вспоминает (и, допустим, записывает на черновик), ");
                Console.WriteLine("после чего нажимает кнопку (или выполняет любое другое действие) и на экране появляется правильная формула.");
                Console.WriteLine("Пользователь сравнивает её с той, что написана у него в черновике и указывает, правильно ли он её написал или нет.");
                Console.WriteLine("1 - Для запуска симулятора геометрии. 2 - Для запуска проверки знаний. 3 - Для запуски зазубривания теории ");
                a = Console.ReadLine();
                a = FirstCheck(a);
            }
            switch(a)
            {
                case "1":
                    {
                        Class3 geom = new Class3();
                        geom.Init();
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("Введите число от 1 до 8, если будете использовать свой файл с вопросами введите число не превышающее количество вопросов");
                        int i = Convert.ToInt32(Console.ReadLine());

                        Test n1 = new Test(i);
                        n1.Start();
                        break;
                    }
                case "3":
                    {
                        var tra = new Training("Filename", 1);
                        tra.GenerateTraining();
                        break;
                    }
            }
                
        }
    }
}