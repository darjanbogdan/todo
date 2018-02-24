using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Model.Identity;
using Todo.Domain.Storage.Identity;

namespace Todo.Domain.Identity
{
    public class RoleManager: RoleManager<Role>, IRoleManager
    {
        public RoleManager(
            IRoleStore<Role> store, 
            ILookupNormalizer keyNormalizer, 
            ILogger<RoleManager> logger) 
            : base(
                store, 
                roleValidators: null, 
                keyNormalizer, 
                errors: null, 
                logger)
        {
        }
    }
}
