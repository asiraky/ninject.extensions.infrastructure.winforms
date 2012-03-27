using System;
using System.Collections.Generic;

namespace Ninject.Extensions.Infrastructure.WinForms.Syntax
{
    public interface IBootStrappedSyntax : IExecutedSyntax
    {
        IBootStrappedSyntax FireBeforeEvent(Action @event);
        IBootStrappedSyntax FireBeforeEvents(IEnumerable<Action> events);
        IExecutedSyntax AndStartTheFormsRunner();
    }
}