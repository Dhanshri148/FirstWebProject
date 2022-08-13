using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_con_FibonacciSeries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1=0, num2, num3;

            Console.WriteLine("Enter number to display fibonacci series");
            num2 = Convert.ToInt32(Console.ReadLine());

            for(int i = num1; i<= num2; i++)
            {
                num1 += num1;
                Console.WriteLine(i);
            }
           
        }
    }
}
