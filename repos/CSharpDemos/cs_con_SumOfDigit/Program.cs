using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_con_SumOfDigit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num, result, sum = 0, rem;

            Console.WriteLine("Enter your Number:");
            num = int.Parse(Console.ReadLine());

            num += sum;
            rem = sum%

                using System;
class HelloWorld
        {
            static void Main()
            {
                int n, sum = 0, m;
                Console.Write("Enter a number: ");
                n = int.Parse(Console.ReadLine());
                while (n > 0)
                {
                    m = n % 10;
                    sum = sum + m;
                    n = n / 10;
                    Console.WriteLine("Value Inside Loop - Sum : " + sum + ", m : " + m + ", n : " + n);
                }
                Console.Write("Total Sum : " + sum);

            }
        }
    }
    }
}
