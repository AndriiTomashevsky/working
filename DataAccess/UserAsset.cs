using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class UserAsset : BaseEntity
    {
        public User User { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
