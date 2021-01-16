using System;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;

namespace Email
{
    class Program
    {
        private static readonly string ConnectionString = @"Data Source=desktop-lmqqmnu;Initial Catalog=Kursach;Integrated Security=True";

        static void Main(string[] args)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("senjoritakukushkina@gmail.com", "kukushkina49"),
                EnableSsl = true
            };

            string queryString = @"SELECT Clients.Email FROM Visits
                INNER JOIN SchedulePoint ON Visits.VisitID = SchedulePoint.VisitID
                INNER JOIN Clients ON Visits.ClientID = Clients.ClientID
                WHERE SchedulePoint.StartTime = (SELECT MIN(StartTime) FROM SchedulePoint S1 WHERE S1.VisitID = Visits.VisitID)
                AND DATEADD(second,
                        DATEPART(second, CURRENT_TIMESTAMP),
                        DATEADD(millisecond,
                            DATEPART(millisecond, CURRENT_TIMESTAMP),
                            SchedulePoint.StartTime
                        )
                    ) = DATEADD(day, 1, CURRENT_TIMESTAMP)";

            /*
            string queryString = @"SELECT Clients.Email FROM Visits
                INNER JOIN SchedulePoint ON Visits.VisitID = SchedulePoint.VisitID
                INNER JOIN Clients ON Visits.ClientID = Clients.ClientID
                WHERE SchedulePoint.StartTime = (SELECT MIN(StartTime) FROM SchedulePoint S1 WHERE S1.VisitID = Visits.VisitID)
                AND SchedulePoint.StartTime = '2021-01-08 11:30:00.000'";
            */

            SqlConnection sqlconn = new SqlConnection(ConnectionString);
            sqlconn.Open();
            SqlCommand cmd = new SqlCommand(queryString, sqlconn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                smtpClient.Send("senjoritakukushkina@gmail.com", reader["Email"].ToString(), "subject", "Напоминание: у вас завтра визит в наш салон!");
                Console.WriteLine(reader["Email"]);
            }
        }
    }
}
