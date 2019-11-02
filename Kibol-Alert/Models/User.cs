using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kibol_Alert.Models
{
    public class User: IdentityUser
    {
        public int UserId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsBanned { get; set; } = false;

    }
}
