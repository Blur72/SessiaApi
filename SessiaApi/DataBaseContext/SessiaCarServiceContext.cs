using Microsoft.EntityFrameworkCore;
using SessiaApi.Model;

namespace SessiaApi.DataBaseContext
{
    public class SessiaCarServiceContext : DbContext
    {
        public SessiaCarServiceContext(DbContextOptions<SessiaCarServiceContext> options) : base(options) { }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<RepairRequest> RepairRequests { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<RepairPart> RepairParts { get; set; }
        public DbSet<RepairReport> RepairReports { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<RepairRequestStatusHistory> RepairRequestStatusHistories { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cars -> Users (OwnerId)
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Owner)
                .WithMany()
                .HasForeignKey(c => c.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            // RepairRequest -> Users (ClientId, ManagerId, MasterId)
            modelBuilder.Entity<RepairRequest>()
                .HasOne(r => r.Client)
                .WithMany()
                .HasForeignKey(r => r.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RepairRequest>()
                .HasOne(r => r.Manager)
                .WithMany()
                .HasForeignKey(r => r.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RepairRequest>()
                .HasOne(r => r.Master)
                .WithMany()
                .HasForeignKey(r => r.MasterId)
                .OnDelete(DeleteBehavior.Restrict);

            // RepairReport -> Users (MasterId)
            modelBuilder.Entity<RepairReport>()
                .HasOne(r => r.Master)
                .WithMany()
                .HasForeignKey(r => r.MasterId)
                .OnDelete(DeleteBehavior.Restrict);

            // ChatMessage -> Users (SenderId)
            modelBuilder.Entity<ChatMessage>()
                .HasOne(m => m.Sender)
                .WithMany()
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RepairRequestStatusHistory>()
                .HasOne(h => h.RepairRequest)
                .WithMany()
                .HasForeignKey(h => h.RepairRequestId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RepairRequestStatusHistory>()
                .HasOne(h => h.ChangedBy)
                .WithMany()
                .HasForeignKey(h => h.ChangedById)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
} 