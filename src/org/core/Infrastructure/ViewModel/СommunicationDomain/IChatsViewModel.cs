using System.Collections.Generic;
using System.Windows.Input;
using Entities.CommunicationDomain;
using ReactiveUI;
using ReactiveUI.Legacy;

namespace Infrastructure.ViewModel.СommunicationDomain
{
    public interface IChatsViewModel : IReactiveObject, IRoutableViewModel
    {
        [System.Obsolete]
        IReactiveList<ChatRoom> ChatRooms { get; }

        ICommand AddChatToChatList { get; }
    }
}