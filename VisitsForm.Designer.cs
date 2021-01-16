namespace NewKursach
{
    partial class VisitsForm
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
            this.ClientComboBox = new System.Windows.Forms.ComboBox();
            this.EmployeeComboBox = new System.Windows.Forms.ComboBox();
            this.ServiceComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.hourComboBox = new System.Windows.Forms.ComboBox();
            this.minuteComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ClientComboBox
            // 
            this.ClientComboBox.FormattingEnabled = true;
            this.ClientComboBox.Location = new System.Drawing.Point(174, 33);
            this.ClientComboBox.Name = "ClientComboBox";
            this.ClientComboBox.Size = new System.Drawing.Size(220, 21);
            this.ClientComboBox.TabIndex = 0;
            // 
            // EmployeeComboBox
            // 
            this.EmployeeComboBox.FormattingEnabled = true;
            this.EmployeeComboBox.Location = new System.Drawing.Point(174, 83);
            this.EmployeeComboBox.Name = "EmployeeComboBox";
            this.EmployeeComboBox.Size = new System.Drawing.Size(220, 21);
            this.EmployeeComboBox.TabIndex = 1;
            this.EmployeeComboBox.SelectedIndexChanged += new System.EventHandler(this.EmployeeComboBox_SelectedIndexChanged);
            // 
            // ServiceComboBox
            // 
            this.ServiceComboBox.FormattingEnabled = true;
            this.ServiceComboBox.Location = new System.Drawing.Point(174, 146);
            this.ServiceComboBox.Name = "ServiceComboBox";
            this.ServiceComboBox.Size = new System.Drawing.Size(220, 21);
            this.ServiceComboBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(51, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "Клиент";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(12, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "Сотрудник";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(62, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 28);
            this.label3.TabIndex = 5;
            this.label3.Text = "Услуга";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.Maroon;
            this.button1.Location = new System.Drawing.Point(122, 349);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 40);
            this.button1.TabIndex = 6;
            this.button1.Text = "Создать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(174, 206);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(220, 20);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // hourComboBox
            // 
            this.hourComboBox.FormattingEnabled = true;
            this.hourComboBox.Items.AddRange(new object[] {
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18"});
            this.hourComboBox.Location = new System.Drawing.Point(174, 258);
            this.hourComboBox.Name = "hourComboBox";
            this.hourComboBox.Size = new System.Drawing.Size(93, 21);
            this.hourComboBox.TabIndex = 8;
            // 
            // minuteComboBox
            // 
            this.minuteComboBox.FormattingEnabled = true;
            this.minuteComboBox.Items.AddRange(new object[] {
            "00",
            "30"});
            this.minuteComboBox.Location = new System.Drawing.Point(301, 258);
            this.minuteComboBox.Name = "minuteComboBox";
            this.minuteComboBox.Size = new System.Drawing.Size(93, 21);
            this.minuteComboBox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(79, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 28);
            this.label4.TabIndex = 10;
            this.label4.Text = "Дата";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(62, 251);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 28);
            this.label5.TabIndex = 11;
            this.label5.Text = "Время";
            // 
            // VisitsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightPink;
            this.ClientSize = new System.Drawing.Size(415, 401);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.minuteComboBox);
            this.Controls.Add(this.hourComboBox);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ServiceComboBox);
            this.Controls.Add(this.EmployeeComboBox);
            this.Controls.Add(this.ClientComboBox);
            this.Name = "VisitsForm";
            this.Text = "VisitsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ClientComboBox;
        private System.Windows.Forms.ComboBox EmployeeComboBox;
        private System.Windows.Forms.ComboBox ServiceComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox hourComboBox;
        private System.Windows.Forms.ComboBox minuteComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}