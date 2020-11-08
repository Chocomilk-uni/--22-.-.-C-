using System;
using System.Drawing;
using System.Windows.Forms;

namespace LabWork
{
    public partial class FormBusConfig : Form
    {
        //Переменная - выбранный автобус
        private Bus bus = null;

        //Поле-событие (встроенный делегат)
        private Action<Bus> eventAddBus;

        //Метод добавления события
        public void AddEvent(Action<Bus> ev)
        {
            if (eventAddBus == null)
            {
                eventAddBus = new Action<Bus>(ev);
            }
            else
            {
                eventAddBus += ev;
            }
        }

        public FormBusConfig()
        {
            InitializeComponent();
            panelBlack.MouseDown += panelColor_MouseDown;
            panelBlue.MouseDown += panelColor_MouseDown;
            panelGreen.MouseDown += panelColor_MouseDown;
            panelPurple.MouseDown += panelColor_MouseDown;
            panelRed.MouseDown += panelColor_MouseDown;
            panelWhite.MouseDown += panelColor_MouseDown;
            panelTurquoise.MouseDown += panelColor_MouseDown;
            panelYellow.MouseDown += panelColor_MouseDown;
            buttonCancel.Click += (object sender, EventArgs e) => { Close(); };
        }

        //Отрисовка автобуса
        private void DrawBus()
        {
            if (bus != null)
            {
                Bitmap bmp = new Bitmap(pictureBoxBus.Width, pictureBoxBus.Height);
                Graphics gr = Graphics.FromImage(bmp);
                bus.SetPosition(5, 50, pictureBoxBus.Width, pictureBoxBus.Height);
                bus.DrawTransport(gr);
                pictureBoxBus.Image = bmp;
            }
        }

        //Передаём информацию при нажатии на Label
        private void labelBus_MouseDown(object sender, MouseEventArgs e)
        {
            labelBus.DoDragDrop(labelBus.Text, DragDropEffects.Move | DragDropEffects.Copy);
        }

        //Передаём информацию при нажатии на Label
        private void labelDoubleBus_MouseDown(object sender, MouseEventArgs e)
        {
            labelDoubleBus.DoDragDrop(labelDoubleBus.Text, DragDropEffects.Move | DragDropEffects.Copy);
        }

        //Проверка получаемой информации
        private void panelBus_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        //Действия при приёме перетаскиваемой информации
        private void panelBus_DragDrop(object sender, DragEventArgs e)
        {
            switch (e.Data.GetData(DataFormats.Text).ToString())
            {
                case "Обычный автобус":
                    bus = new Bus(Color.White, (int)numericUpDownSpeed.Value, (int)numericUpDownWeight.Value, (int)numericUpDownSeats.Value);
                    break;
                case "Двухэтажный автобус":
                    bus = new DoubleBus(Color.White, (int)numericUpDownSpeed.Value, (int)numericUpDownWeight.Value, (int)numericUpDownSeats.Value, Color.Black, checkBoxSecondFloor.Checked, 
                        checkBoxAdditionalDoor.Checked, checkBoxFrontPlatform.Checked);
                    break;
            }
            DrawBus();
        }

        //Проверка получаемой информации (для главного цвета и дополнительного)
        private void labelMainColor_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Color)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        //Действия при приёме перетаскиваемой информации (основной цвет)
        private void labelMainColor_DragDrop(object sender, DragEventArgs e)
        {
            if (bus != null)
            {
                bus.SetMainColor((Color)e.Data.GetData(typeof(Color)));
                DrawBus();
            }
        }

        //Универсальный метод для всех панелей с цветами
        private void panelColor_MouseDown(object sender, MouseEventArgs e)
        {
            Control panelColor = (Control)sender;
            panelColor.DoDragDrop(panelColor.BackColor, DragDropEffects.Move | DragDropEffects.Copy);
        }

        //Действия при приёме перетаскиваемой информации (дополнительный цвет)
        private void labelAdditionalColor_DragDrop(object sender, DragEventArgs e)
        {
            if (bus is DoubleBus)
            {
                DoubleBus doubleBus = (DoubleBus)bus;
                doubleBus.SetAdditionalColor((Color)e.Data.GetData(typeof(Color)));
                DrawBus();
            }
        }

        //Обработка нажатия кнопки "Добавить автобус"
        private void buttonOk_Click(object sender, EventArgs e)
        {
            //Вызов события
            eventAddBus?.Invoke(bus);
            Close();
        }
    }
}