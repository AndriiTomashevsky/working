using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service
{
    public class MessageDTO
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Range(1, int.MaxValue)]
        public int UserId { get; set; }
        [Range(1, int.MaxValue)]
        public int TopicId { get; set; }
        public DateTime CreateOn { get; set; }
        public UserDTO User { get; set; }

    }
}
