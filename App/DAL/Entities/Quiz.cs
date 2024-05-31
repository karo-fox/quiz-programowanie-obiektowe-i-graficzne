using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    class Quiz
    {
        public sbyte? Id { get; set; }
        public string Name { get; set; }

        public Quiz(MySqlDataReader reader)
        {
            Id = sbyte.Parse(reader["id"].ToString());
            Name = reader["name"].ToString();
        }

        public override string ToString()
        {
            return $"Quiz {Id}: {Name}";
        }

        public string ToInsert()
        {
            return $"('{Name}')";
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Quiz quiz) return false;
            if (quiz.Name.ToLower() != Name.ToLower()) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
