using System;

namespace LabWork
{
    class BusStationAlreadyHaveException : Exception
    {
        public BusStationAlreadyHaveException() : base("На автовокзале уже есть такой автобус")
        { }
    }
}