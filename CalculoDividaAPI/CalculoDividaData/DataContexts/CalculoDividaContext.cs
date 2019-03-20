using Microsoft.EntityFrameworkCore;
using CalculoDividaModel.Models;

namespace CalculoDividaData.DataContexts
{
    public class CalculoDividaContext : DbContext
    {
        public CalculoDividaContext(DbContextOptions<CalculoDividaContext> options)
            : base(options)
        {
        }

        public DbSet<Debito> Debitos { get; set; }
        public DbSet<Parcela> Parcelas { get; set; }
    }

}
