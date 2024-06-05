using App.DAL.Entities;
using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;

namespace App.DAL.Repositories
{
    class QuestionRepository
    {
        private const string QUESTIONS_BY_QUIZ_ID = "SELECT * FROM questions WHERE quiz = ";
        private const string QUESTIONID_BY_QUIZ_ID = "SELECT id FROM questions WHERE quiz = ";
        private const string ADD_NEW_QUESTION = "INSERT INTO questions (text, quiz) VALUES ";
        private const string UPDATE = "UPDATE questions SET ";
        private const string GET_ALL_QUESTIONS = "SELECT * FROM questions";

        public static ObservableCollection<Question> GetAllQuestions()
        {
            ObservableCollection<Question> questions = [];

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(GET_ALL_QUESTIONS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read()) { questions.Add(new Question(reader)); }
                connection.Close();
            }

            return questions;
        }

        public static List<Question> GetQuestionsByQuizId(int? quizId)
        {
            List<Question> questions = new List<Question>();

            if (quizId == null) { return questions; }

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
        public static List<int> GetQuestionIdByQuizId(int quizId)
        {
            List<int> questions = new List<int>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(QUESTIONID_BY_QUIZ_ID + quizId, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read()) { questions.Add((int)reader.GetInt32(0)); }
                connection.Close();
            }
            return questions;
        }

        public static bool AddNewQuestionWithAnswers(string name, int id, string ans1, string ans2, string ans3, string ans4, bool bans1, bool bans2, bool bans3, bool bans4)
        {
            bool stan = false;
            int questionId = -1;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ADD_NEW_QUESTION + $"( '{name}', {id} )", connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                stan = true;
                questionId = (int)command.LastInsertedId;
                connection.Close();
            }
            if (questionId != -1)
            {
                AnswerRepository.AddNewAnswer(ans1, bans1, questionId);
                AnswerRepository.AddNewAnswer(ans2, bans2, questionId);
                AnswerRepository.AddNewAnswer(ans3, bans3, questionId);
                AnswerRepository.AddNewAnswer(ans4, bans4, questionId);
            }
            return stan;
        }

        public static bool UpdateQuestion(Question question)
        {
            bool stan = false;
            using (var conn = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(UPDATE + "text='" + question.Text + "' WHERE id=" + question.Id, conn);
                conn.Open();
                var n = command.ExecuteNonQuery();
                stan = true;
                conn.Close();
            }
            return stan;
        }
    }
}
