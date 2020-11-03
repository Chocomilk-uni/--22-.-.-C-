using System;
using System.Drawing;
using System.Windows.Forms;

namespace LabWork
{
    public partial class FormBusStation : Form
    {
        private readonly BusStationCollection busStationCollection;
        public FormBusStation()
        {
            InitializeComponent();
            busStationCollection = new BusStationCollection(pictureBoxBusStation.Width, pictureBoxBusStation.Height);
            Draw();
        }

        //Заполнение listBox
        private void ReloadLevels()
        {
            int index = listBoxBusStations.SelectedIndex;

            listBoxBusStations.Items.Clear();
            for (int i = 0; i < busStationCollection.Keys.Count; i++)
            {
                listBoxBusStations.Items.Add(busStationCollection.Keys[i]);
            }

            if (listBoxBusStations.Items.Count > 0 && (index == -1 || index >= listBoxBusStations.Items.Count))
            {
                listBoxBusStations.SelectedIndex = 0;
            }

            else if (listBoxBusStations.Items.Count > 0 && index > -1 && index < listBoxBusStations.Items.Count)
            {
                listBoxBusStations.SelectedIndex = index;
            }
        }

        private void Draw()
        {
            if (listBoxBusStations.SelectedIndex > -1)
            {
                Bitmap bmp = new Bitmap(pictureBoxBusStation.Width, pictureBoxBusStation.Height);
                Graphics gr = Graphics.FromImage(bmp);
                if (listBoxBusStations.SelectedIndex > -1)
                {
                    busStationCollection[listBoxBusStations.SelectedItem.ToString()].DrawBusStation(gr);
                }
                else
                {
                    gr.FillRectangle(new SolidBrush(Color.Transparent), 0, 0, pictureBoxBusStation.Width, pictureBoxBusStation.Height);
                }
                pictureBoxBusStation.Image = bmp;
            }
        }

        private void buttonParkBus_Click(object sender, EventArgs e)
        {
            if (listBoxBusStations.SelectedIndex > -1)
            {
                ColorDialog dialog = new ColorDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var bus = new Bus(dialog.Color, 1000, 6000, 40);
                    if (busStationCollection[listBoxBusStations.SelectedItem.ToString()] + bus)
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

        private void buttonParkDoubleBus_Click(object sender, EventArgs e)
        {
            if (listBoxBusStations.SelectedIndex > -1)
            {
                ColorDialog dialog = new ColorDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ColorDialog dialogAddit = new ColorDialog();
                    if (dialogAddit.ShowDialog() == DialogResult.OK)
                    {
                        var doubleBus = new DoubleBus(dialog.Color, 1000, 6000, 40, dialogAddit.Color, true, true, true);
                        if (busStationCollection[listBoxBusStations.SelectedItem.ToString()] + doubleBus)
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
        }

        private void buttonPickBus_Click(object sender, EventArgs e)
        {
            if (listBoxBusStations.SelectedIndex > -1 && maskedTextBoxPlaceNumber.Text != "")
            {
                var bus = busStationCollection[listBoxBusStations.SelectedItem.ToString()] - Convert.ToInt32(maskedTextBoxPlaceNumber.Text);
                if (bus != null)
                {
                    FormBus form = new FormBus();
                    form.SetBus(bus);
                    form.ShowDialog();
                }
                Draw();
            }
        }

        private void buttonAddBusStation_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNewLevelName.Text))
            {
                MessageBox.Show("Введите название автовокзала", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            busStationCollection.AddBusStation(textBoxNewLevelName.Text);
            ReloadLevels();
        }

        private void buttonRemoveBusStation_Click(object sender, EventArgs e)
        {
            if (listBoxBusStations.SelectedIndex > -1)
            {
                if (MessageBox.Show($"Удалить автовокзал {listBoxBusStations.SelectedItem.ToString()}?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    busStationCollection.DelBusStation(listBoxBusStations.SelectedItem.ToString());
                    ReloadLevels();
                }
            }
        }

        private void listBoxBusStations_SelectedIndexChanged(object sender, EventArgs e)
        {
            Draw();
        }

        //Метод обработки нажатия кнопки "Добавить автомобиль"
        private void buttonAddBus_Click(object sender, EventArgs e)
        {
            //Объект от формы с параметрами
            var formBusConfig = new FormBusConfig();
            //Связываем событие с методом
            formBusConfig.AddEvent(AddBus);
            //Вызов формы
            formBusConfig.Show();
        }

        //Метод добавления автобуса
        private void AddBus(PublicTransport bus)
        {
            if (bus != null && listBoxBusStations.SelectedIndex > -1)
            {
                if ((busStationCollection[listBoxBusStations.SelectedItem.ToString()]) + bus)
                {
                    Draw();
                }
                else
                {
                    MessageBox.Show("Автобус не удалось поставить");
                }
            }
        }
    }
}