using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Domain.Context
{
    public interface IPipelineContext
    {
        IIdentityContext Identity { get; }

        IContextScope Scope { get; }
    }
}
