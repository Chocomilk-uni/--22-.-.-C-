using System.Collections.Generic;
using System.Drawing;

namespace LabWork
{
    class BusStation<T> where T : class, ITransport
    {
        //Список объектов, которые храним (заменили массив)
        private readonly List<T> places;

        //Максимальное количество мест на автовокзале
        private readonly int maxCount;

        //Размеры окна отрисовки
        private readonly int pictureWidth;
        private readonly int pictureHeight;

        //Размеры места на автовокзале
        private readonly int placeSizeWidth = 230;
        private readonly int placeSizeHeight = 100;

        public BusStation(int picWidth, int picHeight)
        {
            int columnsNumber = picWidth / placeSizeWidth;
            int rowsNumber = picHeight / placeSizeHeight;
            maxCount = columnsNumber * rowsNumber;
            places = new List<T>();
            pictureWidth = picWidth;
            pictureHeight = picHeight;
        }

        //Перегрузка оператора сложения
        public static bool operator +(BusStation<T> busStation, T bus)
        {
            if (busStation.places.Count < busStation.maxCount)
            {
                busStation.places.Add(bus);
                return true;
            }
            return false;
        }

        //Перегрузка оператора вычитания
        public static T operator -(BusStation<T> busStation, int index)
        {
            if (index >= 0 && index < busStation.maxCount && busStation.places[index] != null)
            {
                T bus = busStation.places[index];
                busStation.places.RemoveAt(index);
                return bus;
            }
            return null;
        }

        //Метод отрисовки автовокзала
        public void DrawBusStation(Graphics g)
        {
            int rowsNumber = pictureHeight / placeSizeHeight;
            int margin = 10;

            DrawMarking(g);
            for (int i = 0; i < places.Count; i++)
            {
                places[i]?.SetPosition(margin + placeSizeWidth * (i / rowsNumber), margin + placeSizeHeight * (i % rowsNumber), pictureWidth, pictureHeight);
                places[i]?.DrawTransport(g);
            }
        }

        //Метод отрисовки разметки мест на автовокзале
        public void DrawMarking(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 3);
            for (int i = 0; i < pictureWidth / placeSizeWidth; i++)
            {
                for (int j = 0; j < pictureHeight / placeSizeHeight + 1; ++j)
                {
                    //Линия разметки места
                    g.DrawLine(pen, i * placeSizeWidth, j * placeSizeHeight, i *
                   placeSizeWidth + placeSizeWidth / 2, j * placeSizeHeight);
                }
                g.DrawLine(pen, i * placeSizeWidth, 0, i * placeSizeWidth,
               (pictureHeight / placeSizeHeight) * placeSizeHeight);
            }
        }

        //Функция получения элементов из списка
        public T GetNext(int index)
        {
            if (index < 0 || index >= places.Count)
            {
                return null;
            }
            return places[index];
        }
    }
}