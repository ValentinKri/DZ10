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
        public string filename { get; set; }
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
        public Dictionary<string, string[]> MakeDictFormuls2()
        {
            var formuls = new Dictionary<string, string[]>();
            var file = File.ReadAllLines(filename);
            foreach (var line2 in file)
            {
                string[] ans = new string[2];
                int i = 999;
                foreach (var line in file)    
                {
                    
                    string quest = "";

                    if (line[0] != '@' && line[0] != '|' && i!= 999)
                    {

                        formuls.Add(quest, ans);
                        quest = line;
                        i = 0;
                    }
                    else if (line[0] == '@'  )
                    {
                        ans[i] = line;
                        i++;
                    }
                    else if(i == 999)
                    {
                        quest = line;
                    }

                }
                
            }
            return formuls;
        }
        public void ProcessTraining(Dictionary<string,string[]> Dict)
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
        public void ProcessTraining(Dictionary<string, string> Dict)
        {
            Console.Clear();
            Console.WriteLine("Если хотите узнать, какой самый большой вопрос в данной теме и какая самая маленькая теорема Введите 1");
            var ready1 = Console.ReadLine();
            if (ready1 == "1")
            {
                Smallest(Dict);
            }
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
            void Smallest(Dictionary<string, string> Dict)
            {
                string x1 = "";
                string y2 = "";
                foreach (var D in Dict)
                {
                    y2 = D.Key;
                    break;
                }
                foreach (var D in Dict)
                {
                    if(D.Value.Length > x1.Length )
                    {
                        x1 = D.Value;
                    }
                    if (D.Key.Length > y2.Length)
                    {
                        y2 = D.Key;
                    }
                }
                Console.WriteLine($"Самая большая теорема в данной секции :{x1}");
                Console.WriteLine($"Самый мальнкий ответ :{y2}");
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
                Training test = new Training("Formuls.txt", n); 

                if (n > 4 && n < 7)
                {
                    test.n = n;
                    test.filename = "Formuls2.txt";
                }
                    
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
