using System;
using System.Collections.Generic;

namespace Snake.Core
{
    public interface IDataService
    {
        void Insert(Scores kitten);
        List<Scores> GetAll(Levels lvl);
    }
}

