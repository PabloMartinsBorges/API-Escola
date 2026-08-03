using Escola.Application.DTOs.Matricula;
using Escola.Application.DTOs.Turma;
using Escola.Application.DTOs.Usuario;
using Escola.Application.Exceptions;
using Escola.Application.Interfaces;
using Escola.Domain.Entities;
using Escola.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Application.Services
{
    public class MatriculaService : IMatriculaService
    {
        public readonly IMatriculaRepository _matriculaRepository;
        public readonly ITurmaRepository _turmaRepository;
        public readonly IUsuarioRepository _usuarioRepository;

        public MatriculaService(IMatriculaRepository matriculaRepository, ITurmaRepository turmaRepository, IUsuarioRepository usuarioRepository)
        {
            _matriculaRepository = matriculaRepository;
            _turmaRepository = turmaRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<MatriculaGetDTO> AddAsync(MatriculaPostDTO matriculaPostDTO)
        {
            if(await _usuarioRepository.GetUsuarioByIdAsync(matriculaPostDTO.UsuarioId) == null)
            {
                throw new NotFoundException($"Usuário não existe.");
            }

            if(await _turmaRepository.GetTurmaByIdAsync(matriculaPostDTO.TurmaId) == null)
            {
                throw new NotFoundException($"Turma não existe.");
            }

            var matricula = new Matricula
            {
                UsuarioId = matriculaPostDTO.UsuarioId,
                TurmaId = matriculaPostDTO.TurmaId,
                DataMatricula = DateTime.UtcNow,
                DataExpiracao = matriculaPostDTO.DataExpiracao,
                Ativa = true
            };
            var createdMatricula = await _matriculaRepository.AddAsync(matricula);
            return new MatriculaGetDTO
            {
                Id = createdMatricula.Id,
                UsuarioId = createdMatricula.UsuarioId,
                TurmaId = createdMatricula.TurmaId,
                DataMatricula = createdMatricula.DataMatricula,
                DataExpiracao = createdMatricula.DataExpiracao,
                Ativa = createdMatricula.Ativa
            };
        }

        public async Task<MatriculaGetDTO> DeleteAsync(int id)
        {
            var deletedMatricula = await _matriculaRepository.DeleteAsync(id);
            if (deletedMatricula == null) throw new NotFoundException($"Matrícula não encontrada.");

            return new MatriculaGetDTO
            {
                Id = deletedMatricula.Id,
                UsuarioId = deletedMatricula.UsuarioId,
                TurmaId = deletedMatricula.TurmaId,
                DataMatricula = deletedMatricula.DataMatricula,
                DataExpiracao = deletedMatricula.DataExpiracao,
                Ativa = deletedMatricula.Ativa
            };
        }

        public async Task<List<MatriculaDetailGetDTO>> GetAllMatriculasAsync()
        {
            var matriculas = await _matriculaRepository.GetAllMatriculasAsync();

            var matriculasDTO = matriculas.Select(m => new MatriculaDetailGetDTO
            {
                Id = m.Id,
                Usuario = new UsuarioGetDTO
                {
                    Id = m.Usuario.Id,
                    Nome = m.Usuario.Nome,
                    Email = m.Usuario.Email
                },
                Turma = new TurmaGetDTO
                {
                    Id = m.Turma.Id,
                    Nome = m.Turma.Nome,
                    Descricao = m.Turma.Descricao,

                },
                DataMatricula = m.DataMatricula,
                DataExpiracao = m.DataExpiracao,
                Ativa = m.Ativa
            }).ToList();

            return matriculasDTO;
        }

        public async Task<MatriculaDetailGetDTO> GetMatriculaByIdAsync(int id)
        {
            var matricula = await _matriculaRepository.GetMatriculaByIdAsync(id);

            if (matricula == null) throw new NotFoundException($"Matrícula não encontrada.");

            return new MatriculaDetailGetDTO
            {
                Id = matricula.Id,
                Usuario = new UsuarioGetDTO
                {
                    Id = matricula.Usuario.Id,
                    Nome = matricula.Usuario.Nome,
                    Email = matricula.Usuario.Email
                },
                Turma = new TurmaGetDTO
                {
                    Id = matricula.Turma.Id,
                    Nome = matricula.Turma.Nome,
                    Descricao = matricula.Turma.Descricao
                },
                DataMatricula = matricula.DataMatricula,
                DataExpiracao = matricula.DataExpiracao,
                Ativa = matricula.Ativa
            };
        }


     

        public async Task<MatriculaGetDTO> UpdateAsync(MatriculaPutDTO matriculaDTO)
        {

            var matricula = await _matriculaRepository.GetMatriculaByIdAsync(matriculaDTO.Id);
            if (matricula == null)
            {
                throw new NotFoundException($"Matrícula não encontrada.");
            }



            matricula.Id = matriculaDTO.Id;
            matricula.TurmaId = matriculaDTO.TurmaId;
            matricula.DataExpiracao = matriculaDTO.DataExpiracao;

            var updatedMatricula = await _matriculaRepository.UpdateAsync(matricula);

            return new MatriculaGetDTO
            {
                Id = updatedMatricula.Id,
                UsuarioId = updatedMatricula.UsuarioId,
                TurmaId = updatedMatricula.TurmaId,
                DataMatricula = updatedMatricula.DataMatricula,
                DataExpiracao = updatedMatricula.DataExpiracao,
                Ativa = updatedMatricula.Ativa
            };
        }

        
    }
}
