using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace PL_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        readonly ITopicService topicService;
        readonly IMessageService messageService;

        public TopicController(ITopicService topicService, IMessageService messageService)
        {
            this.topicService = topicService;
            this.messageService = messageService;
        }

        public List<Topic> Get()
        {
            return topicService.GetTopics().ToList();
        }
    }
}