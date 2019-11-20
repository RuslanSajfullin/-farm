using Microsoft.EntityFrameworkCore;
using SampleWebApiAspNetCore.Entities;

namespace SampleWebApiAspNetCore.Repositories
{
    public class EsiaDbContext : DbContext
    {
        public EsiaDbContext(DbContextOptions<EsiaDbContext> options)
           : base(options)
        {

        }

        public DbSet<EsiaItem> EsiaItems { get; set; }

    }
}
