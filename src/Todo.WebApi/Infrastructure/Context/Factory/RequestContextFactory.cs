using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Todo.WebApi.Infrastructure.Context.Factory
{
    public class RequestContextFactory
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public RequestContextFactory(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public RequestContext Create()
        {
            var identityContext = CreateIdentityContext();
            return new RequestContext(identityContext);
        }

        private IdentityContext CreateIdentityContext()
        {
            var userContext = CreateUserContext();
            return new IdentityContext(userContext);
        }

        private UserContext CreateUserContext()
        {
            if ((this.httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated).GetValueOrDefault())
            {
                return CreateUser();
            }
            return CreateAnonymous();
        }

        private UserContext CreateUser()
        {
            var userId = new Guid(this.httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "sub").Value);
            var userName = this.httpContextAccessor.HttpContext.User.Identity.Name;
            var roles = GetUserRoles();
            return new UserContext(userId, userName, roles);
        }

        private string[] GetUserRoles()
        {
            return Enumerable.Empty<string>().ToArray();
        }

        private UserContext CreateAnonymous()
        {
            return new UserContext("anonymous");
        }
    }
}
