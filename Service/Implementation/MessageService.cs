using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DataAccess;
using Repository;

namespace Service
{
    public class MessageService : IMessageService
    {
        IUnitOfWork unitOfWork;
        IMapper mapper;

        public MessageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IEnumerable<MessageDTO> GetMessages(int userId)
        {
            var messages = unitOfWork.Messages.GetAll(m => m.UserId == userId);

            return mapper.Map<IEnumerable<MessageDTO>>(messages);
        }

        public void Add(MessageDTO messageDTO)
        {
            unitOfWork.Messages.Add(mapper.Map<Message>(messageDTO));
        }

        public void Update(MessageDTO messageDTO)
        {
            Message message = unitOfWork.Messages.Get(messageDTO.Id);

            if (message != null)
            {
                message.Text = messageDTO.Text;
                unitOfWork.Messages.Update(message);
            }
        }

        public void Delete(int id)
        {
            unitOfWork.Messages.Remove(id);
        }
    }
}
