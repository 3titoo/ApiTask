using ApiTask.identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiTask.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class appDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public appDbContext(DbContextOptions<appDbContext> options) : base(options)
        {
            
        }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Order> Orders { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
