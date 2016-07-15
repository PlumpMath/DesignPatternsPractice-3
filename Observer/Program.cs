using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            var publisher = new Publisher();
            var observer1 = new Observer(publisher, 1);
            var observer2 = new Observer(publisher, 2);
            var observer3 = new Observer(publisher, 3);
                        
            int clientNumber = rand.Next(2000);
            int difference = clientNumber;
            while (true)
            {
                publisher.ProcessClient(clientNumber);
                clientNumber++;

                if (clientNumber - difference == 4)
                    observer1.Dispose();
            }
        }
    }

    class Payload
    {
        public int Client { get; set; }
    }

    class Observer : IObserver<Payload>
    {
        private IDisposable _disposer;
        private int _screenNumber;

        public Observer(IObservable<Payload> publisher, int screenNumber )
        {
            if (publisher != null)
            {
                _disposer = publisher.Subscribe(this);
                _screenNumber = screenNumber;
            }
        }

        public void OnNext(Payload value)
        {
            Console.WriteLine($"Now serving : {value.Client.ToString()}");
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }
        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _disposer.Dispose();
        }
        
    }

    class Disposer<T> : IDisposable
    {
        private IObserver<T> _observer;
        private List<IObserver<T>> _observerList;

        public Disposer(List<IObserver<T>> observerList, IObserver<T> observer)
        {
            this._observer = observer;
            this._observerList = observerList;
        }

        public void Dispose()
        {
            Console.WriteLine($"Removing observer : {_observer.ToString()}");

            if (_observerList.Contains(_observer))
                _observerList.Remove(_observer);
        }
    }

    class Publisher : IObservable<Payload>
    {
        private List<IObserver<Payload>> _observerList;

        public Publisher()
        {
            _observerList = new List<IObserver<Payload>>();
        }

        public IDisposable Subscribe(IObserver<Payload> observer)
        {
            // Check whether observer is already registered. If not, add it
            if (!_observerList.Contains(observer))
            {
                _observerList.Add(observer);
            }
            return new Disposer<Payload>(_observerList, observer);
        }

        

        public void ProcessClient(int client)
        {
            foreach (var observer in _observerList)
                observer.OnNext(new Payload() { Client = client});

            Thread.Sleep(1000);
            Console.WriteLine($"Processing client : {client} ...");
            Thread.Sleep(2000);
            Console.WriteLine("Done! Next Client!");
            Thread.Sleep(1000);
        }
    }
}
