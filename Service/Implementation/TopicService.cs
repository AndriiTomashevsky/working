using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using Repository;

namespace Service
{
    public class TopicService : ITopicService
    {
        IRepository<Topic> topicRepository;
        IRepository<Message> messageRepository;

        public TopicService(IRepository<Topic> topicRepository, IRepository<Message> messageRepository)
        {
            this.topicRepository = topicRepository;
            this.messageRepository = messageRepository;
        }

        public Topic GetTopic(int id)
        {
            return topicRepository.Get(id);
        }

        public IEnumerable<Topic> GetTopics()
        {
            return topicRepository.GetAll();
        }
    }
}
