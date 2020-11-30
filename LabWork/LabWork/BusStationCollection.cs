using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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

        //Разделитель для записи информации по объекту в файл
        protected readonly char separator = ':';

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

        //Метод записи информации в файл
        private void WriteToFile(string text, FileStream stream)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(text);
            stream.Write(info, 0, info.Length);
        }

        //Сохранение информации по автобусам на автовокзалах в файл
        public void SaveData(string filename)
        {
            using (StreamWriter sw = new StreamWriter(filename, false, System.Text.Encoding.Default))
            {
                sw.WriteLine("BusStationCollection");
                foreach (var level in busStationStages)
                {
                    sw.WriteLine("BusStation" + separator + level.Key);
                    ITransport bus;
                    for (int i = 0; (bus = level.Value.GetNext(i)) != null; i++)
                    {
                        if (bus.GetType().Name == "Bus")
                        {
                            sw.Write("Bus" + separator);
                        }
                        else if (bus.GetType().Name == "DoubleBus")
                        {
                            sw.Write("DoubleBus" + separator);
                        }
                        sw.WriteLine(bus);
                    }
                }
            }
        }

        //Загрузка информации по автобусам на автовокзалах из файла
        public void LoadData(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException();
            }

            using (StreamReader sr = new StreamReader(filename, System.Text.Encoding.Default))
            {
                if (sr.ReadLine().Contains("BusStationCollection"))
                {
                    busStationStages.Clear();
                }
                else
                {
                    throw new FileLoadException("Неверный формат файла");
                }

                Bus bus = null;
                string key = string.Empty;
                string line;

                for (int i = 0; (line = sr.ReadLine()) != null; i++)
                {
                    if (line.Contains("BusStation"))
                    {
                        key = line.Split(separator)[1];
                        busStationStages.Add(key, new BusStation<PublicTransport>(pictureWidth, pictureHeight));
                    }
                    else if (line.Contains(separator))
                    {
                        if (line.Contains("DoubleBus"))
                        {
                            bus = new DoubleBus(line.Split(separator)[1]);
                        }
                        else if (line.Contains("Bus"))
                        {
                            bus = new Bus(line.Split(separator)[1]);
                        }
                        if (!(busStationStages[key] + bus))
                        {
                            throw new BusStationOverflowException();
                        }
                    }
                }
            }
        }
    }
}