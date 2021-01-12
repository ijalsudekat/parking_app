using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherStation weatherStation = new WeatherStation();

            NewsGanecy agency1 = new NewsGanecy("Alpha agency");
            weatherStation.Attach(agency1);

            NewsGanecy agency2 = new NewsGanecy("BETA agency");
            weatherStation.Attach(agency2);

            weatherStation.Temperature = 31.2F;
            weatherStation.Temperature = 21.2F;
            weatherStation.Temperature = 81.2F;
            weatherStation.Temperature = 11.2F;

            Console.ReadLine();
        }
    }

    interface ISubject
    {
        void Attach(IObserver observer);
        void Notify();
    }

    class NewsGanecy : IObserver
    {
        public string AgencyName { get; set; }

        public NewsGanecy(String name)
        {
            AgencyName = name;

        }
        public void Update(ISubject subject)
        {
            WeatherStation weatherStation = subject as WeatherStation;
            if (weatherStation != null)
            {
                Console.WriteLine(String.Format("{0} reporting tempearture {1} degre celcius ", AgencyName, weatherStation.Temperature));

            }
        }
    }

    class WeatherStation : ISubject
    {
        private List<IObserver> _observer;

        public WeatherStation()
        {
            _observer = new List<IObserver>();
        }

        private float temperature;

        public float Temperature
        {
            get { return temperature; }
            set { temperature = value; Notify(); }
        }

        public void Attach(IObserver observer)
        {
            _observer.Add(observer);
        }

        public void Notify()
        {
            _observer.ForEach(o =>
            {
                o.Update(this);
            });
        }
    }

    interface IObserver
    {
        void Update(ISubject subject);

    }

}
