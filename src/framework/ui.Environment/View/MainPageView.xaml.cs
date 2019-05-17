using ReactiveUI;
using System.Windows;
using ui.Environment.ViewModel;

namespace ui.Internal.View
{
    /// <summary>
    /// Interaction logic for MainPageView.xaml
    /// </summary>
    public partial class MainPageView : IViewFor<IMainViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register("ViewModel",
            typeof(IMainViewModel), typeof(MainPageView), new PropertyMetadata(default(IMainViewModel)));

        public MainPageView()
        {
            InitializeComponent();
        }

        object IViewFor.ViewModel
        {
            get
            {
                return this.ViewModel;
            }
            set
            {
                this.ViewModel = (IMainViewModel)value;
            }
        }

        public IMainViewModel ViewModel
        {
            get { return (IMainViewModel)this.GetValue(ViewModelProperty); }
            set
            {
                this.SetValue(ViewModelProperty, value);
            }
        }
    }
}
