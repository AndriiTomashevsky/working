using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public interface ITopicService
    {
        IEnumerable<DataAccess.Topic> GetTopics();
        DataAccess.Topic GetTopic(int id);
    }
}
