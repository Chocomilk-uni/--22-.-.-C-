namespace LabWork
{
    partial class FormBusStation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxPickBus = new System.Windows.Forms.GroupBox();
            this.buttonPickBus = new System.Windows.Forms.Button();
            this.maskedTextBoxPlaceNumber = new System.Windows.Forms.MaskedTextBox();
            this.labelPlace = new System.Windows.Forms.Label();
            this.labelBusStations = new System.Windows.Forms.Label();
            this.buttonAddBusStation = new System.Windows.Forms.Button();
            this.buttonRemoveBusStation = new System.Windows.Forms.Button();
            this.listBoxBusStations = new System.Windows.Forms.ListBox();
            this.textBoxNewLevelName = new System.Windows.Forms.TextBox();
            this.pictureBoxBusStation = new System.Windows.Forms.PictureBox();
            this.buttonAddBus = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonSort = new System.Windows.Forms.Button();
            this.groupBoxPickBus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBusStation)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxPickBus
            // 
            this.groupBoxPickBus.Controls.Add(this.buttonPickBus);
            this.groupBoxPickBus.Controls.Add(this.maskedTextBoxPlaceNumber);
            this.groupBoxPickBus.Controls.Add(this.labelPlace);
            this.groupBoxPickBus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxPickBus.Location = new System.Drawing.Point(722, 335);
            this.groupBoxPickBus.Name = "groupBoxPickBus";
            this.groupBoxPickBus.Size = new System.Drawing.Size(150, 114);
            this.groupBoxPickBus.TabIndex = 3;
            this.groupBoxPickBus.TabStop = false;
            this.groupBoxPickBus.Text = "Забрать автобус";
            // 
            // buttonPickBus
            // 
            this.buttonPickBus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPickBus.Location = new System.Drawing.Point(31, 77);
            this.buttonPickBus.Name = "buttonPickBus";
            this.buttonPickBus.Size = new System.Drawing.Size(75, 23);
            this.buttonPickBus.TabIndex = 2;
            this.buttonPickBus.Text = "Забрать";
            this.buttonPickBus.UseVisualStyleBackColor = true;
            this.buttonPickBus.Click += new System.EventHandler(this.buttonPickBus_Click);
            // 
            // maskedTextBoxPlaceNumber
            // 
            this.maskedTextBoxPlaceNumber.Location = new System.Drawing.Point(74, 36);
            this.maskedTextBoxPlaceNumber.Name = "maskedTextBoxPlaceNumber";
            this.maskedTextBoxPlaceNumber.Size = new System.Drawing.Size(44, 22);
            this.maskedTextBoxPlaceNumber.TabIndex = 1;
            // 
            // labelPlace
            // 
            this.labelPlace.AutoSize = true;
            this.labelPlace.Location = new System.Drawing.Point(15, 39);
            this.labelPlace.Name = "labelPlace";
            this.labelPlace.Size = new System.Drawing.Size(52, 16);
            this.labelPlace.TabIndex = 0;
            this.labelPlace.Text = "Место:";
            // 
            // labelBusStations
            // 
            this.labelBusStations.AutoSize = true;
            this.labelBusStations.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBusStations.Location = new System.Drawing.Point(750, 34);
            this.labelBusStations.Name = "labelBusStations";
            this.labelBusStations.Size = new System.Drawing.Size(99, 16);
            this.labelBusStations.TabIndex = 4;
            this.labelBusStations.Text = "Автовокзалы:";
            // 
            // buttonAddBusStation
            // 
            this.buttonAddBusStation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddBusStation.Location = new System.Drawing.Point(722, 88);
            this.buttonAddBusStation.Name = "buttonAddBusStation";
            this.buttonAddBusStation.Size = new System.Drawing.Size(150, 28);
            this.buttonAddBusStation.TabIndex = 6;
            this.buttonAddBusStation.Text = "Добавить автовокзал";
            this.buttonAddBusStation.UseVisualStyleBackColor = false;
            this.buttonAddBusStation.Click += new System.EventHandler(this.buttonAddBusStation_Click);
            // 
            // buttonRemoveBusStation
            // 
            this.buttonRemoveBusStation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRemoveBusStation.Location = new System.Drawing.Point(722, 222);
            this.buttonRemoveBusStation.Name = "buttonRemoveBusStation";
            this.buttonRemoveBusStation.Size = new System.Drawing.Size(150, 31);
            this.buttonRemoveBusStation.TabIndex = 8;
            this.buttonRemoveBusStation.Text = "Удалить автовокзал";
            this.buttonRemoveBusStation.UseVisualStyleBackColor = true;
            this.buttonRemoveBusStation.Click += new System.EventHandler(this.buttonRemoveBusStation_Click);
            // 
            // listBoxBusStations
            // 
            this.listBoxBusStations.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxBusStations.FormattingEnabled = true;
            this.listBoxBusStations.ItemHeight = 15;
            this.listBoxBusStations.Location = new System.Drawing.Point(722, 122);
            this.listBoxBusStations.Name = "listBoxBusStations";
            this.listBoxBusStations.Size = new System.Drawing.Size(150, 94);
            this.listBoxBusStations.TabIndex = 7;
            this.listBoxBusStations.SelectedIndexChanged += new System.EventHandler(this.listBoxBusStations_SelectedIndexChanged);
            // 
            // textBoxNewLevelName
            // 
            this.textBoxNewLevelName.Location = new System.Drawing.Point(722, 62);
            this.textBoxNewLevelName.Name = "textBoxNewLevelName";
            this.textBoxNewLevelName.Size = new System.Drawing.Size(150, 20);
            this.textBoxNewLevelName.TabIndex = 9;
            // 
            // pictureBoxBusStation
            // 
            this.pictureBoxBusStation.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBoxBusStation.Location = new System.Drawing.Point(0, 24);
            this.pictureBoxBusStation.Name = "pictureBoxBusStation";
            this.pictureBoxBusStation.Size = new System.Drawing.Size(707, 437);
            this.pictureBoxBusStation.TabIndex = 0;
            this.pictureBoxBusStation.TabStop = false;
            // 
            // buttonAddBus
            // 
            this.buttonAddBus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddBus.Location = new System.Drawing.Point(722, 299);
            this.buttonAddBus.Name = "buttonAddBus";
            this.buttonAddBus.Size = new System.Drawing.Size(150, 30);
            this.buttonAddBus.TabIndex = 10;
            this.buttonAddBus.Text = "Добавить автобус";
            this.buttonAddBus.UseVisualStyleBackColor = true;
            this.buttonAddBus.Click += new System.EventHandler(this.buttonAddBus_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(884, 24);
            this.menuStrip.TabIndex = 11;
            this.menuStrip.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem,
            this.загрузитьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // загрузитьToolStripMenuItem
            // 
            this.загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            this.загрузитьToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.загрузитьToolStripMenuItem.Text = "Загрузить";
            this.загрузитьToolStripMenuItem.Click += new System.EventHandler(this.загрузитьToolStripMenuItem_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "txt file | *.txt";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "txt file | *.txt";
            // 
            // buttonSort
            // 
            this.buttonSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSort.Location = new System.Drawing.Point(722, 260);
            this.buttonSort.Name = "buttonSort";
            this.buttonSort.Size = new System.Drawing.Size(150, 33);
            this.buttonSort.TabIndex = 12;
            this.buttonSort.Text = "Сортировать";
            this.buttonSort.UseVisualStyleBackColor = true;
            this.buttonSort.Click += new System.EventHandler(this.buttonSort_Click);
            // 
            // FormBusStation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.buttonSort);
            this.Controls.Add(this.buttonAddBus);
            this.Controls.Add(this.textBoxNewLevelName);
            this.Controls.Add(this.buttonRemoveBusStation);
            this.Controls.Add(this.listBoxBusStations);
            this.Controls.Add(this.buttonAddBusStation);
            this.Controls.Add(this.labelBusStations);
            this.Controls.Add(this.groupBoxPickBus);
            this.Controls.Add(this.pictureBoxBusStation);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormBusStation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Автовокзал";
            this.groupBoxPickBus.ResumeLayout(false);
            this.groupBoxPickBus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBusStation)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxBusStation;
        private System.Windows.Forms.GroupBox groupBoxPickBus;
        private System.Windows.Forms.Button buttonPickBus;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxPlaceNumber;
        private System.Windows.Forms.Label labelPlace;
        private System.Windows.Forms.Label labelBusStations;
        private System.Windows.Forms.Button buttonAddBusStation;
        private System.Windows.Forms.Button buttonRemoveBusStation;
        private System.Windows.Forms.ListBox listBoxBusStations;
        private System.Windows.Forms.TextBox textBoxNewLevelName;
        private System.Windows.Forms.Button buttonAddBus;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button buttonSort;
    }
}