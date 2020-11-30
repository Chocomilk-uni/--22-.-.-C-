using NLog;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LabWork
{
    public partial class FormBusStation : Form
    {
        private readonly BusStationCollection busStationCollection;

        //Логгер
        private readonly Logger logger;
        public FormBusStation()
        {
            InitializeComponent();
            busStationCollection = new BusStationCollection(pictureBoxBusStation.Width, pictureBoxBusStation.Height);
            Draw();
            logger = LogManager.GetCurrentClassLogger();
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
                try
                {
                    var bus = busStationCollection[listBoxBusStations.SelectedItem.ToString()] - Convert.ToInt32(maskedTextBoxPlaceNumber.Text);
                    if (bus != null)
                    {
                        FormBus form = new FormBus();
                        form.SetBus(bus);
                        form.ShowDialog();
                        logger.Info($"Изъят автобус {bus} с места {maskedTextBoxPlaceNumber.Text}");
                        Draw();
                    }
                }
                catch (BusStationPlaceNotFoundException ex)
                {
                    MessageBox.Show(ex.Message, "Не найдено", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Warn(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Неизвестная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Warn(ex.Message);
                }
            }
        }

        private void buttonAddBusStation_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNewLevelName.Text))
            {
                MessageBox.Show("Введите название автовокзала", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            logger.Info($"Добавили автовокзал {textBoxNewLevelName.Text}");
            busStationCollection.AddBusStation(textBoxNewLevelName.Text);
            ReloadLevels();
        }

        private void buttonRemoveBusStation_Click(object sender, EventArgs e)
        {
            if (listBoxBusStations.SelectedIndex > -1)
            {
                if (MessageBox.Show($"Удалить автовокзал {listBoxBusStations.SelectedItem.ToString()}?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    logger.Info($"Удалили автовокзал {listBoxBusStations.SelectedItem.ToString()}");
                    busStationCollection.DelBusStation(listBoxBusStations.SelectedItem.ToString());
                    ReloadLevels();
                }
            }
        }

        private void listBoxBusStations_SelectedIndexChanged(object sender, EventArgs e)
        {
            logger.Info($"Перешли на автовокзал {listBoxBusStations.SelectedItem.ToString()}");
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
                try
                {
                    if ((busStationCollection[listBoxBusStations.SelectedItem.ToString()]) + bus)
                    {
                        Draw();
                        logger.Info($"Добавлен автобус {bus}");
                    }
                    else
                    {
                        MessageBox.Show("Автобус не удалось поставить");
                    }
                    Draw();
                }
                catch (BusStationOverflowException ex)
                {
                    MessageBox.Show(ex.Message, "Переполнение автовокзала", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Warn(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Неизвестная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Warn(ex.Message);
                }
            }
        }

        //Обработка нажатия пункта меню "Сохранить"
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    busStationCollection.SaveData(saveFileDialog.FileName);
                    MessageBox.Show("Сохранение прошло успешно", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    logger.Info("Сохранено в файл " + saveFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Неизвестная ошибка при сохранении", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Warn(ex.Message);
                }
            }
        }

        //Обработка нажатия пункта меню "Загрузить"
        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    busStationCollection.LoadData(openFileDialog.FileName);
                    MessageBox.Show("Загрузили", "Результат", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    logger.Info("Загружено из файла " + openFileDialog.FileName);
                    ReloadLevels();
                    Draw();
                }
                catch (BusStationOverflowException ex)
                {
                    MessageBox.Show(ex.Message, "Занятое место", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Warn(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Неизвестная ошибка при сохранении", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Warn(ex.Message);
                }
            }
        }
    }
}