using System;

namespace Snake.Core
{
    public class SnakeAppContext
    {
        #region Singleton
        private static SnakeAppContext instance;
        public static SnakeAppContext Instance
        {
            get
            {
                instance = instance ?? new SnakeAppContext();

                return instance; 
            }
        }
        #endregion

        #region Constructor
        public SnakeAppContext()
        {
           
        }
        #endregion

        #region Properties
        public Levels LevelChoiced { get; set; }

        public DataService DataServices { get; set; }
        #endregion
    }
}

