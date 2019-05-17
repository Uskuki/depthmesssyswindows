using System.Collections.Generic;

namespace Entities.CommunicationDomain
{
    public class Message
    {
        public string UserName { get; set; }
        
        public string Data { get; set; }
        
//        public IList<string> LinksOfPinnedFiles { get; set; }
    }
}