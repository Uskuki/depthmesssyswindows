using System.Windows;
using depth.Loaders;

namespace depth
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Bootstrapper = new AppBootstrapper();
            this.DataContext = this.Bootstrapper;
        }

        public AppBootstrapper Bootstrapper { get; protected set; }


    }
}
