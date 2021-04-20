using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;

namespace Service
{
    public interface IMessageService
    {
        IEnumerable<MessageDTO> GetMessages(int userId);
        void Add(MessageDTO message);
        void Update(MessageDTO messageDTO);
        void Delete(int id);
    }
}
