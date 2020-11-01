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
            this.pictureBoxBusStation = new System.Windows.Forms.PictureBox();
            this.parkBusButton = new System.Windows.Forms.Button();
            this.parkDoubleBusButton = new System.Windows.Forms.Button();
            this.pickBusGroupBox = new System.Windows.Forms.GroupBox();
            this.pickBusButton = new System.Windows.Forms.Button();
            this.placeNumberMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.placeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBusStation)).BeginInit();
            this.pickBusGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxBusStation
            // 
            this.pictureBoxBusStation.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBoxBusStation.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxBusStation.Name = "pictureBoxBusStation";
            this.pictureBoxBusStation.Size = new System.Drawing.Size(723, 461);
            this.pictureBoxBusStation.TabIndex = 0;
            this.pictureBoxBusStation.TabStop = false;
            // 
            // parkBusButton
            // 
            this.parkBusButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.parkBusButton.Location = new System.Drawing.Point(737, 12);
            this.parkBusButton.Name = "parkBusButton";
            this.parkBusButton.Size = new System.Drawing.Size(135, 40);
            this.parkBusButton.TabIndex = 2;
            this.parkBusButton.Text = "Припарковать автобус";
            this.parkBusButton.UseVisualStyleBackColor = true;
            this.parkBusButton.Click += new System.EventHandler(this.parkBusButton_Click);
            // 
            // parkDoubleBusButton
            // 
            this.parkDoubleBusButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.parkDoubleBusButton.Location = new System.Drawing.Point(737, 58);
            this.parkDoubleBusButton.Name = "parkDoubleBusButton";
            this.parkDoubleBusButton.Size = new System.Drawing.Size(135, 60);
            this.parkDoubleBusButton.TabIndex = 3;
            this.parkDoubleBusButton.Text = "Припарковать двухэтажный автобус";
            this.parkDoubleBusButton.UseVisualStyleBackColor = true;
            this.parkDoubleBusButton.Click += new System.EventHandler(this.parkDoubleBusButton_Click);
            // 
            // pickBusGroupBox
            // 
            this.pickBusGroupBox.Controls.Add(this.pickBusButton);
            this.pickBusGroupBox.Controls.Add(this.placeNumberMaskedTextBox);
            this.pickBusGroupBox.Controls.Add(this.placeLabel);
            this.pickBusGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pickBusGroupBox.Location = new System.Drawing.Point(737, 189);
            this.pickBusGroupBox.Name = "pickBusGroupBox";
            this.pickBusGroupBox.Size = new System.Drawing.Size(135, 121);
            this.pickBusGroupBox.TabIndex = 4;
            this.pickBusGroupBox.TabStop = false;
            this.pickBusGroupBox.Text = "Забрать автобус";
            // 
            // pickBusButton
            // 
            this.pickBusButton.Location = new System.Drawing.Point(30, 73);
            this.pickBusButton.Name = "pickBusButton";
            this.pickBusButton.Size = new System.Drawing.Size(75, 23);
            this.pickBusButton.TabIndex = 2;
            this.pickBusButton.Text = "Забрать";
            this.pickBusButton.UseVisualStyleBackColor = true;
            this.pickBusButton.Click += new System.EventHandler(this.pickBusButton_Click);
            // 
            // placeNumberMaskedTextBox
            // 
            this.placeNumberMaskedTextBox.Location = new System.Drawing.Point(74, 36);
            this.placeNumberMaskedTextBox.Name = "placeNumberMaskedTextBox";
            this.placeNumberMaskedTextBox.Size = new System.Drawing.Size(44, 22);
            this.placeNumberMaskedTextBox.TabIndex = 1;
            // 
            // placeLabel
            // 
            this.placeLabel.AutoSize = true;
            this.placeLabel.Location = new System.Drawing.Point(15, 39);
            this.placeLabel.Name = "placeLabel";
            this.placeLabel.Size = new System.Drawing.Size(52, 16);
            this.placeLabel.TabIndex = 0;
            this.placeLabel.Text = "Место:";
            // 
            // FormBusStation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.pickBusGroupBox);
            this.Controls.Add(this.parkDoubleBusButton);
            this.Controls.Add(this.parkBusButton);
            this.Controls.Add(this.pictureBoxBusStation);
            this.Name = "FormBusStation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Автовокзал";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBusStation)).EndInit();
            this.pickBusGroupBox.ResumeLayout(false);
            this.pickBusGroupBox.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxBusStation;
        private System.Windows.Forms.Button parkBusButton;
        private System.Windows.Forms.Button parkDoubleBusButton;
        private System.Windows.Forms.GroupBox pickBusGroupBox;
        private System.Windows.Forms.Button pickBusButton;
        private System.Windows.Forms.MaskedTextBox placeNumberMaskedTextBox;
        private System.Windows.Forms.Label placeLabel;
    }
}