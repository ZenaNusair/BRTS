using BRTS_System.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BRTS_System.Date
{
    public class SystemDbContext : DbContext
    {
        public SystemDbContext(DbContextOptions options) : base(options)
        {
        }
        //user
        public DbSet<User> user { set; get; }
        public DbSet<Bus> bus { set; get; }
        public DbSet<Trip> trip { set; get; }
        public DbSet<Admin> admin { set; get; }


        public DbSet<User_Trip> user_trip { set; get; }




    }
}
