using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DataAccess;
using Repository;

namespace Service
{
    public class TopicService : ITopicService
    {
        IUnitOfWork unitOfWork;
        IMapper mapper;

        public TopicService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public void Add(TopicDTO topicDTO)
        {
            unitOfWork.Topics.Add(mapper.Map<Topic>(topicDTO));
        }

        public void Delete(int id)
        {
            unitOfWork.Topics.Remove(id);
        }

        public TopicDTO GetTopic(int id, bool related = true)
        {
            Topic topic;

            topic = unitOfWork.Topics.Get(id, related);

            return mapper.Map<TopicDTO>(topic);
        }

        public IEnumerable<TopicDTO> GetTopics()
        {
            var topics = unitOfWork.Topics.GetAll();

            return mapper.Map<IEnumerable<TopicDTO>>(topics);
        }

        public void Update(TopicDTO topicDTO)
        {
            Topic topic = unitOfWork.Topics.Get(topicDTO.Id, false);

            if (topic != null)
            {
                topic.Title = topicDTO.Title;
                topic.Description = topicDTO.Description;
                unitOfWork.Topics.Update(topic);
            }
        }
    }
}
