using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class User : IdentityUser
    {
        public virtual ICollection<Topic> Topics { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
