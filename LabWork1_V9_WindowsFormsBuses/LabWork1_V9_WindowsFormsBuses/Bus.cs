using System.Drawing;


namespace LabWork1_V9_WindowsFormsBuses
{
    class Bus
    {
        //координаты отрисовки
        private float _startPosX;
        private float _startPosY;

        //поле отрисовки
        private int _pictureWidth;
        private int _pictureHeight;

        //размеры автобуса
        private readonly int busHeight = 60;
        private readonly int busWidth = 100;
        private readonly double changeHeight = 1.4;
        public Color MainColor { private set; get; }
        public Color AdditColor { private set; get; }
        public Color AdditColor2 { private set; get; }
        public int AverageSpeed { private set; get; }
        public float Weight { private set; get; }
        public int Seats { private set; get; }
        public bool SecondFloor { private set; get; }
        public bool AdditionalDoor { private set; get; }
        public bool FrontPlatform { private set; get; }

        public Bus(Color mainColor, Color additColor, Color additColor2, int averageSpeed, float weight, int seats, bool secondFloor, bool additionalDoors, bool backPlatform)
        {
            MainColor = mainColor;
            AdditColor = additColor;
            AdditColor2 = additColor2;
            AverageSpeed = averageSpeed;
            Weight = weight;
            Seats = seats;
            SecondFloor = secondFloor;
            AdditionalDoor = additionalDoors;
            FrontPlatform = backPlatform;
        }

        public void SetPosition(int x, int y, int width, int height)
        {
            _startPosX = x;
            _startPosY = y;
            _pictureWidth = width;
            _pictureHeight = height;
        }

        public void MoveTransport(Direction direction)
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

        public void DrawTransport(Graphics g)
        {
            Pen pen = new Pen(Color.Black);

            //осн.кузов
            Brush brRed = new SolidBrush(MainColor);
            g.DrawRectangle(pen, _startPosX + 5, _startPosY + 30, busWidth, 40);
            g.FillRectangle(brRed, _startPosX + 5, _startPosY + 30, busWidth, 40);

            Brush brBlack = new SolidBrush(AdditColor);
            Brush brWhite = new SolidBrush(AdditColor2);

            //окна
            g.FillRectangle(brBlack, _startPosX + 12, _startPosY + 35, 20, 15);
            g.FillRectangle(brBlack, _startPosX + 62, _startPosY + 35, 20, 15);

            //дверь
            g.FillRectangle(brBlack, _startPosX + 87, _startPosY + 40, 18, 32);

            if (FrontPlatform)
            {
                g.DrawRectangle(pen, _startPosX, _startPosY + 55, 40, 15);
                g.FillRectangle(brRed, _startPosX, _startPosY + 50, 40, 20);
                g.FillRectangle(brBlack, _startPosX + 5, _startPosY + 35, 25, 15);
            }

            //колёса
            g.FillEllipse(brBlack, _startPosX + 10, _startPosY + 60, 22, 22);
            g.FillEllipse(brBlack, _startPosX + 65, _startPosY + 60, 22, 22);

            if (SecondFloor)
            {
                g.DrawRectangle(pen, _startPosX, _startPosY + 5, busWidth + 5, 25);
                g.FillRectangle(brRed, _startPosX, _startPosY + 5, busWidth + 5, 25);

                //окна 2-го этажа
                g.FillRectangle(brBlack, _startPosX + 2, _startPosY + 10, 20, 10);
                g.FillRectangle(brBlack, _startPosX + 32, _startPosY + 10, 20, 10);
                g.FillRectangle(brBlack, _startPosX + 62, _startPosY + 10, 20, 10);
                g.FillRectangle(brBlack, _startPosX + 92, _startPosY + 10, 14, 10);

                //полоса
                g.DrawRectangle(pen, _startPosX, _startPosY + 24, busWidth + 5, 3);
                g.FillRectangle(brWhite, _startPosX, _startPosY + 24, busWidth + 5, 3);
            }

            if (AdditionalDoor)
            {
                g.FillRectangle(brBlack, _startPosX + 37, _startPosY + 40, 18, 32);
            }
        }
    }
}
