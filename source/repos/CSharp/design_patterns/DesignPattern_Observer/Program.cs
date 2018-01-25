﻿namespace DesignPattern_Observer
{
    using DesignPattern_Observer.Classes;
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            BaggageHandler provider = new BaggageHandler();

            ArrivalsMonitor observer1 = new ArrivalsMonitor("BaggageClaimMonitor 1");
            ArrivalsMonitor observer2 = new ArrivalsMonitor("SecurityExit");

            provider.BaggageStatus(712, "Detroit", 3);
            observer1.Subscribe(provider);
            provider.BaggageStatus(712, "Kalamazoo", 3);
            provider.BaggageStatus(400, "New York - Kennedy", 1);
            provider.BaggageStatus(712, "Detroit", 3);
            observer2.Subscribe(provider);
            provider.BaggageStatus(511, "San Francisco", 2);
            provider.BaggageStatus(712);
            observer2.Usubscribe();
            provider.BaggageStatus(400);
            provider.LastBaggageClaimed();

            Console.ReadKey();
        }
    }
}
