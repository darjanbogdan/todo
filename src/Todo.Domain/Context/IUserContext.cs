using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Domain.Context
{
    public interface IUserContext
    {
        Guid UserId { get; }

        string UserName { get; }

        IEnumerable<string> Roles { get; }
    }
}
