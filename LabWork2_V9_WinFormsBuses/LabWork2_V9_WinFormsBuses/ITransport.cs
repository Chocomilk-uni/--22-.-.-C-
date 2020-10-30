using System.Drawing;


namespace LabWork2_V9_WinFormsBuses
{
    interface ITransport
    {
        void SetPosition(int x, int y, int width, int height);
        void MoveTransport(Direction direction);
        void DrawTransport(Graphics g);
    }
}
