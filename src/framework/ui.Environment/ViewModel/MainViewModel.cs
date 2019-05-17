namespace ui.Environment.ViewModel
{
    using System.ComponentModel;
    using ReactiveUI;
    public interface IMainViewModel : IReactiveObject, IRoutableViewModel
    {

    }

    public class MainViewModel : ReactiveObject, IMainViewModel, IScreen
    {
        public MainViewModel(IScreen screen)
        {
            HostScreen = screen;
            Router = new RoutingState();
        }

        public string UrlPathSegment
        {
            get
            {
                return "";
            }
        }

        public IScreen HostScreen { get; }

        public RoutingState Router { get; }
    }
}
