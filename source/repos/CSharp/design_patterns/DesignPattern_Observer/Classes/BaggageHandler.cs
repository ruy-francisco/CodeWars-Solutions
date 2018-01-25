namespace DesignPattern_Observer.Classes
{
    using System;
    using System.Collections.Generic;

    public class BaggageHandler : IObservable<BaggageInfo>
    {
        private List<IObserver<BaggageInfo>> _observers;
        private List<BaggageInfo> _fligths;

        public BaggageHandler()
        {
            _observers = new List<IObserver<BaggageInfo>>();
            _fligths = new List<BaggageInfo>();
        }

        public IDisposable Subscribe(IObserver<BaggageInfo> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);

                for (int i = 0; i < _fligths.Count; i++)
                    observer.OnNext(_fligths[i]);
            }

            return new Unsubscriber<BaggageInfo>(_observers, observer);
        }

        public void BaggageStatus(int flightNo) =>
            BaggageStatus(flightNo, String.Empty, 0);

        public void BaggageStatus(int flightNo, string from, int carousel)
        {
            var info = new BaggageInfo(flightNo, from, carousel);

            if (carousel > 0 && !_fligths.Contains(info))
            {
                _fligths.Add(info);

                for (int i = 0; i < _observers.Count; i++)
                    _observers[i].OnNext(info);
            }

            if (carousel == 0)
            {
                var flightsToRemove = new List<BaggageInfo>();

                for (int i = 0; i < _fligths.Count; i++)
                {
                    if (info.FlightNumber == _fligths[i].FlightNumber)
                    {
                        flightsToRemove.Add(_fligths[i]);

                        for (int j = 0; j < _observers.Count; j++)
                            _observers[j].OnNext(info);
                    }
                }

                for (int i = 0; i < flightsToRemove.Count; i++)
                    _fligths.Remove(flightsToRemove[i]);

                flightsToRemove.Clear();
            }
        }

        public void LastBaggageClaimed()
        {
            for (int i = 0; i < _observers.Count; i++)
                _observers[i].OnCompleted();

            _observers.Clear();
        }
    }
}
