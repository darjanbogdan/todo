using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Domain.Context
{
    public interface IIdentityContext
    {
        bool IsAuthenticated { get; }

        IUserContext UserContext { get; }
    }
}
