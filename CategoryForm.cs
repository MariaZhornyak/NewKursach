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
    public partial class CategoryForm : Form
    {
        public CategoryForm()
        {
            InitializeComponent();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kursachDataSet.Categories' table. You can move, or remove it, as needed.
            this.categoriesTableAdapter.Fill(this.kursachDataSet.Categories);

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var editCategory = new EditCategoryForm();
            editCategory.ShowDialog();

            categoriesTableAdapter.Fill(kursachDataSet.Categories);
            kursachDataSet.AcceptChanges();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show("Выберите, пожалуйста, категорию услуг, данные о которой хотите редактировать",
                                "Редактирование данных",
                                MessageBoxButtons.OK);
                return;
            }
            else if (dataGridView1.SelectedCells.Count > 1)
            {
                MessageBox.Show("Выберите, пожалуйста, одну категорию услуг, данные о которой хотите редактировать",
                                "Редактирование данных",
                                MessageBoxButtons.OK);
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex];

            int id = Convert.ToInt32(selectedRow.Cells[0].Value);
            string name = Convert.ToString(selectedRow.Cells[1].Value);

            EditCategoryForm editForm = new EditCategoryForm(id, name);
            editForm.ShowDialog();

            categoriesTableAdapter.Fill(kursachDataSet.Categories);
            kursachDataSet.AcceptChanges();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show("Выберите, пожалуйста, категории услуг, данные о которых хотите удалить",
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
                categoriesTableAdapter.DeleteQuery(id);
                categoriesTableAdapter.Fill(kursachDataSet.Categories);
                kursachDataSet.AcceptChanges();
            }
        }
    }
}
