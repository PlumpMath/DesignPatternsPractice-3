using Factory.Interfaces;
using System;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter car name: ");
            var input = Console.ReadLine();

            AutoFactory factory = new AutoFactory();
            IAuto car = factory.CreateInstance(input);

            car.TurnOn();
            car.TurnOff();
        }
    }
}
