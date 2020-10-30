using System;
using System.Drawing;
using System.Windows.Forms;

namespace LabWork2_V9_WinFormsBuses
{
    public partial class FormBus : Form
    {
        private ITransport bus;
        public FormBus()
        {
            InitializeComponent();
        }
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxBuses.Width, pictureBoxBuses.Height); 
            Graphics gr = Graphics.FromImage(bmp); 
            bus.DrawTransport(gr);
            pictureBoxBuses.Image = bmp; 
        }

        //скорость не очень правдоподобная, чтобы передвижение было более заметно (изначально стояла от 40 до 50)
        private void buttonCreateBus_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            bus = new Bus(Color.Red, rnd.Next(1000, 1500), rnd.Next(5500, 8500), rnd.Next(20, 40));
            bus.SetPosition(rnd.Next(10, 100), rnd.Next(80, 110), pictureBoxBuses.Width, pictureBoxBuses.Height);
            Draw();
        }
        private void buttonCreateDoubleBus_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            bus = new DoubleBus(Color.Red, rnd.Next(1000, 1500), rnd.Next(5500, 8500), rnd.Next(20, 40), Color.White, true, true, true);
            bus.SetPosition(rnd.Next(10, 100), rnd.Next(100, 120), pictureBoxBuses.Width, pictureBoxBuses.Height);
            Draw();
        }
        private void buttonMove_Click(object sender, EventArgs e)
        {
            string name = (sender as Button).Name;
            switch (name)
            {
                case "buttonUp":
                    bus.MoveTransport(Direction.Up);
                    break;
                case "buttonDown":
                    bus.MoveTransport(Direction.Down);
                    break;
                case "buttonLeft":
                    bus.MoveTransport(Direction.Left);
                    break;
                case "buttonRight":
                    bus.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }
    }
}
