using App.DAL.Entities;
using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;
using System.Reflection.Metadata;

namespace App.DAL.Repositories
{
    class AnswerRepository
    {
        private const string ANSWERS_BY_QUESTION_ID = "SELECT * FROM answers WHERE question = ";
        private const string ANSWERID_BY_QUESTION_ID = "SELECT id FROM answers WHERE question = ";
        private const string ADD_NEW_ANSWER = "INSERT INTO answers (text, isCorrect, question) VALUES ";

        public static ObservableCollection<Answer> GetAnswersByQuestionId(int questionId)
        {
            ObservableCollection<Answer> answers = [];

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ANSWERS_BY_QUESTION_ID + questionId, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read()) { answers.Add(new Answer(reader)); }
                connection.Close();
            }

            return answers;
        }

        public static List<int> GetAnswersIdByQuestionId(int questionId)
        {
            List<int> answers = new List<int>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ANSWERID_BY_QUESTION_ID + questionId, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read()) { answers.Add((int)reader.GetInt32(0)); }
                connection.Close();
            }
            return answers;
        }

        public static bool AddNewAnswer(string name, bool isTrue, int id)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ADD_NEW_ANSWER + $"( '{name}', {isTrue}, {id} )", connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                stan = true;
                connection.Close();
            }
            return stan;
        }
    }
}
