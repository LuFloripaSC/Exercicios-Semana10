using Microsoft.EntityFrameworkCore;

namespace ExercicioS10.Models
{
    public class LocacaoContext : DbContext
    {
        public LocacaoContext(DbContextOptions<LocacaoContext> options) : base(options) 
        { }
        public LocacaoContext() { }
        public DbSet<CarrosModel> Carros { get; set; }
        public DbSet<MarcaModel> Marca { get; set; }
    }
}
