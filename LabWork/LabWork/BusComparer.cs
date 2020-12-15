using System.Collections.Generic;

namespace LabWork
{
    class BusComparer : IComparer<PublicTransport>
    {
        public int Compare(PublicTransport x, PublicTransport y)
        {
            if (x.GetType().Name != y.GetType().Name)
            {
                return x.GetType().Name.CompareTo(y.GetType().Name);
            }
            if (x is Bus && y is Bus)
            {
                return ComparerBus(x as Bus, y as Bus);
            }
            if (x is DoubleBus && y is DoubleBus)
            {
                return ComparerDoubleBus(x as DoubleBus, y as DoubleBus);
            }
            return 0;
        }

        private int ComparerBus(Bus x, Bus y)
        {
            if (x.Weight != y.Weight)
            {
                return x.Weight.CompareTo(y.Weight);
            }
            if (x.MainColor != y.MainColor)
            {
                return x.MainColor.Name.CompareTo(y.MainColor.Name);
            }
            if (x.AverageSpeed != y.AverageSpeed)
            {
                return x.AverageSpeed.CompareTo(y.AverageSpeed);
            }
            return 0;
        }

        private int ComparerDoubleBus(DoubleBus x, DoubleBus y)
        {
            var result = ComparerBus(x, y);
            if (result != 0)
            {
                return result;
            }
            if (x.AdditionalColor != y.AdditionalColor)
            {
                return x.AdditionalColor.Name.CompareTo(y.AdditionalColor.Name);
            }
            if (x.SecondFloor != y.SecondFloor)
            {
                return x.SecondFloor.CompareTo(y.SecondFloor);
            }
            if (x.AdditionalDoor != y.AdditionalDoor)
            {
                return x.AdditionalDoor.CompareTo(y.AdditionalDoor);
            }
            if (x.FrontPlatform != y.FrontPlatform)
            {
                return x.FrontPlatform.CompareTo(y.FrontPlatform);
            }
            return 0;
        }
    }
}