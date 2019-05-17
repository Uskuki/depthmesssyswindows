using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel;
using System.Security.Principal;

namespace ui.Environment.UserDomain
{
   [PartCreationPolicy(CreationPolicy.Shared)]
   public class EnteredUser
   {
       public EnteredUser()
       {
            this.Username = WindowsIdentity.GetCurrent().Name.Split('\\')[1];
       }

       public string Username { get; set; }
   }
}
