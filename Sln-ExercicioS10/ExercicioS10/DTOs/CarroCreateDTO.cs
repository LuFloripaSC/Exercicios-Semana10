namespace ExercicioS10.DTOs
{
    public class CarroCreateDTO
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime DataLocacao { get; set; }

        public int MarcaId { get; set; }
    }
}
