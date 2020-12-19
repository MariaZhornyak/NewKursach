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
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'KursachDataSet1.Доходы_сотрудников' table. You can move, or remove it, as needed.
            this.Доходы_сотрудниковTableAdapter.Fill(this.KursachDataSet1.Доходы_сотрудников);

            this.reportViewer1.RefreshReport();
        }
    }
}
