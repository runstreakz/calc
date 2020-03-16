using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите операцию(+,-,*)");
            Sum S = new Sum();
            Raznost R = new Raznost();
            Umnozh U = new Umnozh();
            string selection = Console.ReadLine();


            if (selection == "+")
            {
                Console.WriteLine("Введите первое число");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите второе число");
                int b = Convert.ToInt32(Console.ReadLine());
                S.sum(a, b);
                Console.WriteLine("Выберите операцию(+,-,*)");
            }


            else if (selection == "-")
            {
                Console.WriteLine("Введите первое число");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите второе число");
                int b = Convert.ToInt32(Console.ReadLine());
                R.raz(a, b);
                Console.WriteLine("Выберите операцию(+,-,*)");

            }

            else if (selection == "*")
            {
                Console.WriteLine("Введите первое число");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите второе число");
                int b = Convert.ToInt32(Console.ReadLine());
                U.proizv(a, b);
                Console.WriteLine("Выберите операцию(+,-,*)");
            }
        }







        public class Rasschet
        {
            public int raznica = 0;
            public string s;
            public string s2;
            public int rezult;

            public string rasschet(int a, int b) //выровнять числа по правому краю
            {
                int raznica = 0;
                s = a.ToString();
                s2 = b.ToString();
                if (a.ToString().Length > b.ToString().Length)
                {
                    raznica = a.ToString().Length - b.ToString().Length;
                    s2 = new string(' ', raznica) + s2;
                    return s2;
                }
                else
                {
                    raznica = b.ToString().Length - a.ToString().Length;
                    s = new string(' ', raznica) + s;
                    return s;
                }




            }

        }

        public class Sum : Rasschet  //найти сумму
        {
            public void sum(int a, int b)
            {
                rezult = a + b;
                if (a.ToString().Length > b.ToString().Length)
                {
                    s2 = rasschet(a, b);
                }
                else { s = rasschet(a, b); }
                Console.WriteLine(" " + s + "\r\n+\r\n" + " " + s2 + "\r\n" + "__________\r\n" + " " + rezult);
            }
        }
        public class Raznost : Rasschet //найти разность
        {
            public void raz(int a, int b)
            {
                rezult = a - b;
                if (a.ToString().Length > b.ToString().Length)
                {
                    s2 = rasschet(a, b);
                }
                else { s = rasschet(a, b); }
                Console.WriteLine(" " + s + "\r\n-\r\n" + " " + s2 + "\r\n" + "__________\r\n" + " " + rezult);
            }
        }
        public class Umnozh : Rasschet
        {

            string mnozhitel;
            double proizvedenie;
            string probel_konec = "";
            string probel_nachalo;
            string result;
            int length;
            public string umnozhenie(int a, int b) //поиск и вывод промежуточных значений
            {
                s = a.ToString();
                s2 = b.ToString();
                proizvedenie = a * b;
                length = (proizvedenie.ToString()).Length;

                for (int i = s2.Length - 1; i >= 0; i--)
                {
                    mnozhitel = (a * char.GetNumericValue(s2[i])).ToString() + probel_konec;
                    probel_nachalo = new string(' ', length - mnozhitel.Length);
                    result += probel_nachalo + mnozhitel + "\r\n+\r\n";
                    probel_konec += " ";
                }
                result = result.Substring(0, result.Length - 1);
                return result;


            }
            public void proizv(int a, int b) // вывод всего результата умножения
            {
                raznica = (a * b).ToString().Length;

                int proizv = a * b;
                string rez = umnozhenie(a, b);
                s2 = new string(' ', raznica - s2.Length) + s2;
                s = new string(' ', raznica - s.Length) + s;
                Console.WriteLine(s + "\r\n" + "*" + "\r\n" + s2 + "\r\n__________\r\n" + rez + "__________\r\n" + proizv);

            }
        }

        public class Delenie 
        {
            public static void Div(int a, int b)
            {
                string delimoe = a.ToString();
                string c;
                int delitel = b;
                int chastnoe = a / b;
                int chislo;

                string ostatok = "";
                string new_delimoe = "";

                for (int i = 0; i < (chastnoe.ToString()).Length; i++) //проходимся по каждой цифре частного
                {
                    c = (chastnoe.ToString()[i]).ToString();
                    chislo = delitel * Convert.ToInt32(c);//берем цифру частного и умножаем на делитель
                    Console.WriteLine(chislo + "\r\n");
                    int n = (chislo.ToString()).Length - ostatok.Length;
                    for (int j = 0; j < n; j++)
                    {
                        new_delimoe += (delimoe[j]).ToString(); //берем необходимое кол-во цифр из делимого для вычитания chislo
                    }
                    ostatok = (Convert.ToInt32(new_delimoe) - chislo).ToString();  //находим остаток
                    Console.WriteLine(new_delimoe + "\r\n");
                    new_delimoe = "";
                    for (int k = ((chislo.ToString()).Length + 1); k <= delimoe.Length; k++)
                    {
                        new_delimoe += (delimoe[k]).ToString();  //убираем цифры в начале делимого
                    }
                    delimoe = new_delimoe;
                    new_delimoe = ostatok;
                }




            }
        }
    }
}
