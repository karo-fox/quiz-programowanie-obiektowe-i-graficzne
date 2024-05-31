using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Repositories
{
    using Entities;
    using MySql.Data.MySqlClient;

    class QuizRepository
    {
        private const string ALL_QUIZES = "SELECT * FROM quizes";

        public static List<Quiz> GetAllQuizes()
        {
            List<Quiz> quizes = new List<Quiz>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_QUIZES, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read()) { quizes.Add(new Quiz(reader)); }
                connection.Close();
            }

            return quizes;
        }
    }
}
