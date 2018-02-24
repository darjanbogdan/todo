using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Model.Identity;
using Todo.Domain.Storage.Identity;

namespace Todo.Domain.Identity
{
    public class UserManager : UserManager<User>, IUserManager
    {
        public UserManager(
            IUserStore<User> store, 
            IOptions<IdentityOptions> optionsAccessor, 
            IPasswordHasher<User> passwordHasher, 
            ILogger<UserManager> logger) 
            : base(
                store, 
                optionsAccessor, 
                passwordHasher, 
                userValidators: null, 
                passwordValidators: null, 
                keyNormalizer: null, 
                errors: null, 
                services: null, 
                logger)
        {
        }

        async Task<bool> IUserManager.CreateAsync(User user, string password)
        {
            IdentityResult result = await base.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException(String.Join(", ", result.Errors.Select(e => e.Description)));
            }
            return result.Succeeded;
        }
    }
}
