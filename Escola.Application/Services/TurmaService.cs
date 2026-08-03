using Escola.Application.DTOs.Curso;
using Escola.Application.DTOs.Turma;
using Escola.Application.Interfaces;
using Escola.Domain.Entities;
using Escola.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Application.Services
{
    public class TurmaService: ITurmaService
    {
        public readonly ITurmaRepository _turmaRepository;
        public readonly ICursoRepository _cursoRepository;

        public TurmaService(ITurmaRepository turmaRepository, ICursoRepository cursoRepository)
        {
            _turmaRepository = turmaRepository;
            _cursoRepository = cursoRepository;
        }

        public async Task<TurmaGetDTO> AddAsync(TurmaPostDTO turmaDTO, CursoGetDTO cursoDTO)
        {
            var curso = await _cursoRepository.GetCursoByIdAsync(cursoDTO.Id);

            if(curso == null)
            {
                throw new Exception($"Curso não encontrado.");
            }

            var turma = new Turma
            {
                Nome = turmaDTO.Nome,
                Descricao = turmaDTO.Descricao,
                CursoId = turmaDTO.CursoId
            };

            var createdTurma = await _turmaRepository.AddAsync(turma);

            return new TurmaGetDTO
            {
                Id = createdTurma.Id,
                Nome = createdTurma.Nome,
                Descricao = createdTurma.Descricao,
                CursoId = createdTurma.CursoId
            };
        }

        public async Task<TurmaGetDTO> DeleteAsync(int id)
        {
            var deletedTurma = await _turmaRepository.DeleteAsync(id);

            if (deletedTurma == null) return null;

            
            return new TurmaGetDTO
            {
                Id = deletedTurma.Id,
                Nome = deletedTurma.Nome,
                Descricao = deletedTurma.Descricao,
                CursoId = deletedTurma.CursoId
            };

        }

        public async Task<TurmaDetailGetDTO> GetTurmaByIdAsync(int id)
        {
            var turma = await _turmaRepository.GetTurmaByIdAsync(id);

            if (turma == null) return null;

            return new TurmaDetailGetDTO
            {
                Id = turma.Id,
                Nome = turma.Nome,
                Descricao = turma.Descricao,
                Curso = new CursoGetDTO
                {
                    Id = turma.Curso.Id,
                    Nome = turma.Curso.Nome,
                    Descricao = turma.Curso.Descricao
                }
            };
        }

        public async Task<List<TurmaDetailGetDTO>> GetAllTurmasAsync()
        {
            var turmas = await _turmaRepository.GetAllTurmasAsync();

            var turmasDTO = turmas.Select(turma => new TurmaDetailGetDTO
            {
                Id = turma.Id,
                Nome = turma.Nome,
                Descricao = turma.Descricao,
                Curso = new CursoGetDTO
                {
                    Id = turma.Curso.Id,
                    Nome = turma.Curso.Nome,
                    Descricao = turma.Curso.Descricao
                }
            }).ToList();
            
            return turmasDTO;
        }



      
        public async Task<TurmaGetDTO> UpdateAsync(TurmaPutDTO turmaDTO)
        {
            // 1. Busca a entidade existente (o EF passa a rastreá-la)
            var turma = await _turmaRepository.GetTurmaByIdAsync(turmaDTO.Id);

            if (turma == null)
            {
                return null;
            }

            // 2. Atualiza as propriedades na própria entidade rastreada
            turma.Nome = turmaDTO.Nome;
            turma.Descricao = turmaDTO.Descricao;
            turma.CursoId = turmaDTO.CursoId;

            // 3. Salva a entidade existente
            var updatedTurma = await _turmaRepository.UpdateAsync(turma);

            return new TurmaGetDTO
            {
                Id = updatedTurma.Id,
                Nome = updatedTurma.Nome,
                Descricao = updatedTurma.Descricao,
                CursoId = updatedTurma.CursoId
            };
        }


    }
}
