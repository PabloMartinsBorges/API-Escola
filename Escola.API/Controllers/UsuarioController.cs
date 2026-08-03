using Escola.Application.DTOs.Usuario;
using Escola.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateUsuario(UsuarioPostDTO usuarioPostDTO)
        {
            var createdUsuario = await usuarioService.AddAsync(usuarioPostDTO);
            if (createdUsuario == null) return BadRequest("Não foi possível criar o usuário.");
            return Ok(new { message = "Usuário criado com sucesso." });
        }


        [HttpGet]
        public async Task<ActionResult> GetAllUsuarios()
        {
            var usuarios = await usuarioService.GetAllUsuariosAsync();
            if (usuarios == null) return BadRequest("Não foi possível obter os usuários.");
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUsuarioById(int id)
        {
            var usuario = await usuarioService.GetUsuarioByIdAsync(id);
            if (usuario == null) return BadRequest("Não foi possível obter o usuário.");
            return Ok(usuario);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUsuario(int idUsuario, UsuarioPutDTO usuarioPutDTO)
        {
            var updatedUsuario = await usuarioService.UpdateAsync(idUsuario, usuarioPutDTO);
            if (updatedUsuario == null) return BadRequest("Não foi possível atualizar o usuário.");
            return Ok(new { message = "Usuário atualizado com sucesso." });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUsuario(int id)
        {
            var deletedUsuario = await usuarioService.DeleteAsync(id);
            if (deletedUsuario == null) return BadRequest("Não foi possível deletar o usuário.");
            return Ok(new { message = "Usuário deletado com sucesso." });
        }
    }
}
