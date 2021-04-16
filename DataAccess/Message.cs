using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class Message : BaseEntity
    {
        public string Text { get; set; }

        public Topic Topic { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public int TopicId { get; set; }
    }
}
