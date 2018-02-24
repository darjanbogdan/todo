﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.DataAccess.Context
{
    public class TodoDbContextConfiguration
    {
        public TodoDbContextConfiguration (string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; }
    }
}
