using ProcessComponents.ViewModel.СommunicationDomain;
using ReactiveUI;
using Splat;
using ui.Environment.ViewModel;
using ui.Internal.View;
using VisualComponents.View.CommunicationDomain;
using ProcessComponents.EndLoaders;
using ui.Environment.UserDomain;
using depth.RootEnvironment;
using Autofac;

namespace depth.Loaders
{
    public class AppBootstrapper : ReactiveObject, IScreen
    {
        private NetworkLoader networkLoader;
        private IContainer container;
        public AppBootstrapper(IMutableDependencyResolver dependencyResolver = null, RoutingState testResolver = null)
        {
            this.Router = testResolver ?? new RoutingState();

            dependencyResolver = dependencyResolver ?? Locator.CurrentMutable;

            this.RegisterParts(dependencyResolver);

            this.Router.Navigate.Execute(new ChatsViewModel(this));

            networkLoader = new NetworkLoader();
            networkLoader.autoConnectionDepthServer();

            EnteredUser entered = new EnteredUser();
        }

        private void RegisterParts(IMutableDependencyResolver dependencyResolver)
        {
            var resolver = new AutofacDependencyResolver(container);
            Locator.CurrentMutable.InitializeSplat();
            Locator.CurrentMutable.InitializeReactiveUI();
            
            dependencyResolver.RegisterConstant(this, typeof(IScreen));

            dependencyResolver.Register(() => new MainPageView(), typeof(IViewFor<MainViewModel>));
            dependencyResolver.Register(() => new ChatsView(), typeof(IViewFor<ChatsViewModel>));
        }

        public RoutingState Router { get; }
    }
}