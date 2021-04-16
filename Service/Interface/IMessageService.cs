using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public interface IMessageService
    {
        IEnumerable<DataAccess.Message> GetMessages();
    }
}
