using Escola.Application.DTOs.Notas;
using Escola.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotaController : Controller
    {
        private readonly INotaService _notaService;

        public NotaController(INotaService notaService)
        {
            _notaService = notaService;
        }

        [HttpPost]
       public async Task<ActionResult> CreateNota (NotaPostDTO notaPostDTO)
        {
            var createdNota = await _notaService.AddAsync(notaPostDTO);
            
            if(createdNota == null) {
                return BadRequest("Não foi possível criar a nota.");
            }
            return Ok(new { message = "Nota criada com sucesso." } );
        }

        [HttpGet]
        public async Task<ActionResult> GetAllNotas()
        {
            var notas = await _notaService.GetAllNotasAsync();

            if (notas == null)
            {
                return BadRequest("Não foi possível obter as notas.");
            }
            return Ok(notas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetNotaById(int id)
        {
            var nota = await _notaService.GetNotaByIdAsync(id);
            if (nota == null)
            {
                return BadRequest("Não foi possível obter a nota.");
            }
            return Ok(nota);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateNota(NotaPutDTO notaPutDTO)
        {
            var updatedNota = await _notaService.UpdateAsync(notaPutDTO);
            if (updatedNota == null)
            {
                return BadRequest("Não foi possível atualizar a nota.");
            }
            return Ok(new { message = "Nota atualizada com sucesso." });
        }

       
    }
}
