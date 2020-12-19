using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewKursach
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClientsForm newForm = new ClientsForm();
            newForm.Show();
        }

        private void services_button_Click(object sender, EventArgs e)
        {
            ServicesForm newForm = new ServicesForm();
            newForm.Show();
        }

        private void employee_button_Click(object sender, EventArgs e)
        {
            EmployeeFrom newForm = new EmployeeFrom();
            newForm.Show();
        }

        private void getStatistics_button_Click(object sender, EventArgs e)
        {
            GetStatisticsForm newForm = new GetStatisticsForm();
            newForm.Show();
        }

        private void AllInfoButton_Click(object sender, EventArgs e)
        {
            AllInfoForm newForm = new AllInfoForm();
            newForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReportForm newForm = new ReportForm();
            newForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReportForm1 newForm = new ReportForm1();
            newForm.Show();
        }

        private void reminderButton_Click(object sender, EventArgs e)
        {
            EmailForm newForm = new EmailForm();
            newForm.Show();
        }
    }
}
