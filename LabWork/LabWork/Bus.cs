using System;
using System.Drawing;

namespace LabWork
{
    public class Bus : PublicTransport
    {
        //Размеры автобуса
        protected readonly int busHeight = 60;
        protected readonly int busWidth = 100;
        protected readonly double changeHeight = 1.4;

        //Разделитель для записи информации по объекту в файл
        protected readonly char separator = ';';
        public Bus(Color mainColor, int averageSpeed, float weight, int seats)
        {
            MainColor = mainColor;
            AverageSpeed = averageSpeed;
            Weight = weight;
            Seats = seats;
        }
        //Конструктор для загрузки с файла
        public Bus(string info)
        {
            string[] strs = info.Split(separator);
            if (strs.Length == 4)
            {
                MainColor = Color.FromName(strs[0]);
                AverageSpeed = Convert.ToInt32(strs[1]);
                Weight = Convert.ToInt32(strs[2]);
                Seats = Convert.ToInt32(strs[3]);
            }
        }
        protected Bus(Color mainColor, int averageSpeed, float weight, int seats, int busWidth, int busHeight, double changeHeight)
        {
            MainColor = mainColor;
            AverageSpeed = averageSpeed;
            Weight = weight;
            Seats = seats;
            this.busWidth = busWidth;
            this.busHeight = busHeight;
            this.changeHeight = changeHeight;
        }
        public override void MoveTransport(Direction direction)
        {
            float step = AverageSpeed * 100 / Weight;
            switch (direction)
            {
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - busWidth)
                    {
                        _startPosX += step;
                    }
                    break;
                case Direction.Left:
                    if (_startPosX - step > 0)
                    {
                        _startPosX -= step;
                    }
                    break;
                case Direction.Up:
                    if (_startPosY - step > 0)
                    {
                        _startPosY -= step;
                    }
                    break;
                case Direction.Down:
                    if (_startPosY + step < _pictureHeight - changeHeight * busHeight)
                    {
                        _startPosY += step;
                    }
                    break;
            }
        }

        public override void DrawTransport(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            Pen additionalPen = new Pen(Color.White);

            //Основной кузов
            Brush brRed = new SolidBrush(MainColor);
            g.DrawRectangle(pen, _startPosX + 5, _startPosY + 30, busWidth, 40);
            g.FillRectangle(brRed, _startPosX + 5, _startPosY + 30, busWidth, 40);

            Brush brBlack = new SolidBrush(Color.Black);
            Brush brGray = new SolidBrush(Color.DarkSlateGray);

            //Окна
            g.FillRectangle(brBlack, _startPosX + 5, _startPosY + 40, 28, 12);
            g.FillRectangle(brBlack, _startPosX + 62, _startPosY + 40, 20, 12);

            //Дверь
            g.FillRectangle(brGray, _startPosX + 87, _startPosY + 40, 18, 32);
            g.DrawLine(additionalPen, _startPosX + 96, _startPosY + 40, _startPosX + 96, _startPosY + 72);

            //Колёса
            g.FillEllipse(brBlack, _startPosX + 10, _startPosY + 60, 22, 22);
            g.FillEllipse(brBlack, _startPosX + 65, _startPosY + 60, 22, 22);
        }

        //Переопределение метода ToString() для получения строки из объекта
        public override string ToString()
        {
            return $"{MainColor.Name}{separator}{AverageSpeed}{separator}{Weight}{separator}{Seats}";
        }
    }
}