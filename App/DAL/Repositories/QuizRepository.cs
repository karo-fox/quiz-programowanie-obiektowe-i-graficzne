using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Repositories
{
    using Entities;
    using MySql.Data.MySqlClient;
    using System.Collections.ObjectModel;
    using System.Diagnostics.Eventing.Reader;
    using System.Reflection.Metadata;

    class QuizRepository
    {
        private const string ALL_QUIZES = "SELECT * FROM quizes";
        private const string ALL_QUIZ_NAMES = "SELECT name FROM quizes";
        private const string ALL_QUIZ_IDS = "SELECT id FROM quizes";
        private const string QUIZID_BY_NAME = "SELECT id FROM quizes WHERE name = ";
        private const string ADD_NEW_QUIZ = "INSERT INTO quizes (name) VALUE ";
        private const string UPDATE = "UPDATE quizes SET ";

        public static ObservableCollection<Quiz> GetAllQuizes()
        {
            ObservableCollection<Quiz> quizes = [];

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
        public static ObservableCollection<String> GetAllQuizNames()
        {
            ObservableCollection<String> quizNames = [];
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_QUIZ_NAMES, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read()) { quizNames.Add(reader.GetString(0)); }
                connection.Close();
            }
            return quizNames;
        }
        public static ObservableCollection<int> GetAllQuizIds()
        {
            ObservableCollection<int> quizIds = [];
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_QUIZ_IDS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read()) { quizIds.Add(reader.GetInt32(0)); }
                connection.Close();
            }
            return quizIds;
        }
        public static int GetQuizIdByName(string name)
        {
            int id = -1;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(QUIZID_BY_NAME + $" '{name}' ", connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read()) { id=reader.GetInt32(0); }
                connection.Close();
            }
            return id;
        }
        public static bool AddNewQuiz(string name)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ADD_NEW_QUIZ + $"( '{name}' )", connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                stan = true;
                connection.Close();
            }
            return stan;
        }

        public static bool UpdateQuiz(Quiz quiz)
        {
            bool stan = false;
            using ( var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(UPDATE + "name='" + quiz.Name + "' WHERE id=" + quiz.Id, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                stan = true;
                connection.Close();
            }
            return stan;
        }
    }
}
