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
    public partial class GetStatisticsForm : Form
    {
        const string ConnectionString = @"Data Source=desktop-lmqqmnu;Initial Catalog=Kursach;Integrated Security=True";
        public GetStatisticsForm()
        {
            InitializeComponent();
        }

        private void DoButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(ConnectionString);
                sqlconn.Open();
                SqlDataAdapter oda = new SqlDataAdapter(TestInput.Text, sqlconn);
                DataTable dt = new DataTable();
                oda.Fill(dt);
                dataGridView1.DataSource = dt;
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error: " + ex.Message);
            }

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            TestInput.Clear();
            TestInput.Text = "Select";
        }

        private void WayOfAttractionButton_Click(object sender, EventArgs e)
        {
            const string queryString = "SELECT WayOfAttraction, COUNT(WayOfAttraction) AS [Number of attractions] FROM Clients GROUP BY WayOfAttraction ORDER BY [Number of attractions] DESC";
                
            try
            {
                SqlConnection sqlconn = new SqlConnection(ConnectionString);
                sqlconn.Open();
                SqlDataAdapter oda = new SqlDataAdapter(queryString, sqlconn);
                DataTable dt = new DataTable();
                oda.Fill(dt);
                dataGridView1.DataSource = dt;
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error: " + ex.Message);
            }
        }

        private void servicesStatisticsButton_Click(object sender, EventArgs e)
        {
            const string queryString = @"SELECT Services.ServiceName, COUNT(Visits.VisitID) AS [Number of visits] FROM Services
                 INNER JOIN EmployeeSpeciality ON Services.ServiceID = EmployeeSpeciality.ServiceID
                 INNER JOIN Visits ON EmployeeSpeciality.SpecialityID = Visits.SpecialityID
                 GROUP BY Services.ServiceName ORDER BY COUNT(Visits.VisitID) DESC";

            try
            {
                SqlConnection sqlconn = new SqlConnection(ConnectionString);
                sqlconn.Open();
                SqlDataAdapter oda = new SqlDataAdapter(queryString, sqlconn);
                DataTable dt = new DataTable();
                oda.Fill(dt);
                dataGridView1.DataSource = dt;
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error: " + ex.Message);
            }
        }

        private void EmployeesStatisticsButton_Click(object sender, EventArgs e)
        {
            const string queryString = @"SELECT Top 1 Employees.EmployeeName, COUNT(Visits.VisitID) AS [Number of visits] FROM Employees 
                INNER JOIN EmployeeSpeciality ON Employees.EmployeeID = EmployeeSpeciality.EmployeeID
                INNER JOIN Visits ON EmployeeSpeciality.SpecialityID = Visits.SpecialityID
                GROUP BY Employees.EmployeeName ORDER BY COUNT(Visits.VisitID) DESC";

            try
            {
                SqlConnection sqlconn = new SqlConnection(ConnectionString);
                sqlconn.Open();
                SqlDataAdapter oda = new SqlDataAdapter(queryString, sqlconn);
                DataTable dt = new DataTable();
                oda.Fill(dt);
                dataGridView1.DataSource = dt;
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            const string queryString = @"SELECT Clients.ClientName, COUNT(Visits.VisitID) AS [Number of visits] FROM Clients
                INNER JOIN Visits ON Clients.ClientID = Visits.ClientID
                GROUP BY Clients.ClientName ORDER BY COUNT(Visits.VisitID) DESC";

            try
            {
                SqlConnection sqlconn = new SqlConnection(ConnectionString);
                sqlconn.Open();
                SqlDataAdapter oda = new SqlDataAdapter(queryString, sqlconn);
                DataTable dt = new DataTable();
                oda.Fill(dt);
                dataGridView1.DataSource = dt;
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error: " + ex.Message);
            }
        }
    }
}
