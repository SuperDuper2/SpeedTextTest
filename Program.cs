using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeedTextTest
{
    class my
    {
        public string name;
        public int simm;
        public decimal sims;
    }
    class privkdchd : my
    {
        protected static int sec;
        private static int tm = 1;
        protected static string Name;
        protected static List<my> vse = new List<my>();
        protected static void nachalo()
        {
            Console.Clear();
            Console.WriteLine("Результаты: ");
            vse.Sort((x, y) =>
            {
                int ret = String.Compare($"{y.simm}", $"{x.simm}");
                return ret != 0 ? ret :
                x.simm.CompareTo(y.simm);
            });
            foreach (my a in vse)
            {
                Console.WriteLine($"Имя: {a.name}\nРезультат в минуту: {a.simm}\nРезультат в секунду: {a.sims}\n");
                ser();
            }
            Console.WriteLine($"\nЧтобы добавить новый результат нажмите \"+\"");
        }
        protected static void perehod()
        {
            Console.Clear();
            Console.WriteLine("Введите имя\n");
            Name = Console.ReadLine();
            Console.Clear();
            pechatanie();
            tm = 1;
        }
        protected static void pechatanie()
        {

            string txt = "Всякий игрок клуба, получающий от клуба вознаграждение в какой-бы то ни было форме или денежное возмещение, превышающее его личные расходы или средства, в связи с выходом на ту или иную игру, автоматически отстраняется в соревнованиях на Кубок, в любых соревнованиях под эгидой ФА и в международных турнирах. Клуб, нанявший такого игрока, автоматически исключается из Ассоциации.\r\n";
            char[] text = txt.ToCharArray();
            int i = 0;
            int pos = 0;
            int sop = 0;
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                Console.WriteLine(txt);
                Console.WriteLine("\nЧтобы начать нажмите Enter");
                key = Console.ReadKey();
            } while (key.Key != ConsoleKey.Enter);
            Console.Clear();
            Console.WriteLine(txt);
            Thread po = new Thread(potok);
            po.Start();
            do
            {
                Console.SetCursorPosition(sop, pos);
                key = Console.ReadKey(true);
                if (key.KeyChar == text[i])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(sop, pos);
                    Console.WriteLine(text[i]);
                    i++;
                    sop++;
                    if (sop == 120)
                    {
                        sop = 0;
                        pos++;
                    }
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(sop, pos);
                    Console.WriteLine(text[i]);
                    Console.ResetColor();
                }
            } while (tm != 0 && i != text.Length);
            tm = 0;
            my h = new my();
            h.name = Name;
            h.simm = i * 60 / sec;
            h.sims = (decimal)i / sec;
            vse.Add(h);
        }
        protected static void potok()
        {
            sec = -1;
            int i = 10;

            while (i != 0)
            {
                if (tm != 0)
                {
                    Console.SetCursorPosition(5, 10);
                    if (i == 60)
                    {
                        Console.WriteLine("1:00");
                    }
                    if (i < 60)
                    {
                        Console.WriteLine($"0:{i}");
                    }
                    i--;
                    sec++;
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(5, 10);
                    Console.WriteLine(" ");
                }
            }
            tm = 0;
            Console.SetCursorPosition(5, 10);
            Console.WriteLine("0:0");
            Thread.Sleep(400);
            Console.SetCursorPosition(5, 10);
            Console.WriteLine("Чтобы продолжить - нажмите любую клавишу...");
        }
        static void ser()
        {
            File.WriteAllText("C:\\Users\\User\\Desktop\\1.json", JsonConvert.SerializeObject(vse));
        }
    }

    class Program : privkdchd
    {
        static void Main()
        {
            ConsoleKeyInfo k;
            while (true)
            {
                nachalo();
                k = Console.ReadKey();
                if (k.Key == ConsoleKey.Add)
                    perehod();
            }
        }
    }
}