﻿using Models;
using System.Collections.Generic;

namespace Model
{
    public interface IHistoryRepository
    {
        History Get(int id);
        IList<History> GetAll();
        void Post(History obj);
    }
}