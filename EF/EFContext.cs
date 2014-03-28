using System.Data.Entity;
using EF.Entities;

namespace EF
{
    public class EFContext : DbContext
    {
        public DbSet<CurrencyEF> Currencies { get; set; }
    }
}
