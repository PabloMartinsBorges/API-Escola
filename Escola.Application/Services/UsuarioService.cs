using Escola.Application.DTOs.Usuario;
using Escola.Application.Exceptions;
using Escola.Application.Interfaces;
using Escola.Domain.Entities;
using Escola.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Escola.Application.Services
{
    public class UsuarioService: IUsuarioService
    {
        public readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            this._usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioGetDTO> AddAsync(UsuarioPostDTO usuarioPostDTO)
        {
            using var hmac = new HMACSHA512();

            byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(usuarioPostDTO.Senha));
            byte[] passwordSalt = hmac.Key;

            var usuario = new Usuario
            {
                Nome = usuarioPostDTO.Nome,
                Email = usuarioPostDTO.Email,
                Excluido = false,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Perfil = "Aluno"
            };

            var createdUsuario = await _usuarioRepository.AddAsync(usuario);

            return new UsuarioGetDTO
            {
                Id = createdUsuario.Id,
                Nome = createdUsuario.Nome,
                Email = createdUsuario.Email
            };


        }

        public async Task<UsuarioGetDTO> DeleteAsync(int id)
        {
            var deletedUsuario = await _usuarioRepository.DeleteAsync(id);

            if (deletedUsuario == null) throw new NotFoundException($"Usuário não encontrado.");
            return new UsuarioGetDTO
            {
                Id = deletedUsuario.Id,
                Nome = deletedUsuario.Nome,
                Email = deletedUsuario.Email
            };
        }

        public async Task<List<UsuarioGetDTO>> GetAllUsuariosAsync()
        {
            var usuarios = await _usuarioRepository.GetAllUsuariosAsync();

            var usuariosGetDTO = usuarios.Select(usuario => new UsuarioGetDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email
            }).ToList();

            return usuariosGetDTO;
        }

        public async Task<UsuarioGetDTO> GetUsuarioByIdAsync(int id)
        {
            var usuario = await _usuarioRepository.GetUsuarioByIdAsync(id);

            if (usuario == null) throw new NotFoundException($"Usuário não encontrado.");

            return new UsuarioGetDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email
            };
        }

        public async Task<UsuarioGetDTO> UpdateAsync(int usuarioId, UsuarioPutDTO usuarioPutDTO)
        {
            var usuario = await _usuarioRepository.GetUsuarioByIdAsync(usuarioId);

            if (usuario == null) throw new NotFoundException($"Usuário não encontrado.");

            usuario.Nome = usuarioPutDTO.Nome;
            usuario.Email = usuarioPutDTO.Email;

            var updatedUsuario = await _usuarioRepository.UpdateAsync(usuario);

            return new UsuarioGetDTO
            {
                Id = updatedUsuario.Id,
                Nome = updatedUsuario.Nome,
                Email = updatedUsuario.Email
            };
        }
    }
}
