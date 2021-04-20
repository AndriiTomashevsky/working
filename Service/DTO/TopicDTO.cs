using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service
{
    public class TopicDTO
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int UserId { get; set; }
        public DateTime CreateOn { get; set; }
        public UserDTO User { get; set; }
        public virtual ICollection<MessageDTO> Messages { get; set; }
    }
}
