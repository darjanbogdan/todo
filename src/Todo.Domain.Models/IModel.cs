using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Domain.Model
{
    public interface IModel
    {
        Guid Id { get; set; }
    }
}
