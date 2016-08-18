using Factory.Cars;
using Factory.Interfaces;

namespace Factory
{
    internal class AutoFactory
    {
        internal IAuto CreateInstance(string input)
        {
            IAuto result = null;
            switch (input)
            {
                case "BMW":
                    result = new BMW();
                    break;
                case "Audi":
                    result = new Audi();
                    break;
                case "Ferrari":
                    result = new Ferrari();
                    break;
            }
            return result;
        }
    }
}