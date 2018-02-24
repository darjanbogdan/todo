using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Domain.Context;

namespace Todo.WebApi.Infrastructure.Context
{
    public class UserContext : IUserContext
    {
        public UserContext(params string[] roles)
            : this(Guid.Empty, String.Empty, roles)
        {

        }

        public UserContext(Guid userid, string userName, params string[] roles)
        {
            UserId = userid;
            Roles = roles ?? Enumerable.Empty<string>();
        }

        public Guid UserId { get; }

        public string UserName { get; }

        public IEnumerable<string> Roles { get; }
    }
}
