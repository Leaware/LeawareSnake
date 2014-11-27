using System;
using Cirrious.MvvmCross.Plugins.Sqlite;

namespace Snake.Core
{
    public class Scores
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        public int Level { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }
    }
}

