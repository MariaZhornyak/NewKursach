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
    public partial class EditCategoryForm : Form
    {
        private readonly int categoryId;

        private bool edit;

        public EditCategoryForm()
        {
            InitializeComponent();

            edit = false;
        }

        public EditCategoryForm(int categoryId, string categoryName) : this()
        {
            this.categoryId = categoryId;
            categoryName_textBox.Text = categoryName;
            edit = true;
        }

        private void EditCategoryForm_Load(object sender, EventArgs e)
        {
            this.categoriesTableAdapter.Fill(this.kursachDataSet.Categories);

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ok_button_Click(object sender, EventArgs e)
        {
            if (edit)
            {
                categoriesTableAdapter.UpdateQuery(categoryName_textBox.Text, categoryId);
            }
            else
            {
                categoriesTableAdapter.InsertQuery(categoryName_textBox.Text);
            }

            this.Close();
        }
    }
}
