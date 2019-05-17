using System.Collections.Generic;
using System.Windows.Input;
using Entities.CommunicationDomain;
using Infrastructure.ViewModel.СommunicationDomain;

namespace ProcessComponents.ViewModel.СommunicationDomain
{
    public class ChatViewModel : IChatViewModel
    {
        public IList<Message> Messages { get; set; }
        public ICommand SendMessage { get; set; }
    }
}