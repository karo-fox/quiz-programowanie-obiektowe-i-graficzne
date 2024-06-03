using MySql.Data.MySqlClient;

namespace App.DAL.Entities
{
    class Answer
    {
        public sbyte Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public sbyte QuestionId { get; set; }

        public Answer(MySqlDataReader reader)
        {
            Id = sbyte.Parse(reader["id"].ToString());
            Text = reader["text"].ToString();
            IsCorrect = bool.Parse(reader["isCorrect"].ToString());
            QuestionId = sbyte.Parse(reader["question"].ToString());
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
