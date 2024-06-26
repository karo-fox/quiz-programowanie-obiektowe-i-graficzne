﻿using System;
using MySql.Data.MySqlClient;

namespace App.DAL
{
    class DBConnection
    {
        private MySqlConnectionStringBuilder stringBuilder = new MySqlConnectionStringBuilder();
        private static DBConnection instance = null;
        public static DBConnection Instance
        {
            get
            {
                if (instance == null) instance = new DBConnection();
                return instance;
            }
        }

        private MySqlConnection connection;
        //public MySqlConnection Connection => connection;
        // Wywalało mi błąd connection is disposed, podmianka na to niżej naprawiło
        public MySqlConnection Connection => new MySqlConnection(stringBuilder.ToString());

        private DBConnection()
        {
            stringBuilder.UserID = Properties.Settings.Default.user;
            stringBuilder.Server = Properties.Settings.Default.server;
            stringBuilder.Database = Properties.Settings.Default.database;
            stringBuilder.Port = Properties.Settings.Default.port;
            stringBuilder.Password = Properties.Settings.Default.password;

            connection = new MySqlConnection(stringBuilder.ToString());
        }
    }
}
