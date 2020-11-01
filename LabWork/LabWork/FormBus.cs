using System;
using System.Drawing;
using System.Windows.Forms;

namespace LabWork
{
    public partial class FormBus : Form
    {
        private ITransport bus;
        public FormBus()
        {
            InitializeComponent();
        }

        //Передача автобуса на форму
        public void SetBus(ITransport bus)
        {
            this.bus = bus;
            Draw();
        }
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxBuses.Width, pictureBoxBuses.Height);
            Graphics gr = Graphics.FromImage(bmp);
            bus?.DrawTransport(gr);
            pictureBoxBuses.Image = bmp;
        }
        private void buttonMove_Click(object sender, EventArgs e)
        {
            string name = (sender as Button).Name;
            switch (name)
            {
                case "buttonUp":
                    bus?.MoveTransport(Direction.Up);
                    break;
                case "buttonDown":
                    bus?.MoveTransport(Direction.Down);
                    break;
                case "buttonLeft":
                    bus?.MoveTransport(Direction.Left);
                    break;
                case "buttonRight":
                    bus?.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }
    }
}