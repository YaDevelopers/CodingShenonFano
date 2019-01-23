using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
         class Program
        {

        

            static void Main(string[] args)
            {
            string str = Console.ReadLine();
            letter[] arr = new letter[str.Distinct().Count()];
            int i = 0;
            foreach (char c in str)
            {
                int index = A.findInArr(arr, c, str.Distinct().Count());
                if (index > -1)
                {
                    arr[index].Frequency++;
                }
                else
                {
                    arr[i].Alpha = c;
                    arr[i].Frequency++;
                    
                    i++;
                }
            }

            int k = 0;

            foreach (letter r in arr)
            {
                arr[k].p = Convert.ToDouble(Convert.ToDouble(r.Frequency) / (Convert.ToDouble(str.Distinct().Count())));
           
                k++;
            }

            int size = 0;

            foreach (var a in arr)
            {
                size += a.Frequency;
               
            }

            A.Sort(arr, str.Distinct().Count());
            A.Fano(0, str.Distinct().Count() - 1, arr);
           
            Console.WriteLine(str.Distinct().Count() - 1);
            string itog = ""; 
            itog = A.output(arr,str,itog);
            string q = A.Decoding(itog, arr);
            Console.WriteLine($"закодированное сообщение {itog} \nрасшифровка {q}");
          
        }

        }
    
}
