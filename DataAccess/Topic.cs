using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class Topic : BaseEntity
    {
        public string Title { get; set; }
        public string UserId { get; set; }

        public User User { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
