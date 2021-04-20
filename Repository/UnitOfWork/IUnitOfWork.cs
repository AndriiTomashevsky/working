using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface IUnitOfWork : IDisposable
    {
        TopicRepository Topics { get; }
        Repository<Message> Messages { get; }
    }
}
