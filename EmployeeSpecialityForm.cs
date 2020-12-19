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
    public partial class EmployeeSpecialityForm : Form
    {
        public EmployeeSpecialityForm()
        {
            InitializeComponent();
        }

        private void EmployeeSpecialityForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kursachDataSet.EmployeeSpeciality' table. You can move, or remove it, as needed.
            this.employeeSpecialityTableAdapter.Fill(this.kursachDataSet.EmployeeSpeciality);

        }
    }
}
