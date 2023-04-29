using ExercicioS10.DTOs;
using ExercicioS10.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExercicioS10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        private readonly LocacaoContext _locacaoContext;

        public CarroController (LocacaoContext locacaoContext)
        {
            _locacaoContext = locacaoContext;
        }

        [HttpPost]
        public ActionResult<CarroCreateDTO> Post([FromBody] CarroCreateDTO carroDTO)
        { 
            CarrosModel carrosModel = new CarrosModel();
            carrosModel.Datalocacao = carroDTO.DataLocacao;
            carrosModel.Nome = carroDTO.Nome;
            carrosModel.MarcaId = carroDTO.MarcaId;

            var marcaModel = _locacaoContext.Marca.Find(carroDTO.MarcaId);
            if (marcaModel != null)
            { 
                _locacaoContext.Carros.Add(carrosModel);

                _locacaoContext.SaveChanges();

                carroDTO.Id = carrosModel.Id;

                return Ok (carrosModel);
            }

            else
            {
                return BadRequest("Ocorreu um erro ao inserir o carro no Banco de Dados");
            }
        }

        [HttpPut]

        public ActionResult Put([FromBody] CarroUpdateDTO carroUpdateDTO)
        {
            CarrosModel carrosModel = _locacaoContext.Carros.Find(carroUpdateDTO.Id);
            MarcaModel marcaModel = _locacaoContext.Marca.Find(carroUpdateDTO.CodigoMarca);

            if (marcaModel == null) 
            {
                return NotFound("Marca não encontrada");
            }

            if (carrosModel == null)
            {
                return NotFound("Carro não encontrado");
            }

            carrosModel.Id = carroUpdateDTO.Id;
            carrosModel.Nome = carroUpdateDTO.Nome;
            carrosModel.MarcaId = marcaModel.id;

            _locacaoContext.Attach(carrosModel);
            _locacaoContext.SaveChanges ();

            return Ok("Carro atualizado");
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            CarrosModel carrosModel = _locacaoContext.Carros.Find (id);

            if (carrosModel != null)
            {
                _locacaoContext.Remove(carrosModel);
                _locacaoContext.SaveChanges ();

                return Ok("Carro removido");
            }

            return BadRequest("Carro não cadastrado");
        }

        [HttpGet]
        public ActionResult<List<CarroRequestDTO>> Get()
        {
            var ListCarrosModel = _locacaoContext.Carros;

            List<CarroRequestDTO> listaRequestDTO = new List<CarroRequestDTO> ();

            foreach (var item in ListCarrosModel)
            {
                var carroRequestDTO = new CarroRequestDTO ();
                carroRequestDTO.Id = item.Id;
                carroRequestDTO.Nome = item.Nome;

                listaRequestDTO.Add (carroRequestDTO);
            }

            return Ok(listaRequestDTO);
        }

        [HttpGet("{id}")]

        public ActionResult<CarroRequestDTO> Get([FromRoute] int id)
        {
            var carrosModel = _locacaoContext.Carros.Where(x => x.Id == id).FirstOrDefault();

            if (carrosModel == null)
            {
                return BadRequest("Dados não encontrados no Banco de dados");
            }

            CarroRequestDTO carroRequestDTO = new CarroRequestDTO ();
            carroRequestDTO.Id = id;
            carroRequestDTO.Nome = carrosModel.Nome;
            return Ok(carroRequestDTO);
        }

    }
}
