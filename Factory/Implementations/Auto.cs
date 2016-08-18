using Factory.Interfaces;
using System;

namespace Factory.Cars
{
    internal abstract class Auto : IAuto
    {
        public string Name { get; set; }
        public void TurnOff()
        {
            Console.WriteLine($"{Name} has been turned off.");
        }

        public void TurnOn()
        {
            Console.WriteLine($"{Name} has been turned on.");
        }
    }
}