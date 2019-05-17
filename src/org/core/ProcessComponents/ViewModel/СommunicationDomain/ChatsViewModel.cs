using System;
using System.Collections.Generic;
using System.Reactive;
using System.Windows.Input;
using Entities.CommunicationDomain;
using Infrastructure.ViewModel;
using Infrastructure.ViewModel.СommunicationDomain;
using ReactiveUI;
using ReactiveUI.Legacy;

namespace ProcessComponents.ViewModel.СommunicationDomain
{
    public class ChatsViewModel : ReactiveObject, IChatsViewModel
    {
        private ReactiveCommand<Unit, Unit> _addChatToChatList;

        [Obsolete]
        private IReactiveList<ChatRoom> _chatRooms { get; set; }

        [Obsolete]
        public ChatsViewModel(IScreen hostScreen)
        {
            HostScreen = hostScreen;
            _chatRooms = new ReactiveList<ChatRoom>();
        }

        [Obsolete]
        public IReactiveList<ChatRoom> ChatRooms
        {
            get
            {
                return _chatRooms;
            }
        }

        public string UrlPathSegment
        {
            get
            {
                return "ChatsViewModel";
                
            }
        }

        public IScreen HostScreen { get; }

        [Obsolete]
        public ICommand AddChatToChatList
        {
            get
            {
                if (_addChatToChatList == null)
                {
                    this._addChatToChatList = ReactiveCommand.Create( (Action)(() =>
                    {
                        _chatRooms.Add(new ChatRoom { Name = "Room1" });
                        this.LogingVM();
                    }));
                }

                return _addChatToChatList;
            }
        }

        private void LogingVM()
        {
            Console.WriteLine("Working");
        }
    }
}