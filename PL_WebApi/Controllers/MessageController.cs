using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace PL_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MessageController : ControllerBase
    {
        readonly ITopicService topicService;
        readonly IMessageService messageService;

        public MessageController(ITopicService topicService, IMessageService messageService)
        {
            this.topicService = topicService;
            this.messageService = messageService;
        }

        [HttpGet("{userId}")]
        public List<MessageDTO> Get(int userId)
        {
            return messageService.GetMessages(userId).ToList();
        }

        [HttpPost]
        public IActionResult Create([FromBody] MessageDTO message)
        {
            if (ModelState.IsValid)
            {
                message.CreateOn = DateTime.Now;
                messageService.Add(message);

                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody]MessageDTO messageDTO)
        {
            if (ModelState.IsValid)
            {
                messageService.Update(messageDTO);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, Moderator")]
        public void Delete(int id)
        {
            messageService.Delete(id);
        }
    }
}