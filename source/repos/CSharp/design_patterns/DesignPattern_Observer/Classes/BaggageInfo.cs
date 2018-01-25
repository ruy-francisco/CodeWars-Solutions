namespace DesignPattern_Observer.Classes
{
    public class BaggageInfo
    {
        private int _flightNo;
        private string _origin;
        private int _location;

        internal BaggageInfo(int flight, string from, int carousel)
        {
            _flightNo = flight;
            _origin = from;
            _location = carousel;
        }

        public int FlightNumber
        {
            get => _flightNo;
        }

        public string From
        {
            get => _origin;
        }

        public int Carousel
        {
            get => _location;
        }
    }
}
