using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace depth.RootEnvironment
{
    public class AutofacDependencyRestrator
    {
        protected IContainer Container;

        public AutofacDependencyRestrator(IContainer container)
        {
            Container = container;
            RegisterViews();
            RegisterViewModels();
            RegisterServices();
            RegisterScreen();
        }

        public void RegisterViews() { }

        public void RegisterViewModels() { }

        public void RegisterServices() { }

        public void RegisterScreen() { }
    }
}
