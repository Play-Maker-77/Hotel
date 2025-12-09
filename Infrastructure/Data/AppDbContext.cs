using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Visitor> Visitors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Room>(builder =>
            {
                builder.ToTable("tabRooms");
                builder.Property(r => r.IsAvailable).HasDefaultValue(true);
                builder.HasIndex(r => r.RoomNumber).IsUnique();
                builder.Property(r => r.CreatedAt).HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity<Visitor>(builder =>
            {
                builder.ToTable("tabVisitors");
                builder.Property(v => v.CreatedAt).HasDefaultValueSql("GETDATE()");
            });


        }

    }
}
