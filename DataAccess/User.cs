using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class User : IdentityUser<int>
    {
        public DateTime CreateOn { get; set; }
    }
}
