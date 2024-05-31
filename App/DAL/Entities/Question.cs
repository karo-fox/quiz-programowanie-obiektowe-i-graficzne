using MySql.Data.MySqlClient;

namespace App.DAL.Entities
{
    class Question
    {
        public sbyte Id { get; set; }
        public string Text { get; set; }
        public sbyte QuizId {  get; set; }

        public Question(MySqlDataReader reader)
        {
            Id = sbyte.Parse(reader["id"].ToString());
            Text = reader["text"].ToString();
            QuizId = sbyte.Parse(reader["quiz"].ToString());
        }
    }
}
