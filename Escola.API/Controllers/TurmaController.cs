using Escola.Application.DTOs.Turma;
using Escola.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TurmaController : Controller
    {
        private readonly ITurmaService _turmaService;

        public TurmaController(ITurmaService turmaService)
        {
            _turmaService = turmaService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateTurma(TurmaPostDTO turmaPostDTO)
        {
            var createdTurma = await _turmaService.AddAsync(turmaPostDTO);

            if (createdTurma == null) return BadRequest("Não foi possível incluir a turma");


            return Ok(new { message = "Turma criada com sucesso!" });
        }

        [HttpPut]
        public async Task<ActionResult> UpdateTurma(TurmaPutDTO turmaPutDTO)
        {
            var updatedTurma = await _turmaService.UpdateAsync(turmaPutDTO);

            if (updatedTurma == null) return BadRequest("Não foi possível atualizar a turma");

            return Ok(new { message = "Turma atualizada com sucesso!" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTurma(int id)
        {
            var deletedTurma = await _turmaService.DeleteAsync(id);

            if (deletedTurma == null) return BadRequest("Não foi possível excluir a turma");

            return Ok(new { message = "Turma excluída com sucesso!" });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTurmaById(int id)
        {
            var turma = await _turmaService.GetTurmaByIdAsync(id);

            if (turma == null) return BadRequest("Turma não encontrada");

            return Ok(turma);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTurma()
        {
            var turmas = await _turmaService.GetAllTurmasAsync();

            if (turmas == null) return NotFound("Nenhuma turma encontrada");

            return Ok(turmas);
        }
    }
}
