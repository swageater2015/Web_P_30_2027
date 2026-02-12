using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace hotel
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Hotel_Room> Hotel_Room { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}
