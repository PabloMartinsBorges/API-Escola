using Escola.API.Erros;
using Escola.Application.DTOs.Matricula;
using Escola.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatriculaController : Controller
    {
        private readonly IMatriculaService _matriculaService;
        public MatriculaController(IMatriculaService matriculaService)
        {
            _matriculaService = matriculaService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllMatriculas()
        {
            var matriculas = await _matriculaService.GetAllMatriculasAsync();
            return Ok(matriculas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetMatriculaById(int id)
        {
            var matricula = await _matriculaService.GetMatriculaByIdAsync(id);
            return Ok(matricula);
        }

        [HttpPost]
        public async Task<ActionResult> CreateMatricula(MatriculaPostDTO matriculaPostDTO)
        {
            var createdMatricula = await _matriculaService.AddAsync(matriculaPostDTO);
            return Ok(new { message = "Matrícula criada com sucesso." });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMatricula(MatriculaPutDTO matriculaPutDTO)
        {
            var updatedMatricula = await _matriculaService.UpdateAsync(matriculaPutDTO);
            return Ok(new { message = "Matrícula atualizada com sucesso." });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMatricula(int id)
        {
            var deletedMatricula = await _matriculaService.DeleteAsync(id);
            return Ok(new { message = "Matrícula excluída com sucesso." });
        }
    }
}
