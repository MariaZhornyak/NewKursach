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
    public partial class SelectDateForm : Form
    {
        int employeeID;

        public SelectDateForm(int employeeID)
        {
            this.employeeID = employeeID;

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SchedulePointForm newForm = new SchedulePointForm(employeeID, dateTimePicker1.Value);
            newForm.Show();
        }
    }
}
