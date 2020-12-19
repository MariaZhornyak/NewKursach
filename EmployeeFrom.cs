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
    public partial class EmployeeFrom : Form
    {
        public EmployeeFrom()
        {
            InitializeComponent();
        }

        private void EmployeeFrom_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kursachDataSet.Employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter.Fill(this.kursachDataSet.Employees);
            // TODO: This line of code loads data into the 'kursachDataSet.Employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter.Fill(this.kursachDataSet.Employees);
            // TODO: This line of code loads data into the 'kursachDataSet.Employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter.Fill(this.kursachDataSet.Employees);
            // TODO: This line of code loads data into the 'kursachDataSet.Employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter.Fill(this.kursachDataSet.Employees);

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var editEmployee = new EditEmployeeForm();
            editEmployee.ShowDialog();

            employeesTableAdapter.Fill(kursachDataSet.Employees);
            kursachDataSet.AcceptChanges();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show("Выберите, пожалуйста, сотрудника, данные о котором хотите редактировать",
                                "Редактирование данных",
                                MessageBoxButtons.OK);
                return;
            }
            else if (dataGridView1.SelectedCells.Count > 1)
            {
                MessageBox.Show("Выберите, пожалуйста, одного сотрудника, данные о котором хотите редактировать",
                                "Редактирование данных",
                                MessageBoxButtons.OK);
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex];

            int id = Convert.ToInt32(selectedRow.Cells[0].Value);
            string name = Convert.ToString(selectedRow.Cells[1].Value);
            string phoneNumber = Convert.ToString(selectedRow.Cells[2].Value);
            DateTime DOB = Convert.ToDateTime(selectedRow.Cells[3].Value);
            DateTime beginningYear = Convert.ToDateTime(selectedRow.Cells[3].Value);

            EditEmployeeForm editForm = new EditEmployeeForm(id, name, phoneNumber, beginningYear, DOB);
            editForm.ShowDialog();

            employeesTableAdapter.Fill(kursachDataSet.Employees);
            kursachDataSet.AcceptChanges();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show("Выберите, пожалуйста, клиентов, данные о которых хотите удалить",
                                "Удаление данных",
                                MessageBoxButtons.OK);
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex];

            int id = Convert.ToInt32(selectedRow.Cells[0].Value);
            string name = Convert.ToString(selectedRow.Cells[1].Value);

            if (MessageBox.Show($"Вы действительно хотите удалить данные о клиенте {name}?",
                "Изменение данных", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                employeesTableAdapter.DeleteQuery(id);
                employeesTableAdapter.Fill(kursachDataSet.Employees);
                kursachDataSet.AcceptChanges();
            }
        }

        private void phoneNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != '-') // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                employeesBindingSource.Filter = "employeeName LIKE '%" + nameTextBox2.Text.ToString() + "%'";
            }
            else
            {
                employeesBindingSource.Filter = "";
            }
        }

        

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (name_textBox.Text != "" && phoneNumberTextBox.Text == "")
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1.Rows[i].Selected = false;
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[1].Value != null)
                        {
                            if (dataGridView1.Rows[i].Cells[1].Value.ToString().ToLower().Contains(name_textBox.Text.ToLower()))
                            {
                                dataGridView1.Rows[i].Selected = true;
                                break;
                            }
                        }

                    }
                }
            }

            if (name_textBox.Text == "" && phoneNumberTextBox.Text != "")
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1.Rows[i].Selected = false;
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[2].Value != null)
                        {
                            if (dataGridView1.Rows[i].Cells[2].Value.ToString().ToLower().Contains(phoneNumberTextBox.Text.ToLower()))
                            {
                                dataGridView1.Rows[i].Selected = true;
                                break;
                            }
                        }

                    }
                }
            }

            if (name_textBox.Text != "" && phoneNumberTextBox.Text != "")
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1.Rows[i].Selected = false;
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[0].Value != null)
                        {
                            if (dataGridView1.Rows[i].Cells[1].Value.ToString().ToLower().Contains(name_textBox.Text.ToLower()) &&
                                dataGridView1.Rows[i].Cells[2].Value.ToString().ToLower().Contains(phoneNumberTextBox.Text.ToLower()))
                            {
                                dataGridView1.Rows[i].Selected = true;
                                break;
                            }
                        }

                    }
                }
            }
        }
    }
}
