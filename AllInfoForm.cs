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
    public partial class AllInfoForm : Form
    {
        public AllInfoForm()
        {
            InitializeComponent();
        }

        private void AllInfoForm_Load(object sender, EventArgs e)
        {
            this.visitsTableAdapter.Fill(this.kursachDataSet.Visits);
            this.servicesTableAdapter.Fill(this.kursachDataSet.Services);
            this.schedulePointTableAdapter.Fill(this.kursachDataSet.SchedulePoint);
            // this.employeeSpecialityTableAdapter.Fill(this.kursachDataSet.EmployeeSpeciality);
            this.employeesTableAdapter.Fill(this.kursachDataSet.Employees);
            this.clientsTableAdapter.Fill(this.kursachDataSet.Clients);
            this.categoriesTableAdapter.Fill(this.kursachDataSet.Categories);

            dataGridView6.AutoGenerateColumns = true;
        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator3.BindingSource = clientsBindingSource;
            dataGridView6.DataSource = clientsBindingSource;
            label1.Text = "Клиенты";
        }

        private void сотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator3.BindingSource = employeesBindingSource;
            dataGridView6.DataSource = employeesBindingSource;
            label1.Text = "Сотрудники";
        }

        private void услугиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator3.BindingSource = servicesBindingSource;
            dataGridView6.DataSource = servicesBindingSource;
            label1.Text = "Услуги";
        }

        private void специальностьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator3.BindingSource = employeeSpecialityBindingSource;
            dataGridView6.DataSource = employeeSpecialityBindingSource;
            label1.Text = "Специальность";
        }

        private void расписаниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator3.BindingSource = schedulePointBindingSource;
            dataGridView6.DataSource = schedulePointBindingSource;
            label1.Text = "Расписание";
        }

        private void категорииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator3.BindingSource = categoriesBindingSource;
            dataGridView6.DataSource = categoriesBindingSource;
            label1.Text = "Категории";
        }

        private void посещенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator3.BindingSource = visitsBindingSource;
            dataGridView6.DataSource = visitsBindingSource;
            label1.Text = "Посещения";
        }

        private void AllInfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            visitsTableAdapter.Update(kursachDataSet);
            clientsTableAdapter.Update(kursachDataSet);
            employeesTableAdapter.Update(kursachDataSet);
            categoriesTableAdapter.Update(kursachDataSet);
            employeeSpecialityTableAdapter.Update(kursachDataSet);
            servicesTableAdapter.Update(kursachDataSet);
            schedulePointTableAdapter.Update(kursachDataSet);
        }
    }
}
