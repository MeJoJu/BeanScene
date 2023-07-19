using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BeanScene2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BeanScene2.Data
{
    public class BeanScene2Context : IdentityDbContext
    {
        public BeanScene2Context (DbContextOptions<BeanScene2Context> options)
            : base(options)
        {
        }

        public DbSet<BeanScene2.Models.Area> Area { get; set; } = default!;

        public DbSet<BeanScene2.Models.Customer> Customer { get; set; } = default!;

        public DbSet<BeanScene2.Models.Permission> Permission { get; set; } = default!;

        public DbSet<BeanScene2.Models.Reservation> Reservation { get; set; } = default!;

        public DbSet<BeanScene2.Models.Sitting> Sitting { get; set; } = default!;

        public DbSet<BeanScene2.Models.Table> Table { get; set; } = default!;

        public DbSet<BeanScene2.Models.User> User { get; set; } = default!;
    }
}
