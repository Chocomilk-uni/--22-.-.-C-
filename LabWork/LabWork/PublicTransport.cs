using System.Drawing;

namespace LabWork
{
    public abstract class PublicTransport : ITransport
    {
        protected float _startPosX;
        protected float _startPosY;

        protected int _pictureWidth;
        protected int _pictureHeight;
        public Color MainColor { protected set; get; }
        public int AverageSpeed { protected set; get; }
        public float Weight { protected set; get; }
        public int Seats { protected set; get; }
        public void SetPosition(int x, int y, int width, int height)
        {
            _startPosX = x;
            _startPosY = y;
            _pictureWidth = width;
            _pictureHeight = height;
        }
        public abstract void DrawTransport(Graphics g);
        public abstract void MoveTransport(Direction direction);
        public void SetMainColor(Color color)
        {
            MainColor = color;
        }
    }
}