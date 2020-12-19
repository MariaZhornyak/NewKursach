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
    public partial class EditClientForm : Form
    {
        private readonly int clientId;

        private bool edit;

        public EditClientForm()
        {
            InitializeComponent();

            edit = false;
        }

        public EditClientForm(int clientId, string clientName, string phoneNumber,
            DateTime DOB, string email, string wayOfAttraction) : this()
        {
            this.clientId = clientId;

            clientName_textBox.Text = clientName;
            phoneNumber_textBox.Text = phoneNumber;
            dateTimePicker1.Value = DOB;
            email_textBox.Text = email;

            switch (wayOfAttraction)
            {
                case "Социальные сети":
                    wayOfAttraction_comboBox.SelectedIndex = 0;
                    break;
                case "Реклама":
                    wayOfAttraction_comboBox.SelectedIndex = 1;
                    break;
                case "От знакомых":
                    wayOfAttraction_comboBox.SelectedIndex = 2;
                    break;
                case "Другое":
                    wayOfAttraction_comboBox.SelectedIndex = 3;
                    break;
            }

            edit = true;
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Ok_button_Click(object sender, EventArgs e)
        {
            if (edit)
            {
                clientsTableAdapter.UpdateQuery(
                    clientName_textBox.Text,
                    phoneNumber_textBox.Text,
                    Convert.ToString(dateTimePicker1.Value),
                    email_textBox.Text,
                    Convert.ToString(wayOfAttraction_comboBox.Text),
                    clientId);
            }
            else
            {
                clientsTableAdapter.InsertQuery(
                    clientName_textBox.Text,
                    phoneNumber_textBox.Text,
                    Convert.ToString(dateTimePicker1.Value),
                    email_textBox.Text,
                    Convert.ToString(wayOfAttraction_comboBox.Text));
            }

            this.Close();
        }

        private void EditClientForm_Load(object sender, EventArgs e)
        {
            this.clientsTableAdapter.Fill(this.kursachDataSet.Clients);
        }

        private void phoneNumber_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != '-')
            {
                e.Handled = true;
            }
        }

        private void email_textBox_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidEmailAddress(email_textBox.Text, out errorMsg))
            {
                e.Cancel = true;
                email_textBox.Select(0, email_textBox.Text.Length);

                this.errorProvider1.SetError(email_textBox, errorMsg);
            }
        }

        public bool ValidEmailAddress(string emailAddress, out string errorMessage)
        {
            if (emailAddress.Length == 0)
            {
                errorMessage = "email address is required.";
                return false;
            }

            if (emailAddress.IndexOf("@") > -1)
            {
                if (emailAddress.IndexOf(".", emailAddress.IndexOf("@")) > emailAddress.IndexOf("@"))
                {
                    errorMessage = "";
                    return true;
                }
            }

            errorMessage = "email address must be valid email address format.\n" +
               "For example 'someone@example.com' ";
            return false;
        }

        private void email_textBox_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(email_textBox, "");
        }
    }
}
