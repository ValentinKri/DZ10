using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace HomeWork10
{
    public class Formule
    {
        public string name { get; }
        public string answer { get; }
        public Formule(string Name, string Answer)
        {
            name = Name;
            answer = Answer;
        }
    }
    public class Training
    {
        public string filename { get; }
        public int n { get; set; }
        public int LocalStat { get; set; }
        public int CountTry = 0;

        public Training(string Filename, int N)
        {
            filename = Filename;
            n = N;
        }
        public Dictionary<string, string> MakeDictFormuls()
        {
            var formuls = new Dictionary<string, string>();
            var file = File.ReadAllLines(filename);
            foreach (var line in file)
            {
                for (var i = 0; i < line.Length - 1; i++)
                {
                    if (line[i] == '|')
                    {
                        var formule = new Formule(line.Substring(i + 1), line.Substring(0, i - 1));
                        formuls.Add(formule.name, formule.answer);
                    }
                }
            }
            return formuls;
        }
        public void ProcessTraining(Dictionary<string, string> Dict)
        {
            var i = 0;
            foreach (var x in Dict)
            {
                i++;
                if ((i <= n * 10) && (i > n * 10 - 10))
                {
                    bool flag = false;
                    while (flag == false)
                    {
                        Console.Clear();
                        Console.WriteLine($"Вопрос : {x.Key}");
                        Console.WriteLine();
                        Console.WriteLine("Нажмите 'enter' , если готовы проверить :");
                        var ready = Console.ReadLine();
                        CountTry++;
                        if (ready == "")
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Ответ : {x.Value}");
                            Console.WriteLine();
                            Console.WriteLine("Ваш ответ сходится? (напишите '+' если сходится,'-' в противном случае)");
                            //Tof - True or False
                            var ToF = Console.ReadLine();
                            if (ToF == "-") flag = false;
                            if (ToF == "+") flag = true;
                        }
                    }
                }
                if (i > n * 10)
                {
                    LocalStat = 1000 / CountTry;
                    Console.Clear();
                    Console.WriteLine($"Ваша статистика правильных ответов : {LocalStat}%");
                    Console.WriteLine();
                    Console.WriteLine("Нажмите 'Enter'");
                    var qw = Console.ReadLine();
                    if (qw == "") break;
                }
            }
        }
        public void GenerateTraining()
        {
            bool ToF = true;
            while (ToF == true)
            {
                Console.Clear();
                Console.WriteLine("Приветствую в модуле зазубривания теории, выбери номер темы , которую хочешь подучить:");
                Console.WriteLine();
                Console.WriteLine("1. Тригонометрия");
                Console.WriteLine("2. Стереометрия");
                Console.WriteLine("3. Планиметрия");
                Console.WriteLine("4. Формулы сокращённого умножения");
                var val = Console.ReadLine();
                int n;
                n = Convert.ToInt32(val);
                var test = new Training("Formuls.txt", n);
                test.ProcessTraining(test.MakeDictFormuls());
                Console.Clear();
                Console.WriteLine("Хотите еще потренироваться? (напишите '+' если хотите,'-' в противном случае)");
                var aa = Console.ReadLine();
                if (aa == "+")
                {
                    ToF = true;
                }
                else ToF = false;
            }
        }
    }
}
