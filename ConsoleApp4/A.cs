using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class A
    {
        public static int Delenie_Posledovatelnosty(int L, int R, letter[] arr)
        {

            double schet1 = 0;
            
            foreach (var e in arr)
                Console.WriteLine(e.Frequency);
                
            for (int i = L; i <= R - 1; i++)
            {
                schet1 = schet1 + arr[i].p;
            }

            double schet2 = arr[R].p;
            int m = R;
            while (schet1 >= schet2)//разделение вероятностей на 2 группы по возрастанию
            {
                m = m - 1;
                schet1 = schet1 - arr[m].p;
                schet2 = schet2 + arr[m].p;
            }
            return m;//индекс с которого начинается вторая группа


        }


        public static void Fano(int L, int R, letter[] arr)
        {
            Console.WriteLine(L + "+" + R + '\n');

            int n;

            if (L < R)
            {

                n = Delenie_Posledovatelnosty(L, R, arr);
                // Console.WriteLine(L + "+" + R + "=" + n);
                for (int i = L; i <= R; i++)//для каждой буквы выполняется кодировка
                {
                    if (i <= n)
                    {
                        arr[i].Res += Convert.ToByte(0);
                    }
                    else
                    {
                        arr[i].Res += Convert.ToByte(1);
                    }
                }



                Fano(L, n, arr);

                Fano(n + 1, R, arr);

            }


        }

        public static void Sort(letter[] arr, int size)
        {
            for (int i = 0; i < size; i++)//сортировка вероятностей по убыванию
            {
                for (int j = 0; j < size - i - 1; j++)
                {
                    if (arr[j].p < arr[j + 1].p)
                    {
                        char temp = arr[j].Alpha;
                        arr[j].Alpha = arr[j + 1].Alpha;
                        arr[j + 1].Alpha = temp;

                        int temp1 = arr[j].Frequency;
                        arr[j].Frequency = arr[j + 1].Frequency;
                        arr[j + 1].Frequency = temp1;

                        double temp2 = arr[j].p;
                        arr[j].p = arr[j + 1].p;
                        arr[j + 1].p = temp2;

                    }
                }
            }


        }

        public static int findInArr(letter[] arr, char c, int Count)
        {

            for (int i = 0; i < Count; i++)
            {
                if (arr[i].Alpha == c)
                {
                    return i;
                }
            }
            return -1;
        }

        public static string output(letter[] arr, string str, string q)
        {
            foreach (var e in str)
            {
                foreach (var l in arr)
                {
                    if (l.Alpha == e)
                    {
                        // Console.Write(l.Res);
                        q += l.Res;
                    }
                }
            }
            return q;
        }

        public static string Decoding(string str, letter[] let)
        {
            string it = "";
            string oneTime = "";
            bool metka = true;
            foreach (char e in str)
            {
                metka = true;
                oneTime += e;
                foreach (letter a in let)
                {

                    if (oneTime == a.Res)
                    {
                        it += a.Alpha;
                        oneTime = "";

                    }
                    else
                    {
                        metka = false;
                    }
                }

            }
            return it;
        }
    }
}
