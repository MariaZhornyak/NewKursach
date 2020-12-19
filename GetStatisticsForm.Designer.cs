namespace NewKursach
{
    partial class GetStatisticsForm
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
            this.TestInput = new System.Windows.Forms.RichTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DoButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.WayOfAttractionButton = new System.Windows.Forms.Button();
            this.servicesStatisticsButton = new System.Windows.Forms.Button();
            this.EmployeesStatisticsButton = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // TestInput
            // 
            this.TestInput.Location = new System.Drawing.Point(12, 43);
            this.TestInput.Name = "TestInput";
            this.TestInput.Size = new System.Drawing.Size(532, 104);
            this.TestInput.TabIndex = 0;
            this.TestInput.Text = "SELECT";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 182);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(532, 332);
            this.dataGridView1.TabIndex = 1;
            // 
            // DoButton
            // 
            this.DoButton.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DoButton.ForeColor = System.Drawing.Color.Maroon;
            this.DoButton.Location = new System.Drawing.Point(601, 43);
            this.DoButton.Name = "DoButton";
            this.DoButton.Size = new System.Drawing.Size(238, 44);
            this.DoButton.TabIndex = 2;
            this.DoButton.Text = "Выполнить запрос";
            this.DoButton.UseVisualStyleBackColor = true;
            this.DoButton.Click += new System.EventHandler(this.DoButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClearButton.ForeColor = System.Drawing.Color.Maroon;
            this.ClearButton.Location = new System.Drawing.Point(601, 103);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(238, 44);
            this.ClearButton.TabIndex = 3;
            this.ClearButton.Text = "Очистить";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 28);
            this.label1.TabIndex = 4;
            this.label1.Text = "Введите свой запрос: ";
            // 
            // WayOfAttractionButton
            // 
            this.WayOfAttractionButton.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WayOfAttractionButton.ForeColor = System.Drawing.Color.Maroon;
            this.WayOfAttractionButton.Location = new System.Drawing.Point(576, 182);
            this.WayOfAttractionButton.Name = "WayOfAttractionButton";
            this.WayOfAttractionButton.Size = new System.Drawing.Size(318, 73);
            this.WayOfAttractionButton.TabIndex = 5;
            this.WayOfAttractionButton.Text = "Статистика способов привлечения";
            this.WayOfAttractionButton.UseVisualStyleBackColor = true;
            this.WayOfAttractionButton.Click += new System.EventHandler(this.WayOfAttractionButton_Click);
            // 
            // servicesStatisticsButton
            // 
            this.servicesStatisticsButton.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.servicesStatisticsButton.ForeColor = System.Drawing.Color.Maroon;
            this.servicesStatisticsButton.Location = new System.Drawing.Point(576, 277);
            this.servicesStatisticsButton.Name = "servicesStatisticsButton";
            this.servicesStatisticsButton.Size = new System.Drawing.Size(318, 44);
            this.servicesStatisticsButton.TabIndex = 6;
            this.servicesStatisticsButton.Text = "Статистика услуг";
            this.servicesStatisticsButton.UseVisualStyleBackColor = true;
            this.servicesStatisticsButton.Click += new System.EventHandler(this.servicesStatisticsButton_Click);
            // 
            // EmployeesStatisticsButton
            // 
            this.EmployeesStatisticsButton.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EmployeesStatisticsButton.ForeColor = System.Drawing.Color.Maroon;
            this.EmployeesStatisticsButton.Location = new System.Drawing.Point(576, 340);
            this.EmployeesStatisticsButton.Name = "EmployeesStatisticsButton";
            this.EmployeesStatisticsButton.Size = new System.Drawing.Size(318, 66);
            this.EmployeesStatisticsButton.TabIndex = 7;
            this.EmployeesStatisticsButton.Text = "Статистика работы сотрудников";
            this.EmployeesStatisticsButton.UseVisualStyleBackColor = true;
            this.EmployeesStatisticsButton.Click += new System.EventHandler(this.EmployeesStatisticsButton_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.ForeColor = System.Drawing.Color.Maroon;
            this.button4.Location = new System.Drawing.Point(576, 436);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(318, 78);
            this.button4.TabIndex = 8;
            this.button4.Text = "Статистика посещаемости клиентов";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // GetStatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightPink;
            this.ClientSize = new System.Drawing.Size(906, 580);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.EmployeesStatisticsButton);
            this.Controls.Add(this.servicesStatisticsButton);
            this.Controls.Add(this.WayOfAttractionButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.DoButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.TestInput);
            this.Name = "GetStatisticsForm";
            this.Text = "GetStatisticsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox TestInput;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button DoButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button WayOfAttractionButton;
        private System.Windows.Forms.Button servicesStatisticsButton;
        private System.Windows.Forms.Button EmployeesStatisticsButton;
        private System.Windows.Forms.Button button4;
    }
}