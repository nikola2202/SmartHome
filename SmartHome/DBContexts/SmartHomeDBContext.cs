using SmartHome.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SmartHome.DBContexts
{
    public class SmartHomeDBContext : DbContext
    {
        public SmartHomeDBContext(DbContextOptions<SmartHomeDBContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Home> Homes { get; set; }
        public DbSet<UserHome> UserHomes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserHome>().HasKey(uh => new { uh.UserId, uh.HomeId });

        }
        public DbSet<SmartHome.Models.Device> Device { get; set; }
        public DbSet<SmartHome.Models.DeviceType> DeviceType { get; set; }
        public DbSet<SmartHome.Models.NumberParameter> NumberParameter { get; set; }
        public DbSet<SmartHome.Models.StringParameter> StringParameter { get; set; }
        public DbSet<SmartHome.Models.DeviceParameterCurrentValue> DeviceParameterCurrentValue { get; set; }

        
    }

}
