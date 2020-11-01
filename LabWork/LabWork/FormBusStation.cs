using System;
using System.Drawing;
using System.Windows.Forms;

namespace LabWork
{
    public partial class FormBusStation : Form
    {
        //Объект от параметризованного класса-автовокзала
        private readonly BusStation<PublicTransport> busStation;
        public FormBusStation()
        {
            InitializeComponent();
            busStation = new BusStation<PublicTransport>(pictureBoxBusStation.Width, pictureBoxBusStation.Height);
            Draw();
        }

        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxBusStation.Width, pictureBoxBusStation.Height);
            Graphics gr = Graphics.FromImage(bmp);
            busStation.DrawBusStation(gr);
            pictureBoxBusStation.Image = bmp;
        }

        private void parkBusButton_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var bus = new Bus(dialog.Color, 1000, 6000, 40);
                if (busStation + bus)
                {
                    Draw();
                }
                else
                {
                    MessageBox.Show("Автовокзал переполнен");
                }
            }
        }

        private void parkDoubleBusButton_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ColorDialog dialogAddit = new ColorDialog();
                if (dialogAddit.ShowDialog() == DialogResult.OK)
                {
                    var doubleBus = new DoubleBus(dialog.Color, 1000, 6000, 40, dialogAddit.Color, true, true, true);
                    if (busStation + doubleBus)
                    {
                        Draw();
                    }
                    else
                    {
                        MessageBox.Show("Автовокзал переполнен");
                    }
                }
            }
        }

        private void pickBusButton_Click(object sender, EventArgs e)
        {
            if (placeNumberMaskedTextBox.Text != "")
            {
                var bus = busStation - Convert.ToInt32(placeNumberMaskedTextBox.Text);
                if (bus != null)
                {
                    FormBus form = new FormBus();
                    form.SetBus(bus);
                    form.ShowDialog();
                }
                Draw();
            }
        }
    }
}