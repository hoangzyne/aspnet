using doanthi.Models;
using Microsoft.EntityFrameworkCore;

namespace doanthi.Data
{
    public class doanthiDBContext : DbContext
    {
        public doanthiDBContext(DbContextOptions<doanthiDBContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Sanpham> Sanphams { get; set; }
        public DbSet<Hoadon> Hoadons { get; set; }
        public DbSet<Khachhang> Khachhangs { get; set; }
        public DbSet<Hoadon_Tinh> hoadon_Tinhs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hoadon_Tinh>()
                .HasOne(h => h.Sanpham)
                .WithMany(t => t.Hoadon_Tinh)
                .HasForeignKey(h => h.Sanpham_id);
        }
    }
}
