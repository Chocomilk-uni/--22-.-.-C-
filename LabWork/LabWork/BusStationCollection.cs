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
        public bool SaveData(string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                WriteToFile($"BusStationCollection{Environment.NewLine}", fs);
                foreach (var level in busStationStages)
                {
                    //Начинаем автовокзал
                    WriteToFile($"BusStation{separator}{level.Key}{Environment.NewLine}", fs);
                    ITransport bus = null;
                    for (int i = 0; (bus = level.Value.GetNext(i)) != null; i++)
                    {
                        if (bus != null)
                        {
                            //Если место не пустое, записываем тип автобуса
                            if (bus.GetType().Name == "Bus")
                            {
                                WriteToFile($"Bus{separator}", fs);
                            }
                            if (bus.GetType().Name == "DoubleBus")
                            {
                                WriteToFile($"DoubleBus{separator}", fs);
                            }
                            //Записываем параметры
                            WriteToFile(bus + Environment.NewLine, fs);
                        }
                    }
                }
            }
            return true;
        }

        //Загрузка информации по автобусам на автовокзалах из файла
        public bool LoadData(string filename)
        {
            if (!File.Exists(filename))
            {
                return false;
            }
            string bufferTextFromFile = "";
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                byte[] b = new byte[fs.Length];
                UTF8Encoding temp = new UTF8Encoding(true);
                while (fs.Read(b, 0, b.Length) > 0)
                {
                    bufferTextFromFile += temp.GetString(b);
                }
            }
            bufferTextFromFile = bufferTextFromFile.Replace("\r", "");
            var strs = bufferTextFromFile.Split('\n');
            if (strs[0].Contains("BusStationCollection"))
            {
                //Очищаем записи
                busStationStages.Clear();
            }
            else
            {
                //Если нет такой записи, значит это не те даные
                return false;
            }
            PublicTransport bus = null;
            string key = string.Empty;
            for (int i = 1; i < strs.Length; i++)
            {
                //Идём по считанным записям
                if (strs[i].Contains("BusStation"))
                {
                    //Начинаем новую парковку
                    key = strs[i].Split(separator)[1];
                    busStationStages.Add(key, new BusStation<PublicTransport>(pictureWidth, pictureHeight));
                    continue;
                }
                if (string.IsNullOrEmpty(strs[i]))
                {
                    continue;
                }
                if (strs[i].Split(separator)[0] == "Bus")
                {
                    bus = new Bus(strs[i].Split(separator)[1]);
                }
                if (strs[i].Split(separator)[0] == "DoubleBus")
                {
                    bus = new DoubleBus(strs[i].Split(separator)[1]);
                }

                var result = busStationStages[key] + bus;
                if (!result)
                {
                    return false;
                }
            }
            return true;
        }
    }
}