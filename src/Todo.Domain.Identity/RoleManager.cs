using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Model.Identity;
using Todo.Domain.Storage.Identity;

namespace Todo.Domain.Identity
{
    public class RoleManager : RoleManager<Role>, IRoleStorage
    {
        public RoleManager(
            IRoleStore<Role> store, 
            IEnumerable<IRoleValidator<Role>> roleValidators, 
            ILookupNormalizer keyNormalizer, 
            IdentityErrorDescriber errors, 
            ILogger<RoleManager> logger) : base(store, roleValidators, keyNormalizer, errors, logger)
        {
        }
    }
}
