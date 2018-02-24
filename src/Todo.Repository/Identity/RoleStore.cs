using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.DataAccess.Context;
using Todo.Domain.Model.Identity;

namespace Todo.DataAccess.Identity
{
    public class RoleStore : RoleStore<Role, TodoDbContext, Guid, UserRole, RoleClaim>
    {
        public RoleStore(TodoDbContext context) 
            : base(context)
        {
        }
    }
}
