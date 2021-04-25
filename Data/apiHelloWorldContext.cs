using apiHelloWorld.Models;
using Microsoft.EntityFrameworkCore;

namespace apiHelloWorld.Data
{
    public class apiHelloWorldContext : DbContext
    {
        public apiHelloWorldContext(DbContextOptions<apiHelloWorldContext> opt) : base(opt)
        {

        }

        public DbSet<Command> Commands { get; set; }
    }
}