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
    public partial class VisitsForm : Form
    {
        const string ConnectionString = @"Data Source=desktop-lmqqmnu;Initial Catalog=Kursach;Integrated Security=True";

        public VisitsForm()
        {
            InitializeComponent();

            string queryString = "SELECT ClientName FROM Clients";

            SqlConnection sqlconn = new SqlConnection(ConnectionString);
            sqlconn.Open();
            SqlCommand cmd = new SqlCommand(queryString, sqlconn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ClientComboBox.Items.Add(reader["ClientName"].ToString());
            }

            queryString = "SELECT EmployeeName FROM Employees";

            sqlconn = new SqlConnection(ConnectionString);
            sqlconn.Open();
            cmd = new SqlCommand(queryString, sqlconn);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                EmployeeComboBox.Items.Add(reader["EmployeeName"].ToString());
            }
        }

        private void EmployeeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string queryString = $@"SELECT Services.ServiceName FROM Employees
                INNER JOIN EmployeeSpeciality ON Employees.EmployeeID = EmployeeSpeciality.EmployeeID
                INNER JOIN Services ON Services.ServiceID = EmployeeSpeciality.ServiceID
                WHERE Employees.EmployeeName = '{EmployeeComboBox.SelectedItem.ToString()}'";

            SqlConnection sqlconn = new SqlConnection(ConnectionString);
            sqlconn.Open();
            SqlCommand cmd = new SqlCommand(queryString, sqlconn);
            SqlDataReader reader = cmd.ExecuteReader();

            ServiceComboBox.SelectedItem = null;
            ServiceComboBox.Items.Clear();
            while (reader.Read())
            {
                ServiceComboBox.Items.Add(reader["ServiceName"].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ClientComboBox.SelectedItem.ToString() == "" || EmployeeComboBox.SelectedItem.ToString() == ""
                || ServiceComboBox.SelectedItem.ToString() == "" || hourComboBox.SelectedItem.ToString() == ""
                || minuteComboBox.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Пожалуйста, введите все данные.");
                return;
            }

            string queryString = $@"SELECT Duration FROM Services
                WHERE ServiceName = '{ServiceComboBox.SelectedItem.ToString()}'";

            SqlConnection sqlconn = new SqlConnection(ConnectionString);
            sqlconn.Open();
            SqlCommand cmd = new SqlCommand(queryString, sqlconn);
            SqlDataReader reader = cmd.ExecuteReader();

            reader.Read();

            float duration = Convert.ToSingle(reader["Duration"].ToString());

            for (int i = 0; i < duration * 2; i++)
            {
                int x = 2 * Convert.ToInt32(hourComboBox.SelectedItem.ToString()) + Convert.ToInt32(minuteComboBox.SelectedItem.ToString()) / 30;

                queryString = $@"SELECT StartTime FROM SchedulePoint
                    INNER JOIN Employees ON SchedulePoint.EmployeeID = Employees.EmployeeID
                    WHERE EmployeeName = '{EmployeeComboBox.SelectedItem.ToString()}'
                    AND SchedulePoint.VisitID = NULL
                    AND DATEPART(year, StartTime) = {dateTimePicker1.Value.Year}
                    AND DATEPART(month, StartTime) = {dateTimePicker1.Value.Month}
                    AND DATEPART(day, StartTime) = {dateTimePicker1.Value.Day}
                    AND DATEPART(hour, StartTime) = {Math.Floor(Convert.ToDecimal((x + i) / 2))}
                    AND DATEPART(minute, StartTime) = {30 * ((x + i) % 2)}";

                sqlconn = new SqlConnection(ConnectionString);
                sqlconn.Open();
                cmd = new SqlCommand(queryString, sqlconn);
                reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    MessageBox.Show("Нельзя создать посещение в это время.");
                    return;
                }
            }

            string getClientIdString = $"SELECT ClientID FROM Clients WHERE ClientName = '{ClientComboBox.SelectedItem.ToString()}'";
            string getSpecialityIdString = $"SELECT ServiceID FROM Services WHERE ServiceName = '{ServiceComboBox.SelectedItem.ToString()}'";

            string insertString = $@"INSERT INTO Visits (ClientID, SpecialityID)
                VALUES (({getClientIdString}), ({getSpecialityIdString}))";

            sqlconn = new SqlConnection(ConnectionString);
            sqlconn.Open();
            cmd = new SqlCommand(insertString, sqlconn);
            cmd.ExecuteReader();

            queryString = "SELECT MAX(VisitID) MaxVisitID FROM Visits";

            sqlconn = new SqlConnection(ConnectionString);
            sqlconn.Open();
            cmd = new SqlCommand(queryString, sqlconn);
            reader = cmd.ExecuteReader();

            reader.Read();

            int visitId = Convert.ToInt32(reader["MaxVisitID"].ToString());

            for (int i = 0; i < duration * 2; i++)
            {
                int x = 2 * Convert.ToInt32(hourComboBox.SelectedItem.ToString()) + Convert.ToInt32(minuteComboBox.SelectedItem.ToString()) / 30;

                queryString = $@"UPDATE SP SET VisitID = {visitId}
                    FROM SchedulePoint SP
                    INNER JOIN Employees ON SP.EmployeeID = Employees.EmployeeID
                    WHERE EmployeeName = '{EmployeeComboBox.SelectedItem.ToString()}'
                    AND DATEPART(year, StartTime) = {dateTimePicker1.Value.Year}
                    AND DATEPART(month, StartTime) = {dateTimePicker1.Value.Month}
                    AND DATEPART(day, StartTime) = {dateTimePicker1.Value.Day}
                    AND DATEPART(hour, StartTime) = {Math.Floor(Convert.ToDecimal((x + i) / 2))}
                    AND DATEPART(minute, StartTime) = {30 * ((x + i) % 2)}";

                sqlconn = new SqlConnection(ConnectionString);
                sqlconn.Open();
                cmd = new SqlCommand(queryString, sqlconn);
                cmd.ExecuteReader();
            }

            this.Close();
        }
    }
}
