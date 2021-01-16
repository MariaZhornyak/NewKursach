using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NewKursach
{
    public partial class SchedulePointForm : Form
    {
        const string ConnectionString = @"Data Source=desktop-lmqqmnu;Initial Catalog=Kursach;Integrated Security=True";

        int employeeID;
        DateTime startTime;

        public SchedulePointForm(int employeeID, DateTime startTime)
        {
            InitializeComponent();

            this.employeeID = employeeID;
            this.startTime = startTime;

            string queryString = $@"SELECT VisitID, StartTime FROM SchedulePoint
                WHERE EmployeeID = {employeeID}
                AND DATEPART(year, StartTime) = {startTime.Year}
                AND DATEPART(month, StartTime) = {startTime.Month}
                AND DATEPART(day, StartTime) = {startTime.Day}";

            SqlConnection sqlconn = new SqlConnection(ConnectionString);
            sqlconn.Open();
            SqlCommand cmd = new SqlCommand(queryString, sqlconn);
            SqlDataReader reader = cmd.ExecuteReader();
            CheckBox[] checkBoxes = new CheckBox[]
            { 
                this.checkBox1,
                this.checkBox2,
                this.checkBox3,
                this.checkBox4,
                this.checkBox5,
                this.checkBox6,
                this.checkBox7,
                this.checkBox8,
                this.checkBox9,
                this.checkBox10,
                this.checkBox11,
                this.checkBox12,
                this.checkBox13,
                this.checkBox14,
                this.checkBox15,
                this.checkBox16,
                this.checkBox17,
                this.checkBox18,
                this.checkBox19,
                this.checkBox20
            };

            while (reader.Read())
            {
                DateTime start = Convert.ToDateTime(reader["startTime"].ToString());
                int n = start.Hour * 2 + Math.Min(1, start.Minute) - 18;
                checkBoxes[n].Checked = true;

                if (reader["VisitID"].ToString() != "")
                {
                    checkBoxes[n].Enabled = false;
                }
            }
        }

        private void SchedulePointForm_Load(object sender, EventArgs e)
        {

        }

        private void SchedulePointForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CheckBox[] checkBoxes = new CheckBox[]
            {
                this.checkBox1,
                this.checkBox2,
                this.checkBox3,
                this.checkBox4,
                this.checkBox5,
                this.checkBox6,
                this.checkBox7,
                this.checkBox8,
                this.checkBox9,
                this.checkBox10,
                this.checkBox11,
                this.checkBox12,
                this.checkBox13,
                this.checkBox14,
                this.checkBox15,
                this.checkBox16,
                this.checkBox17,
                this.checkBox18,
                this.checkBox19,
                this.checkBox20
            };

            for (int i = 0; i < checkBoxes.Length; i++)
            {
                if (checkBoxes[i].Checked)
                {
                    string queryString = $@"SELECT StartTime FROM SchedulePoint
                        WHERE EmployeeID = {employeeID}
                        AND DATEPART(year, StartTime) = {startTime.Year}
                        AND DATEPART(month, StartTime) = {startTime.Month}
                        AND DATEPART(day, StartTime) = {startTime.Day}
                        AND DATEPART(hour, StartTime) = {9 + i/2}
                        AND DATEPART(minute, StartTime) = {30 * (i % 2)}";

                    SqlConnection sqlconn = new SqlConnection(ConnectionString);
                    sqlconn.Open();
                    SqlCommand cmd = new SqlCommand(queryString, sqlconn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        string insertString = $@"INSERT INTO SchedulePoint (VisitID, EmployeeID, StartTime)
                            VALUES (NULL, {employeeID}, Convert(DateTime, '{startTime.Month}-{startTime.Day}-{startTime.Year} {9 + i / 2}:{((i % 2 == 0) ? "00" : "30")}:00'))";

                        sqlconn = new SqlConnection(ConnectionString);
                        sqlconn.Open();
                        cmd = new SqlCommand(insertString, sqlconn);
                        cmd.ExecuteReader();
                    }
                }
                else
                {
                    string deleteString = $@"DELETE FROM SchedulePoint
                        WHERE EmployeeID = {employeeID}
                        AND DATEPART(year, StartTime) = {startTime.Year}
                        AND DATEPART(month, StartTime) = {startTime.Month}
                        AND DATEPART(day, StartTime) = {startTime.Day}
                        AND DATEPART(hour, StartTime) = {9 + i / 2}
                        AND DATEPART(minute, StartTime) = {30 * (i % 2)}";

                    SqlConnection sqlconn = new SqlConnection(ConnectionString);
                    sqlconn.Open();
                    SqlCommand cmd = new SqlCommand(deleteString, sqlconn);
                    cmd.ExecuteReader();
                }
            }
        }
    }
}
