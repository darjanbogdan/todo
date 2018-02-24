using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Domain.Context
{
    public class ContextScope : IContextScope
    {
        private object scopeObject = null;

        public T Get<T>() where T : class
        {
            return (T)scopeObject ?? default;
        }

        public void Set<T>(T obj) where T : class
        {
            scopeObject = obj;
        }
    }
}
