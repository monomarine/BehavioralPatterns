using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDemo
{
    internal class Weather : IWeatherSubject
    {
        private List<IWeatherObserver> _observers = new List<IWeatherObserver>();   
        private double _temperature;
        public void AddObserver(IWeatherObserver observer)
        {
            _observers.Add(observer);
        }

        public void NotifyObservers()
        {
            foreach (IWeatherObserver observer in _observers) 
            {
                observer.Update(_temperature);
            }
        }

        public void RemoveObserver(IWeatherObserver observer)
        {
            _observers?.Remove(observer);
        }

        public void GenerateTem()
        {
            Random rnd = new Random();
            _temperature = rnd.NextDouble() + rnd.Next(-40, 40);
            NotifyObservers();
        }

    }
}
