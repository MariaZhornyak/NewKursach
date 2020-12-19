using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.Net.Mime;

namespace NewKursach
{
    public partial class EmailForm : Form
    {
        public EmailForm()
        {
            InitializeComponent();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 465);
                client.EnableSsl = true;
                // client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("senjoritakukushkina@gmail.com", "kukushkina48");
                MailMessage message = new MailMessage();
                message.To.Add(textBoxTo.Text);
                message.From = new MailAddress("senjoritakukushkina@gmail.com");
                message.Subject = textBoxSubject.Text;
                message.Body = textBoxMessage.Text;
                client.Send(message);
                MessageBox.Show("Сообщение отправлено!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EmailForm_Load(object sender, EventArgs e)
        {
            this.clientsTableAdapter.Fill(this.kursachDataSet.Clients);

        }
    }
}
