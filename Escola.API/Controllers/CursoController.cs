using Escola.Application.DTOs.Curso;
using Escola.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursoController : Controller
    {
        private readonly ICursoService _cursoService;

        public CursoController(ICursoService cursoService)
        {
            this._cursoService = cursoService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateCurso(CursoPostDTO cursoPostDTO)
        {
            var createdCurso = await _cursoService.AddAsync(cursoPostDTO);

            if(createdCurso == null) return BadRequest("Não foi possível criar o curso.");

            return Ok(new { message = "Curso criado com sucesso." });
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCursos()
        {
            var cursos = await _cursoService.GetAllCursosAsync();

            if(cursos == null) return BadRequest("Não foi possível obter os cursos.");

            return Ok(cursos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCursoById(int id)
        {
            var curso = await _cursoService.GetCursoByIdAsync(id);
            if (curso == null) return BadRequest("Não foi possível obter o curso.");
            return Ok(curso);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCurso(CursoPutDTO cursoPutDTO)
        {
            var updatedCurso = await _cursoService.UpdateAsync(cursoPutDTO);
            if (updatedCurso == null) return BadRequest("Não foi possível atualizar o curso.");
            return Ok(new { message = "Curso atualizado com sucesso." } );
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCurso(int id)
        {
            var deletedCurso = await _cursoService.DeleteAsync(id);
            if (deletedCurso == null) return BadRequest("Não foi possível deletar o curso.");
            return Ok(new { message = "Curso deletado com sucesso." });
        }
    }
}
