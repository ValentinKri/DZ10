using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace HomeWork10
{
    public class Formule
    {
        public string name { get; set; }
        public string answer { get; set; }
        public Formule(string Name, string Answer)
        {
            name = Name;
            answer = Answer;
        }
    }
    public class Training
    {
        public int n { get; set; }
        public int LocalStat { get; set; }
        public int CountTry = 0;

        public Training( int N)
        {
            n = N;
        }
        public Dictionary<string, string> MakeDictFormuls(string filename)
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
        public Dictionary<string, string[]> MakeDictFormuls2(string filename)
        {
            var formuls = new Dictionary<string, string[]>();
            var file = File.ReadAllLines(filename);
            bool j = true;
            string[] ans = new string[3];
            string quest = "";
            int i = 0;
            foreach (var line in file)
            {
                if (line[0] != '@' && line[0] != '|' && !j)
                {
                    string[] nebie = { ans[0], ans[1], ans[2] };
                    formuls.Add(quest, nebie);
                    quest = line;
                    i = 0;
                }
                else if (line[0] == '@' && i != 3)
                {

                    ans[i] = line;
                    i++;
                }
                else if (j && i == 3)
                {
                    string[] nebie = { ans[0], ans[1], ans[2] };
                    formuls.Add(quest, nebie);
                    i = 0;
                    j = false;
                    quest = line;
                }
                else if (j)
                {
                    quest = line;
                }

            }
            return formuls;
        }
        public void ProcessTraining(Dictionary<string,string[]> Dict)
        {
            int i = 0;
            Console.Clear();
            int plug = 0;
            foreach (var x in Dict)
            {
                if (n == 6 && plug < 2)
                {
                    plug ++;
                }
                else if (n == 5 && plug <2) 
                {
                    
                    bool flag = false;
                    while (flag == false)
                    {
                        Console.Clear();

                        Console.WriteLine($"Вопрос : {x.Key}");
                        Console.WriteLine();
                        int j = 0;
                        CountTry++;
                        foreach (string val in x.Value)
                        {

                            string ready = "asd";
                            if (j == 0)
                            {
                                Console.WriteLine($"Напишите условиe");
                                Console.WriteLine();
                                Console.WriteLine("Нажмите 'enter' , если готовы проверить :");
                                ready = Console.ReadLine();

                            }
                            else if (j == 1)
                            {

                                Console.WriteLine($" Напишите доказательствo");
                                Console.WriteLine();
                                Console.WriteLine("Нажмите 'enter' , если готовы проверить :");
                                ready = Console.ReadLine();
                            }
                            else if(j == 2)
                            {
                                Console.WriteLine($"Напишите заключенияe");
                                Console.WriteLine();
                                Console.WriteLine("Нажмите 'enter' , если готовы проверить :");
                                ready = Console.ReadLine();
                            }
                            if (ready == "")
                            {
                                Console.WriteLine(val);
                                Console.WriteLine();

                                Console.WriteLine();
                                Console.WriteLine("Ваш ответ сходится? (напишите '+' если сходится,'-' в противном случае)");
                                //Tof - True or False
                                var ToF = Console.ReadLine();
                                if (ToF == "-")
                                {
                                    flag = false;
                                    j = 0;
                                    break;
                                }
                                else if(ToF == "+" && j != 2)
                                {
                                    j++;
                                }
                                else if(ToF == "+" && j == 2)
                                {
                                    flag = true;
                                }
                            }
                        }
                        
                    }
                    plug++;
                }
                else if (n == 6)
                {
                    bool flag = false;
                    while (flag == false)
                    {
                        Console.Clear();
                        Console.WriteLine($"Вопрос : {x.Key}");
                        Console.WriteLine();
                        int j = 0;
                        CountTry++;
                        foreach (string val in x.Value)
                        {
                            string ready = "asd";
                            if (j == 0)
                            {
                                Console.WriteLine($"Напишите условиe");
                                Console.WriteLine();
                                Console.WriteLine("Нажмите 'enter' , если готовы проверить :");
                                ready = Console.ReadLine();

                            }
                            else if (j == 1)
                            {
                                Console.WriteLine($"Напишите заключенияe");
                                Console.WriteLine();
                                Console.WriteLine("Нажмите 'enter' , если готовы проверить :");
                                ready = Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine($" Напишите доказательствo");
                                Console.WriteLine();
                                Console.WriteLine("Нажмите 'enter' , если готовы проверить :");
                                ready = Console.ReadLine();
                            }
                            if (ready == "")
                            {
                                Console.WriteLine(val);
                                Console.WriteLine();

                                Console.WriteLine();
                                Console.WriteLine("Ваш ответ сходится? (напишите '+' если сходится,'-' в противном случае)");
                                //Tof - True or False
                                var ToF = Console.ReadLine();
                                if (ToF == "-")
                                {
                                    flag = false;
                                    j = 0;
                                    break;
                                }
                                else if (ToF == "+" && j != 2)
                                {
                                    j++;
                                }
                                else if (ToF == "+" && j == 2)
                                {
                                    flag = true;
                                }
                            }

                        }

                    }

                    plug++;
                }
            }
            if(n == 5)
            {
                LocalStat = 200 / CountTry;
            }
            else 
            {
                LocalStat = 300 / CountTry;
            }
            Console.Clear();
            Console.WriteLine($"Ваша статистика правильных ответов : {LocalStat}%");
            Console.WriteLine();
            Console.WriteLine("Нажмите 'Enter'");
            Console.ReadLine();


        
        }
        public void ProcessTraining(Dictionary<string, string> Dict)
        {
            Console.Clear();
            var i = 0;
            foreach (var x in Dict)
            {
                i++;
                if ((i <= n * 10) && (i > n * 10 - 10))
                {

                    bool flag = false;
                    while (flag == false)
                    {


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
                Console.WriteLine("Если хотите подучить теоремы");
                Console.WriteLine("5. теоремы о перпендекулярах");
                Console.WriteLine("6. теоремы о признаках равенства триугольника");
                var val = Console.ReadLine();
                int n;
                n = Convert.ToInt32(val);
                Training test = new Training( n); 

                if (n > 4 && n < 7)
                {
                    test.n = n;
                    test.ProcessTraining(test.MakeDictFormuls2("Formuls2.txt"));
                }
                else if(n > 0 && n < 5)
                {
                    test.ProcessTraining(test.MakeDictFormuls("Formuls.txt"));
                }
                
                Console.Clear();
                Console.WriteLine("Хотите еще потренироваться? (напишите '+' если хотите,'-' в противном случае)");
                var aa = Console.ReadLine();
                if (aa == "+")
                {
                    ToF = true;
                }
                else ToF = false;
                Console.WriteLine("Хотите узнать среди всех элементов в банке формулу с наиболее короткой записью и теорему с самым длинным доказательством - введите 1");
                var ready = Console.ReadLine();
                if (ready == "1")
                {
                    Smallest(MakeDictFormuls("Formuls.txt"), MakeDictFormuls2("Formuls2.txt"));
                }
            }
            void Smallest(Dictionary<string, string> Dict, Dictionary<string, string[]> Dict2)
            {
                string x2 = "";
                string y2 = "";
                foreach (var D in Dict)
                {
                    y2 = D.Key;
                    break;
                }
                foreach (var D in Dict)
                {
                    if (D.Key.Length > y2.Length)
                    {
                        y2 = D.Key;
                    }
                }
                foreach(var d2 in Dict2)
                {
                    if(d2.Value[1].Length > x2.Length)
                    {
                        x2 = d2.Value[1];
                    }
                }
                Console.WriteLine($"Самая маленькая формула :{y2}");
                Console.WriteLine($"Самое мальнкое доказательство :{x2}");
                Console.WriteLine("Нажмите Enter");
                Console.ReadLine();

            }
        }
    }
}/*
  * Код не очень хороший, его невозможно изменить, он расчитан под конкретный текстовый файл 
  * с формулами заданного формата, по сути, чтобы сделать возможным вывод теорем мне пришлось
  * второй раз писать программу, писать или перегружать функции, в итоге 
  * они лишь отдаленно напоминают то что было в оригинале.
  * */

