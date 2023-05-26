using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace HomeWork10
{
    class Test
    {
        private string[] questions { get; }
        private string[] answers { get; }
        private string[] hints { get; }
        private int num { get; }

        private Random rand = new Random();
        public Test(int i)
        {

            num = i;
            questions = new string[i];
            answers = new string[i];
            hints = new string[i];

            string path;
            Console.WriteLine("Введите 1 если вы хотите использовать стандартный тест, введите два если хотите загрузить свои вопросы");
            int ans = Convert.ToInt32(Console.ReadLine());
            ans = Check(ans);
            if (ans == 1)
            {
                path = "test.txt";
            }
            else
            {
                Console.WriteLine("Введите путь к файлу");
                path = Console.ReadLine();
            }
            string[] readText = File.ReadAllLines(path);
            for (int j = 0; j < i; j++)
            {
                int l = rand.Next(0, readText.Length);
                string[] quiz = readText[l].Split(new char[] { '/' });
                quiz = checkS(quiz, readText);
                questions[j] = quiz[0];
                answers[j] = quiz[1];
                hints[j] = quiz[2];
            }
        }
        public string[] checkS(string[] quiz,string[] readText)
        {
            for (int i = 0; i < questions.Length; i++)
            {
                if (questions[i] != null && questions[i] == quiz[0])
                {
                    int l = rand.Next(0, readText.Length);
                    quiz = readText[l].Split(new char[] { '/' });
                    return quiz = checkS(quiz, readText);
                }
            }
            return quiz;
        }
        public void Start()
        {
            int ball = 0;
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("Вопрос " + (i + 1));
                Console.WriteLine(questions[i]);
                Console.WriteLine("Дайте ответ, если нужна подсказка введите Hint ");
                string ans = Console.ReadLine();
                if (ans == "Hint")
                {
                    Console.WriteLine(hints[i]);
                    Console.WriteLine("Дайте ответ");
                    ans = Console.ReadLine();
                }
                if (ans == answers[i])
                {
                    ball++;
                }
            }
            Console.WriteLine("Правильных ответов - " + ball + " из " + num);
            Console.WriteLine("Хотите сохранить: 1-да 2-нет");
            ball = Convert.ToInt32(Console.ReadLine());
            if (ball == 1)
            {
                if (!File.Exists("save.txt"))
                    File.Create("save.txt").Close();
                using (StreamWriter writer = new StreamWriter("save.txt", false))
                {
                    for (int i = 0; i < num; i++)
                    {
                        writer.WriteLine(questions[i]);
                        writer.WriteLine(answers[i]);
                    }
                }
                if (!File.Exists("savehint.txt"))
                    File.Create("savehint.txt").Close();
                using (StreamWriter hintsw = new StreamWriter("savehint.txt", false))
                {
                    for (int i = 0; i < num; i++)
                    {
                        hintsw.WriteLine(hints[i]);
                    }
                }
            }
        }
        private int Check(int i)
        {
            if (i == 1)
            {
                return 1;
            }
            else if (i == 2)
            {

                return 2;
            }
            else
            {
                int ans = Convert.ToInt32(Console.ReadLine());
                Check(ans);
            }
            return 1;
        }
    }
}
