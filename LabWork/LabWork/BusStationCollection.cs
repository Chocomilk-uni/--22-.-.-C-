using System.Collections.Generic;
using System.Linq;

namespace LabWork
{
    class BusStationCollection
    {
        //Словарь (хранилище) с автовокзалами
        readonly Dictionary<string, BusStation<PublicTransport>> busStationStages;

        //Возвращение списка названий автовокзалов
        public List<string> Keys => busStationStages.Keys.ToList();

        private readonly int pictureWidth;
        private readonly int pictureHeight;

        public BusStationCollection(int pictureWidth, int pictureHeight)
        {
            busStationStages = new Dictionary<string, BusStation<PublicTransport>>();
            this.pictureWidth = pictureWidth;
            this.pictureHeight = pictureHeight;
        }

        //Добавление записи в словарь
        public void AddBusStation(string name)
        {
            if (busStationStages.ContainsKey(name))
            {
                return;
            }

            busStationStages.Add(name, new BusStation<PublicTransport>(pictureWidth, pictureHeight));

        }

        //Удаление записи из словаря
        public void DelBusStation(string name)
        {
            if (busStationStages.ContainsKey(name))
            {
                busStationStages.Remove(name);
            }
        }

        //Индексатор
        public BusStation<PublicTransport> this[string name]
        {
            get
            {
                if (busStationStages.ContainsKey(name))
                {
                    return busStationStages[name];
                }
                return null;
            }
        }

    }
}