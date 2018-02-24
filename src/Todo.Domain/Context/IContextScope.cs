using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Domain.Context
{
    public interface IContextScope
    {
        T Get<T>() where T : class;

        void Set<T>(T obj) where T : class;
    }
}
