using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ExercicioS10.Models
{
    [Table("Carros")]
    public class CarrosModel

    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [NotNull]
        [Column("NOME")]
        [StringLength(50)]
        public string Nome { get; set; }

        [Column("DATA LOCACAO")]
        [AllowNull]
        public DateTime Datalocacao { get; set; }

        [Column("ID MARCA")]
        [ForeignKey("MarcaModel")]
        public int MarcaId { get; set; }
        public MarcaModel Marca { get; set; }

        

    }
}
