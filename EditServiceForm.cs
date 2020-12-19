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
    public partial class EditServiceForm : Form
    {
        private readonly int serviceId;

        private bool edit;

        public EditServiceForm()
        {
            InitializeComponent();

            edit = false;
        }

        private void EditServiceForm_Load(object sender, EventArgs e)
        {
            this.servicesTableAdapter.Fill(this.kursachDataSet.Services);
            this.categoriesTableAdapter.Fill(this.kursachDataSet.Categories);

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public EditServiceForm(int serviceId, string serviceName, decimal duration,
            decimal price, int categoryID) : this()
        {
            this.serviceId = serviceId;

            serviceName_textBox.Text = serviceName;
            durationTextBox.Text = duration.ToString();
            priceTextBox.Text = price.ToString();
            CategoryComboBox.Text = categoryID.ToString();

            edit = true;
        }

        private void ok_button_Click(object sender, EventArgs e)
        {
            if (edit)
            {
                servicesTableAdapter.UpdateQuery(
                    serviceName_textBox.Text,
                    Convert.ToSingle(durationTextBox.Text),
                    Convert.ToDecimal(priceTextBox.Text),
                    Convert.ToInt32(CategoryComboBox.SelectedValue),
                    serviceId);
            }
            else
            {
                servicesTableAdapter.InsertQuery(
                    serviceName_textBox.Text,
                    Convert.ToSingle(durationTextBox.Text),
                    Convert.ToDecimal(priceTextBox.Text),
                    Convert.ToInt32(CategoryComboBox.SelectedValue));
            }

            this.Close();
        }

        private void priceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != ',')
            {
                e.Handled = true;
            }
        }

        private void durationTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != ',')
            {
                e.Handled = true;
            }
        }
    }
}
