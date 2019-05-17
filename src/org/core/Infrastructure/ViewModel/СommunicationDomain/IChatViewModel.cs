using System.Collections.Generic;
using System.Windows.Input;
using Entities.CommunicationDomain;

namespace Infrastructure.ViewModel.СommunicationDomain
{
    public interface IChatViewModel
    {
        IList<Message> Messages { get; set; }
        
        ICommand SendMessage { get; set; }
    }
}