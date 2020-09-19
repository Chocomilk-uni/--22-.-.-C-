using System;
using System.Drawing;
using System.Windows.Forms;

namespace LabWork1_V9_WindowsFormsBuses
{
    public partial class FormBus : Form
    {
        private Bus doubleBus;
        public FormBus()
        {
            InitializeComponent();
        }
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxBuses.Width, pictureBoxBuses.Height); 
            Graphics gr = Graphics.FromImage(bmp); 
            doubleBus.DrawTransport(gr);
            pictureBoxBuses.Image = bmp; 
        }

        //скорость не очень правдоподобная, чтобы передвижение было более заметно (изначально стояла от 40 до 50)
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            doubleBus = new Bus(Color.Red, Color.Black, Color.White, rnd.Next(1000, 1500), rnd.Next(5500, 8500), rnd.Next(20, 40), true, true, true);
            doubleBus.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxBuses.Width, pictureBoxBuses.Height);
            Draw();
        }
        private void buttonMove_Click(object sender, EventArgs e)
        {
            string name = (sender as Button).Name;
            switch (name)
            {
                case "buttonUp":
                    doubleBus.MoveTransport(Direction.Up);
                    break;
                case "buttonDown":
                    doubleBus.MoveTransport(Direction.Down);
                    break;
                case "buttonLeft":
                    doubleBus.MoveTransport(Direction.Left);
                    break;
                case "buttonRight":
                    doubleBus.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }
    }
}
