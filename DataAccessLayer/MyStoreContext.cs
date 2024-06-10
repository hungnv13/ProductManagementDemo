using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class MyStoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Chuỗi kết nối đến cơ sở dữ liệu của bạn
            optionsBuilder.UseSqlServer("Server=DESKTOP-3IC20SU\\HUNGNV13;Database=MyStore;User Id=sa;Password=123;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cấu hình các thực thể nếu cần thiết
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            // Cấu hình các thực thể khác nếu cần thiết
        }

        // Phương thức để lấy danh sách sản phẩm
        public List<Product> GetProducts()
        {
            using (var context = new MyStoreContext())
            {
                return context.Products.Include(p => p.Category).ToList();
            }
        }
    }
}
