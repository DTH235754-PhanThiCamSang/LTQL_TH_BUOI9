
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Configuration;

namespace QuanLyBanHang.Data
{
    public class QLBHDbContextFactory : IDesignTimeDbContextFactory<QLBHDbContext>
    {
        public QLBHDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<QLBHDbContext>();

            // Đọc từ App.config
            var connectionString = ConfigurationManager.ConnectionStrings["QLBHConnection"]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'QLBHConnection' not found in App.config");
            }

            optionsBuilder.UseSqlServer(connectionString);

            return new QLBHDbContext(optionsBuilder.Options);
        }
    }
}
