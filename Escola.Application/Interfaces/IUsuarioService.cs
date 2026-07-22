using Escola.Application.DTOs.Usuario;
using Escola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioGetDTO> GetUsuarioByIdAsync(int id);
        Task<List<UsuarioGetDTO>> GetAllUsuariosAsync();
        Task<UsuarioGetDTO> AddAsync(UsuarioPostDTO usuarioDTO);
        Task<UsuarioGetDTO> UpdateAsync(UsuarioPutDTO usuarioDTO);
        Task<UsuarioGetDTO> DeleteAsync(int id);
    }
}
