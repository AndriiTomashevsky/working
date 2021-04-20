using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;

namespace Service
{
    public interface ITopicService
    {
        IEnumerable<TopicDTO> GetTopics();
        TopicDTO GetTopic(int id, bool related = true);
        void Add(TopicDTO topic);
        void Update(TopicDTO topicDTO);
        void Delete(int id);
    }
}
