using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_con_PrimeNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num, i, num1 = 0, flag = 0;
            Console.Write("Enter the Number:");
            num = int.Parse(Console.ReadLine());
            num1 = num / 2;
            for(i = 2; i <= num1 ;i++)
            {
                if(num % 2 == 0)
                {
                    Console.WriteLine("Number is not Prime");
                    flag = 1;
                    break;
                }
            }
            if (flag == 0)
            {
                Console.WriteLine("Number is Prime");
            }
        }
    }
}
