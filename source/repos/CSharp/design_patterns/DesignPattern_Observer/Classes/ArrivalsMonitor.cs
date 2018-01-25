namespace DesignPattern_Observer.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ArrivalsMonitor : IObserver<BaggageInfo>
    {
        private string _name;
        private List<string> _flightInfos = new List<string>();
        private IDisposable _cancellation;
        private string fmt = "{0,-20} {1,5} {2,3}";

        public ArrivalsMonitor(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("The observer must to be assigner to a name");

            _name = name;
        }

        public virtual void Subscribe(BaggageHandler provider) =>
            _cancellation = provider.Subscribe(this);

        public virtual void Usubscribe()
        {
            _cancellation.Dispose();
            _flightInfos.Clear();
        }

        public void OnCompleted() =>
            _flightInfos.Clear();

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(BaggageInfo info)
        {
            bool updated = false;

            if (info.Carousel == 0)
            {
                var flightsToRemove = new List<string>();
                string flightNo = String.Format("{0,5}", info.FlightNumber);

                for (int i = 0; i < _flightInfos.Count; i++)
                {
                    if (_flightInfos[i].Substring(21, 5).Equals(flightNo))
                    {
                        flightsToRemove.Add(_flightInfos[i]);
                        updated = true;
                    }
                }

                for (int i = 0; i < flightsToRemove.Count; i++)
                    _flightInfos.Remove(flightsToRemove[i]);

                flightsToRemove.Clear();

                ShowSortedFlights(updated);
                return;
            }

            string flightInfo = String.Format(fmt, info.From, info.FlightNumber, info.Carousel);
            if (!_flightInfos.Contains(flightInfo))
            {
                _flightInfos.Add(flightInfo);
                updated = true;
            }

            ShowSortedFlights(updated);
        }

        private void ShowSortedFlights(bool updated)
        {
            if (updated)
            {
                _flightInfos.Sort();
                Console.WriteLine("Arrivals information from {0}:", _name);

                for (int i = 0; i < _flightInfos.Count; i++)
                    Console.WriteLine(_flightInfos[i]);

                Console.WriteLine();
            }
        }
    }
}
