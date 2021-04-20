using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class TopicRepository : Repository<Topic>, IRepository<Topic>
    {
        readonly ApplicationContext context;

        public TopicRepository(ApplicationContext context) : base(context)
        {
            this.context = context;
        }

        public override IEnumerable<Topic> GetAll()
        {
            return context.Topics.Include(t => t.User);
        }

        public Topic Get(int id, bool related = true)
        {
            if (related)
            {
                return context.Topics
                    .Include(t => t.User)
                    .Include(t => t.Messages)
                    .ThenInclude(m => m.User)
                    .SingleOrDefault(t => t.Id == id);
            }

            return context.Topics.SingleOrDefault(t => t.Id == id); ;
        }
    }
}
