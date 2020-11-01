using System.Drawing;

namespace LabWork
{
    class BusStation<T> where T : class, ITransport
    {
        //Массив объектов от параметра
        private readonly T[] places;

        //Размеры окна отрисовки
        private readonly int pictureWidth;
        private readonly int pictureHeight;

        //Размеры места на автовокзале
        private readonly int _placeSizeWidth = 230;
        private readonly int _placeSizeHeight = 100;

        public BusStation(int picWidth, int picHeight)
        {
            int columnsNumber = picWidth / _placeSizeWidth;
            int rowsNumber = picHeight / _placeSizeHeight;
            places = new T[columnsNumber * rowsNumber];
            pictureWidth = picWidth;
            pictureHeight = picHeight;
        }

        //Перегрузка оператора сложения
        public static bool operator +(BusStation<T> busStation, T transport)
        {
            int rowsNumber = busStation.pictureHeight / busStation._placeSizeHeight;
            int margin = 10;
            for (int i = 0; i < busStation.places.Length; i++)
            {
                if (busStation.places[i] == null)
                {
                    transport.SetPosition(margin + busStation._placeSizeWidth * (i / rowsNumber), margin + busStation._placeSizeHeight * (i % rowsNumber), busStation.pictureWidth, busStation.pictureHeight);
                    busStation.places[i] = transport;
                    return true;
                }
            }
            return false;
        }

        //Перегрузка оператора вычитания
        public static T operator -(BusStation<T> busStation, int index)
        {
            if (index >= 0 && index < busStation.places.Length && busStation.places[index] != null)
            {
                T bus = busStation.places[index];
                busStation.places[index] = null;
                return bus;
            }
            return null;
        }

        //Метод отрисовки автовокзала
        public void DrawBusStation(Graphics g)
        {
            DrawMarking(g);
            for (int i = 0; i < places.Length; i++)
            {
                places[i]?.DrawTransport(g);
            }
        }

        //Метод отрисовки разметки мест на автовокзале
        public void DrawMarking(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 3);
            for (int i = 0; i < pictureWidth / _placeSizeWidth; i++)
            {
                for (int j = 0; j < pictureHeight / _placeSizeHeight + 1; ++j)
                {
                    //Линия разметки места
                    g.DrawLine(pen, i * _placeSizeWidth, j * _placeSizeHeight, i *
                   _placeSizeWidth + _placeSizeWidth / 2, j * _placeSizeHeight);
                }
                g.DrawLine(pen, i * _placeSizeWidth, 0, i * _placeSizeWidth,
               (pictureHeight / _placeSizeHeight) * _placeSizeHeight);
            }
        }
    }
}