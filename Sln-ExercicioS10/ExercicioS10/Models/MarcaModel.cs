using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ExercicioS10.Models
{
    [Table("Marcas")]
    public class MarcaModel
    {
        [Key]
        [Column("ID")]
        public int id { get; set; }

        [Column("NOME")]
        [NotNull] 
        public string Nome { get; set; }
    }
}
