using Literator.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Literator.Data
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options) { }

        public DbSet<Book> Book { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Gender> gender { get; set; }
        public DbSet<Role> role { get; set; }
        public DbSet<AuthorizationData> authdata { get; set; }
        public DbSet<Cart> Cart { get; set; }
    }
}
