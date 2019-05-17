using Infrastructure.ViewModel;
using ReactiveUI;
using System.Windows;
using System.Windows.Controls;
using Infrastructure.ViewModel.СommunicationDomain;

namespace VisualComponents.View.CommunicationDomain
{
    /// <summary>
    /// Interaction logic for ChatsView.xaml
    /// </summary>
    public partial class ChatsView : IViewFor<IChatsViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register("ViewModel",
            typeof(IChatsViewModel), typeof(ChatsView), new PropertyMetadata(default(IChatsViewModel)));

        public ChatsView()
        {
            InitializeComponent();
            this.WhenActivated(d =>
            {
                d(this.OneWayBind(ViewModel, vm => vm.ChatRooms, v => v.Chats.ItemsSource));
                d(this.BindCommand(ViewModel, vm => vm.AddChatToChatList, v => v.AddChatRoom));
            });
        }

        public IChatsViewModel ViewModel
        {
            get { return (IChatsViewModel) this.GetValue(ViewModelProperty); }
            set { this.SetValue(ViewModelProperty, value); }
        }
        object IViewFor.ViewModel
        {
            get
            {
                return this.ViewModel;

            }
            set
            {
                this.ViewModel = (IChatsViewModel) value;

            }
        }
    }
}
