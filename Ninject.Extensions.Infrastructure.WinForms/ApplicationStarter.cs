using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ninject.Extensions.Infrastructure.WinForms.Syntax;

namespace Ninject.Extensions.Infrastructure.WinForms
{
    public class ApplicationStarter : IBootStrappedSyntax
    {
        private readonly IocContainer iocContainer;

        private ApplicationStarter(IocContainer iocContainer)
        {
            this.iocContainer = iocContainer;
        }

        public static IBootStrappedSyntax BootStrapAssembliesMatching(string assemblyScanningAlgorithm)
        {
            return new ApplicationStarter(new IocContainer()).BootStrap(assemblyScanningAlgorithm);
        }

        public static IBootStrappedSyntax BootStrapAssemblies(params string[] assemblies)
        {
            return new ApplicationStarter(new IocContainer()).BootStrap(assemblies);
        }

        public IBootStrappedSyntax FireBeforeEvent(Action @event)
        {
            @event();
            return this;
        }

        public IBootStrappedSyntax FireBeforeEvents(IEnumerable<Action> events)
        {
            foreach (var @event in events) @event();
            return this;
        }

        public IExecutedSyntax AndStartTheFormsRunner()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(iocContainer.Resolver.Get<Form>());
            return this;
        }

        public void FireAfterEvent(Action @event)
        {
            @event();
        }

        public void FireAfterEvents(IEnumerable<Action> events)
        {
            foreach (var @event in events) @event();
        }

        private IBootStrappedSyntax BootStrap(string assemblyScanningAlgorithm)
        {
            iocContainer.WireDependenciesInAssemblyMatching(assemblyScanningAlgorithm);
            return this;
        }

        private IBootStrappedSyntax BootStrap(params string[] assemblies)
        {
            iocContainer.WireDependenciesInAssemblies(assemblies);
            return this;
        }
    }
}