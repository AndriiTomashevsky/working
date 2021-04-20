using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        ApplicationContext context;
        TopicRepository topicRepository;
        Repository<Message> messageReposistory;

        bool disposed = false;

        public UnitOfWork(ApplicationContext context)
        {
            this.context = context;
        }

        public TopicRepository Topics
        {
            get
            {
                if (topicRepository == null)
                    topicRepository = new TopicRepository(context);
                return topicRepository;
            }
        }

        public Repository<Message> Messages
        {
            get
            {
                if (messageReposistory == null)
                    messageReposistory = new Repository<Message>(context);
                return messageReposistory;
            }
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }

                disposed = true;
            }
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            throw new NotImplementedException();
        }
    }
}
