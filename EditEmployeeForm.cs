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
    public partial class EditEmployeeForm : Form
    {
        private readonly int employeeId;

        private bool edit;

        public EditEmployeeForm()
        {
            InitializeComponent();

            edit = false;
        }

        public EditEmployeeForm(int employeeId, string employeeName, string phoneNumber,
            DateTime beginningYear, DateTime DOB) : this()
        {
            this.employeeId = employeeId;

            textBoxName.Text = employeeName;
            phoneNumber_textBox.Text = phoneNumber;
            dateTimePicker1.Value = beginningYear;
            dateTimePicker2.Value = DOB;

            edit = true;
        }

        private void ok_button_Click(object sender, EventArgs e)
        {
            if (edit)
            {
                employeesTableAdapter.UpdateQuery(
                    textBoxName.Text,
                    phoneNumber_textBox.Text,
                    Convert.ToString(dateTimePicker1.Value),
                    Convert.ToString(dateTimePicker2.Value),
                    employeeId);
            }
            else
            {
                employeesTableAdapter.InsertQuery(
                    textBoxName.Text,
                    phoneNumber_textBox.Text,
                    Convert.ToString(dateTimePicker1.Value),
                    Convert.ToString(dateTimePicker2.Value));
            }

            this.Close();
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditEmployeeForm_Load(object sender, EventArgs e)
        {
            this.employeesTableAdapter.Fill(this.kursachDataSet.Employees);
        }
    }
}
