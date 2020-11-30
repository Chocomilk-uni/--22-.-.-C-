using System;

namespace LabWork
{
    class BusStationPlaceNotFoundException : Exception
    {
        public BusStationPlaceNotFoundException(int i) : base("Автобус по месту " + i +  " не найден")
        { }
    }
}
