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
    public partial class ServicesForm : Form
    {
        public ServicesForm()
        {
            InitializeComponent();
        }

        private void ServicesForm_Load(object sender, EventArgs e)
        {
            this.categoriesTableAdapter.Fill(this.kursachDataSet.Categories);
            this.servicesTableAdapter.Fill(this.kursachDataSet.Services);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var editService = new EditServiceForm();
            editService.ShowDialog();

            servicesTableAdapter.Fill(kursachDataSet.Services);
            kursachDataSet.AcceptChanges();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show("Выберите, пожалуйста, услугу, данные о которой хотите редактировать",
                                "Редактирование данных",
                                MessageBoxButtons.OK);
                return;
            }
            else if (dataGridView1.SelectedCells.Count > 1)
            {
                MessageBox.Show("Выберите, пожалуйста, одну услугу, данные о которой хотите редактировать",
                                "Редактирование данных",
                                MessageBoxButtons.OK);
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex];

            int id = Convert.ToInt32(selectedRow.Cells[0].Value);
            string name = Convert.ToString(selectedRow.Cells[1].Value);
            decimal duration = Convert.ToDecimal(selectedRow.Cells[2].Value);
            decimal price = Convert.ToDecimal(selectedRow.Cells[3].Value);
            int categoryID = Convert.ToInt32(selectedRow.Cells[4].Value);

            EditServiceForm editForm = new EditServiceForm(id, name, duration, price, categoryID);
            editForm.ShowDialog();

            servicesTableAdapter.Fill(kursachDataSet.Services);
            kursachDataSet.AcceptChanges();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show("Выберите, пожалуйста, услуги, данные о которых хотите удалить",
                                "Удаление данных",
                                MessageBoxButtons.OK);
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex];

            int id = Convert.ToInt32(selectedRow.Cells[0].Value);
            string name = Convert.ToString(selectedRow.Cells[1].Value);

            if (MessageBox.Show($"Вы действительно хотите удалить данные об услуге {name}?",
                "Изменение данных", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                servicesTableAdapter.DeleteQuery(id);
                servicesTableAdapter.Fill(kursachDataSet.Services);
                kursachDataSet.AcceptChanges();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (priceTextBox.Text == "")
                {
                    priceTextBox.Text = "0";
                }
                if (priceTextBox3.Text == "")
                {
                    priceTextBox3.Text = "10000";
                }
                servicesBindingSource.Filter = "CONVERT(categoryID, 'System.String') LIKE '" + categoryComboBox.SelectedValue.ToString() + "' AND " +
                    String.Format("price >={0} and price <={1}", priceTextBox.Text, priceTextBox3.Text);
            }
            else
            {
                servicesBindingSource.Filter = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text != "" && priceTextBox2.Text == "")
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1.Rows[i].Selected = false;
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[1].Value != null)
                        {
                            if (dataGridView1.Rows[i].Cells[1].Value.ToString().ToLower().Contains(nameTextBox.Text.ToLower()))
                            {
                                dataGridView1.Rows[i].Selected = true;
                                break;
                            }
                        }

                    }
                }
            }

            if (nameTextBox.Text == "" && priceTextBox2.Text != "")
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1.Rows[i].Selected = false;
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[3].Value != null)
                        {
                            if (dataGridView1.Rows[i].Cells[3].Value.ToString().ToLower().Contains(priceTextBox2.Text.ToLower()))
                            {
                                dataGridView1.Rows[i].Selected = true;
                                break;
                            }
                        }

                    }
                }
            }

            if (nameTextBox.Text != "" && priceTextBox2.Text != "")
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1.Rows[i].Selected = false;
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[0].Value != null)
                        {
                            if (dataGridView1.Rows[i].Cells[1].Value.ToString().ToLower().Contains(nameTextBox.Text.ToLower()) &&
                                dataGridView1.Rows[i].Cells[3].Value.ToString().ToLower().Contains(priceTextBox2.Text.ToLower()))
                            {
                                dataGridView1.Rows[i].Selected = true;
                                break;
                            }
                        }

                    }
                }
            }
        }

        private void CategoryButton_Click(object sender, EventArgs e)
        {
            CategoryForm newForm = new CategoryForm();
            newForm.Show();
        }
    }
}
