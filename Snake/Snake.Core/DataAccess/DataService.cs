using System;
using Cirrious.MvvmCross.Plugins.Sqlite;
using System.Collections.Generic;
using System.Linq;

namespace Snake.Core
{
    public class DataService : IDataService
    {
        private readonly ISQLiteConnection connection;

        public DataService(ISQLiteConnectionFactory factory)
        {
            connection = factory.Create("snakedb.sql");
            connection.CreateTable<Scores>();
        }  

        public void Insert(Scores kitten)
        {
            connection.Insert(kitten);
        }

        public List<Scores> GetAll(Levels lvl)
        {
            return connection.Table<Scores>().Where(x=>x.Level == (int)lvl).ToList();
        }

        public int Count
        {
            get
            {
                return connection.Table<Scores>().Count();
            }
        }
    }
}
