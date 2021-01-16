using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NewKursach
{
    public partial class ClientsForm : Form
    {
        const string ConnectionString = @"Data Source=desktop-lmqqmnu;Initial Catalog=Kursach;Integrated Security=True";

        public ClientsForm()
        {
            InitializeComponent();
        }

        private void ClientsForm_Load(object sender, EventArgs e)
        {
            this.clientsTableAdapter.Fill(this.kursachDataSet.Clients);
            dataGridView1.AutoGenerateColumns = true;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var editClient = new EditClientForm();
            editClient.ShowDialog();

            clientsTableAdapter.Fill(kursachDataSet.Clients);
            kursachDataSet.AcceptChanges();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show("Выберите, пожалуйста, клиента, данные о котором хотите редактировать",
                                "Редактирование данных",
                                MessageBoxButtons.OK);
                return;
            }
            else if (dataGridView1.SelectedCells.Count > 1)
            {
                MessageBox.Show("Выберите, пожалуйста, одного клиента, данные о котором хотите редактировать",
                                "Редактирование данных",
                                MessageBoxButtons.OK);
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex];

            int id = Convert.ToInt32(selectedRow.Cells[0].Value);
            string name = Convert.ToString(selectedRow.Cells[1].Value);
            string phoneNumber = Convert.ToString(selectedRow.Cells[2].Value);
            DateTime DOB = Convert.ToDateTime(selectedRow.Cells[3].Value);
            string email = Convert.ToString(selectedRow.Cells[4].Value);
            string wayOfAttraction = Convert.ToString(selectedRow.Cells[5].Value);

            EditClientForm editForm = new EditClientForm(id, name, phoneNumber, DOB, email, wayOfAttraction);
            editForm.ShowDialog();

            clientsTableAdapter.Fill(kursachDataSet.Clients);
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
                clientsTableAdapter.DeleteQuery(id);
                clientsTableAdapter.Fill(kursachDataSet.Clients);
                kursachDataSet.AcceptChanges();
            }
        }

        private void phoneNumber_textBox_KeyPress(object sender, KeyPressEventArgs e)
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
                clientsBindingSource.Filter = "wayOfAttraction LIKE '%" + comboBox_wayOfAttraction.Text.ToString() + "%'";
            }
            else
            {
                clientsBindingSource.Filter = "";
            }
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            if (name_textBox.Text != "" && phoneNumber_textBox.Text == "")
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

            if (name_textBox.Text == "" && phoneNumber_textBox.Text != "")
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1.Rows[i].Selected = false;
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[2].Value != null)
                        {
                            if (dataGridView1.Rows[i].Cells[2].Value.ToString().ToLower().Contains(phoneNumber_textBox.Text.ToLower()))
                            {
                                dataGridView1.Rows[i].Selected = true;
                                break;
                            }
                        }

                    }
                }
            }

            if (name_textBox.Text != "" && phoneNumber_textBox.Text != "")
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1.Rows[i].Selected = false;
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[0].Value != null)
                        {
                            if (dataGridView1.Rows[i].Cells[1].Value.ToString().ToLower().Contains(name_textBox.Text.ToLower()) &&
                                dataGridView1.Rows[i].Cells[2].Value.ToString().ToLower().Contains(phoneNumber_textBox.Text.ToLower()))
                            {
                                dataGridView1.Rows[i].Selected = true;
                                break;
                            }
                        }

                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string querySortStart = " SELECT * FROM Clients ORDER BY ";
            string values = "";
            foreach (var box in this.Controls.OfType<CheckBox>().Reverse())
            {
                if (box.Checked && box.Name != "CheckBoxFilter")
                {
                    values += box.Text + ", ";
                }
            }

            if (values == "")
            {
                clientsBindingSource.Sort = values;
            }
            else
            {
                string querySort = querySortStart + values.Remove(values.Length - 2);
                try
                {
                    SqlConnection sqlconn = new SqlConnection(ConnectionString);
                    sqlconn.Open();
                    SqlDataAdapter oda = new SqlDataAdapter(querySort, sqlconn);
                    DataTable dt = new DataTable();
                    oda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    sqlconn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(@"Error: " + ex.Message);
                }
            }
        }
    }
}
