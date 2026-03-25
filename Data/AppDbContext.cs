using Microsoft.EntityFrameworkCore;
using AutoshkollaAPI.Models;

namespace AutoshkollaAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<AvailableSlot> AvailableSlots { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
    }
}