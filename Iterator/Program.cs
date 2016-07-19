using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter the number of values to be generated: ");
            int values = Convert.ToInt32(Console.ReadLine());
            var fibonacci = new FibonacciSequence(values);
            
            foreach(var value in fibonacci)
                Console.WriteLine(value);

            Console.Read();
        }
    }
}
