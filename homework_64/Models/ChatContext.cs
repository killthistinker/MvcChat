using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace homework_64.Models
{
    public class ChatContext : IdentityDbContext<User,Role,int>
    {

        public DbSet<Message> Messages { get; set; }
        public ChatContext(DbContextOptions<ChatContext> options) : base(options)
        {
            
        }
    }
}