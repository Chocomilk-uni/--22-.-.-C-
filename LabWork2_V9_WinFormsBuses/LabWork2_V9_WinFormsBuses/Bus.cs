using System.Drawing;

namespace LabWork2_V9_WinFormsBuses
{
    class Bus : PublicTransport
    {
        //Размеры автобуса
        protected readonly int busHeight = 60;
        protected readonly int busWidth = 100;
        protected readonly double changeHeight = 1.4;
        public Bus(Color mainColor, int averageSpeed, float weight, int seats)
        {
            MainColor = mainColor;
            AverageSpeed = averageSpeed;
            Weight = weight;
            Seats = seats;
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

            //Оновной кузов
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
    }
}
