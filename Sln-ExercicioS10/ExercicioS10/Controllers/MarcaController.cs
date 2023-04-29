using ExercicioS10.DTOs;
using ExercicioS10.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExercicioS10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly LocacaoContext _locacaoContext;

        public MarcaController(LocacaoContext _locsacaoContext)
        {
            this._locacaoContext = _locsacaoContext;
        }

        [HttpGet]
        public ActionResult<List<MarcaRequestDTO>> Get()
        {
            var ListMarcaModel = _locacaoContext.Marca;
            List<MarcaRequestDTO> listaRequestDTO = new List<MarcaRequestDTO>();

            foreach (var item in ListMarcaModel)
            {
                var marcaRequestDTO = new MarcaRequestDTO();
                marcaRequestDTO.Codigo = item.id;
                marcaRequestDTO.Nome = item.Nome;

                listaRequestDTO.Add(marcaRequestDTO);
            }

            return Ok(listaRequestDTO);
        }

        [HttpGet("{id}")]
        public ActionResult<MarcaRequestDTO> Get([FromRoute] int id)
        {
            var marcaModel = _locacaoContext.Marca.Where(x => x.id == id).FirstOrDefault();

            if (marcaModel == null)
            {
                return BadRequest("Dados não encontrados no Banco de dados");
            }

            MarcaRequestDTO marcaRequestDTO = new MarcaRequestDTO();
            marcaRequestDTO.Codigo = marcaModel.id;
            marcaRequestDTO.Nome = marcaModel.Nome;

            return Ok(marcaRequestDTO);
        }

        [HttpPost]
        public ActionResult Post([FromBody] MarcaCreateDTO marcaCreateDTO)
        {
            MarcaModel model = new MarcaModel();
            model.Nome = marcaCreateDTO.Nome;
            _locacaoContext.Marca.Add(model);
            _locacaoContext.SaveChanges();
            return Ok(marcaCreateDTO);
        }

        [HttpPut]
        public ActionResult Put([FromBody] MarcaUpdateDTO marcaUpdateDTO)
        {
            var marcaModel = _locacaoContext.Marca.Where(x => x.id == marcaUpdateDTO.Codigo).FirstOrDefault();

            if(marcaModel != null)
            {
                marcaModel.id = marcaUpdateDTO.Codigo;
                marcaModel.Nome = marcaUpdateDTO.Nome;
                _locacaoContext.Marca.Attach(marcaModel);
                _locacaoContext.SaveChanges();
                return Ok(marcaUpdateDTO);
            }

            else
            {
                return BadRequest("Erro ao atualizar o registro");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute]int id)
        {
            var marcaModel = _locacaoContext.Marca.Find(id);

            if (marcaModel != null)
            {
                _locacaoContext.Marca.Remove(marcaModel);

                _locacaoContext.SaveChanges();

                return Ok();
            }

            else
            {
                return BadRequest("Erro ao atualizar o registro");
            }
        }
       
    }
}
