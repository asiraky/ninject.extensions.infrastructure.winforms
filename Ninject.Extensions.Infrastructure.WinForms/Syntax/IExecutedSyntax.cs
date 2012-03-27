using System;
using System.Collections.Generic;

namespace Ninject.Extensions.Infrastructure.WinForms.Syntax
{
    public interface IExecutedSyntax
    {
        void FireAfterEvent(Action @event);
        void FireAfterEvents(IEnumerable<Action> events);
    }
}