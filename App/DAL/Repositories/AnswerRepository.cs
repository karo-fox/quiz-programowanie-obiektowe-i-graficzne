using App.DAL.Entities;
using MySql.Data.MySqlClient;

namespace App.DAL.Repositories
{
    class AnswerRepository
    {
        private const string ANSWERS_BY_QUESTION_ID = "SELECT * FROM answers WHERE question = ";

        public static List<Answer> GetAnswersByQuestionId(int questionId)
        {
            List<Answer> answers = new List<Answer>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ANSWERS_BY_QUESTION_ID + questionId + ";", connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read()) { answers.Add(new Answer(reader)); }
                connection.Close();
            }

            return answers;
        }
    }
}
