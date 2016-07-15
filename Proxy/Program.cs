using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            Proxy proxy = new Proxy();
            proxy.Request();

            Console.Read();
        }
    }

    class Proxy : ISubject
    {
        private Subject _subject;

        public void Request()
        {
            Console.WriteLine($"This method is being called on : {this.ToString()}");

            //create a lazy loader for the Subject
            if (_subject == null)
                _subject = new Subject();

            Console.WriteLine("  |");
            Console.Write("  ---");

            _subject.Request();
        }

        public override string ToString()
        {
            return $"Proxy";
        }
    }

    class Subject : ISubject
    {
        public void Request()
        {
            Console.WriteLine($"This method is being called on : {this.ToString()}");
        }

        public override string ToString()
        {
            return $"Subject";
        }
    }

    internal interface ISubject
    {
        void Request();
    }

    
}
