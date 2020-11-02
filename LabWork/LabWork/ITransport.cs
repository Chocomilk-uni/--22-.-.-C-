using System.Drawing;

namespace LabWork
{
    public interface ITransport
    {
        void SetPosition(int x, int y, int width, int height);
        void MoveTransport(Direction direction);
        void DrawTransport(Graphics g);
        void SetMainColor(Color color);
    }
}