﻿using App.DAL.Entities;
using MySql.Data.MySqlClient;
using System.Reflection.Metadata;

namespace App.DAL.Repositories
{
    class AnswerRepository
    {
        private const string ANSWERS_BY_QUESTION_ID = "SELECT * FROM answers WHERE question = ";
        private const string ADD_NEW_ANSWER = "INSERT INTO answers (text, isCorrect, question) VALUES ";

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
