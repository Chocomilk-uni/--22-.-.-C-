using System;
using System.Drawing;

namespace LabWork
{
    class DoubleBus : Bus
    {
        public Color AdditionalColor { private set; get; }
        public bool SecondFloor { private set; get; }
        public bool AdditionalDoor { private set; get; }
        public bool FrontPlatform { private set; get; }
        public DoubleBus(Color mainColor, int averageSpeed, float weight, int seats, Color additColor, bool secondFloor, bool additionalDoor, bool frontPlatform) : base(mainColor, averageSpeed, weight, seats, 100, 60, 1.4)
        {
            AdditionalColor = additColor;
            SecondFloor = secondFloor;
            AdditionalDoor = additionalDoor;
            FrontPlatform = frontPlatform;
        }

        //Конструктор для загрузки с файла
        public DoubleBus(string info) : base(info)
        {
            string[] strs = info.Split(separator);
            if (strs.Length == 8)
            {
                MainColor = Color.FromName(strs[0]);
                AverageSpeed = Convert.ToInt32(strs[1]);
                Weight = Convert.ToInt32(strs[2]);
                Seats = Convert.ToInt32(strs[3]);
                AdditionalColor = Color.FromName(strs[4]);
                SecondFloor = Convert.ToBoolean(strs[5]);
                AdditionalDoor = Convert.ToBoolean(strs[6]);
                FrontPlatform = Convert.ToBoolean(strs[7]);
            }
        }
        public override void DrawTransport(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            Pen additionalPen = new Pen(Color.White);

            base.DrawTransport(g);

            Brush brRed = new SolidBrush(MainColor);
            Brush brWhite = new SolidBrush(AdditionalColor);

            Brush brBlack = new SolidBrush(Color.Black);
            Brush brGray = new SolidBrush(Color.DarkSlateGray);

            if (FrontPlatform)
            {
                g.DrawRectangle(pen, _startPosX, _startPosY + 55, 40, 15);
                g.FillRectangle(brRed, _startPosX, _startPosY + 50, 40, 20);
                g.FillRectangle(brBlack, _startPosX + 5, _startPosY + 35, 28, 15);
                g.FillEllipse(brBlack, _startPosX + 10, _startPosY + 60, 22, 22);
            }

            if (SecondFloor)
            {
                g.DrawRectangle(pen, _startPosX, _startPosY + 5, busWidth + 5, 25);
                g.FillRectangle(brRed, _startPosX, _startPosY + 5, busWidth + 5, 25);

                //Окна 2-го этажа
                g.FillRectangle(brBlack, _startPosX + 2, _startPosY + 10, 20, 10);
                g.FillRectangle(brBlack, _startPosX + 32, _startPosY + 10, 20, 10);
                g.FillRectangle(brBlack, _startPosX + 62, _startPosY + 10, 20, 10);
                g.FillRectangle(brBlack, _startPosX + 92, _startPosY + 10, 14, 10);

                //Полоса
                g.DrawRectangle(pen, _startPosX, _startPosY + 24, busWidth + 5, 3);
                g.FillRectangle(brWhite, _startPosX, _startPosY + 24, busWidth + 5, 3);
            }

            if (AdditionalDoor)
            {
                g.FillRectangle(brGray, _startPosX + 37, _startPosY + 40, 18, 32);
                g.DrawLine(additionalPen, _startPosX + 46, _startPosY + 40, _startPosX + 46, _startPosY + 72);
            }
        }

        //Смена дополнительного цвета
        public void SetAdditionalColor(Color color)
        {
            AdditionalColor = color;
        }

        //Переопределение метода ToString() для получения строки из объекта
        public override string ToString()
        {
            return $"{MainColor.Name}{separator}{AverageSpeed}{separator}{Weight}{separator}{Seats}{separator}{AdditionalColor.Name}{separator}{SecondFloor}{separator}{AdditionalDoor}{separator}{FrontPlatform}";
        }
    }
}