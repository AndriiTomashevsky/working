using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using Repository;

namespace Service
{
    public class MessageService : IMessageService
    {
        IRepository<Message> messageRepository;

        public MessageService(IRepository<Message> messageRepository)
        {
            this.messageRepository = messageRepository;
        }

        public IEnumerable<Message> GetMessages()
        {
            return messageRepository.GetAll();
        }
    }
}
