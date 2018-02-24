using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Domain.Context;

namespace Todo.WebApi.Infrastructure.Context
{
    public class RequestContext : IPipelineContext
    {
        public RequestContext(IIdentityContext identity)
        {
            Identity = identity;
        }

        public IIdentityContext Identity { get; }

        public IContextScope Scope { get; } = new ContextScope();
    }
}
