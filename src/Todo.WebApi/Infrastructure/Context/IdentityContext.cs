using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Domain.Context;

namespace Todo.WebApi.Infrastructure.Context
{
    public class IdentityContext : IIdentityContext
    {
        public IdentityContext(IUserContext userContext, bool isAuthenticated = default)
        {
            UserContext = userContext;
            IsAuthenticated = isAuthenticated;
        }

        public bool IsAuthenticated { get; }

        public IUserContext UserContext { get; }
    }
}
