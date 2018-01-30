using Calculator.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicCalculator cal = new BasicCalculator();
            Console.WriteLine(cal.Add(10, 5));
            Console.WriteLine(cal.Sub(10, 5));
            Console.WriteLine(cal.Mul(10, 5));
            Console.WriteLine(cal.Div(10, 5));


            Console.ReadLine();
        }
    }
}
