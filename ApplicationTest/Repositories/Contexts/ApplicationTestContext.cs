using ApplicationTest.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationTest.Repositories.Contexts
{
    public class ApplicationTestContext : DbContext
    {

        public ApplicationTestContext(DbContextOptions<ApplicationTestContext> options) : base(options)
        {

        }

        public DbSet<Endereco> Enderecos { get; set; }
    }
}