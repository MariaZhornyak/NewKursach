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
    public partial class ReportForm1 : Form
    {
        public ReportForm1()
        {
            InitializeComponent();
        }

        private void ReportForm1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'KursachDataSet2.Информация_про_сотрудников' table. You can move, or remove it, as needed.
            this.Информация_про_сотрудниковTableAdapter.Fill(this.KursachDataSet2.Информация_про_сотрудников);

            this.reportViewer1.RefreshReport();
        }
    }
}
