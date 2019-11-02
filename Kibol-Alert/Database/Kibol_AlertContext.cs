using Kibol_Alert.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kibol_Alert.Database
{
    public class Kibol_AlertContext : IdentityDbContext<User>
    {
        public Kibol_AlertContext(DbContextOptions<Kibol_AlertContext> options)
            : base(options)
        {
        }

    }
}
