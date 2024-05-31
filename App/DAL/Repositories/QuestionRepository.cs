using App.DAL.Entities;
using MySql.Data.MySqlClient;

namespace App.DAL.Repositories
{
    class QuestionRepository
    {
        private const string QUESTIONS_BY_QUIZ_ID = "SELECT * FROM questions WHERE quiz = ";

        public static List<Question> GetQuestionsByQuizId(int quizId)
        {
            List<Question> questions = new List<Question>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(QUESTIONS_BY_QUIZ_ID + quizId + ";", connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read()) { questions.Add(new Question(reader)); }
                connection.Close();
            }

            return questions;
        }
    }
}
