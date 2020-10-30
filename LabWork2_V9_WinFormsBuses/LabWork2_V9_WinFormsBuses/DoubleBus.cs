using System.Drawing;

namespace LabWork2_V9_WinFormsBuses
{
    class DoubleBus : Bus
    {
        public Color AdditColor { private set; get; }
        public bool SecondFloor { private set; get; }
        public bool AdditionalDoor { private set; get; }
        public bool FrontPlatform { private set; get; }
        public DoubleBus(Color mainColor, int averageSpeed, float weight, int seats, Color additColor, bool secondFloor, bool additionalDoor, bool frontPlatform) : base(mainColor, averageSpeed, weight, seats, 100, 60, 1.4)
        {
            AdditColor = additColor;
            SecondFloor = secondFloor;
            AdditionalDoor = additionalDoor;
            FrontPlatform = frontPlatform;
        }

        public override void DrawTransport(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            Pen pen2 = new Pen(AdditColor);

            base.DrawTransport(g);

            Brush brRed = new SolidBrush(MainColor);
            Brush brWhite = new SolidBrush(AdditColor);

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
                g.FillRectangle(brGray, _startPosX + 37, _startPosY + 40, 18, 32);
                g.DrawLine(pen2, _startPosX + 46, _startPosY + 40, _startPosX + 46, _startPosY + 72);
            }
        }
    }
}