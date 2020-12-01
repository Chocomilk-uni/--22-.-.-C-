using System;

namespace LabWork
{
    class BusStationOverflowException : Exception
    {
        public BusStationOverflowException() : base("На автовокзале нет свободных мест") 
        { }
    }
}