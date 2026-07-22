using Escola.Application.DTOs.Curso;
using Escola.Application.Interfaces;
using Escola.Domain.Entities;
using Escola.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Application.Services
{
    public class CursoService : ICursoService
    {

        public readonly ICursoRepostitory cursoRepostitory;

        public CursoService(ICursoRepostitory cursoRepostitory)
        {
            this.cursoRepostitory = cursoRepostitory;
        }
        public async Task<CursoGetDTO> AddAsync(CursoPostDTO cursoPostDTO)
        {
            var curso = new Curso
            {
                Nome = cursoPostDTO.Nome,
                Descricao = cursoPostDTO.Descricao
            };
            var createdCurso = await cursoRepostitory.AddAsync(curso);

            return new CursoGetDTO
            {
                Id = createdCurso.Id,
                Nome = createdCurso.Nome,
                Descricao = createdCurso.Descricao
            };
        }

        public async Task<CursoGetDTO> DeleteAsync(int id)
        {
            var deletedCurso = await cursoRepostitory.DeleteAsync(id);

            if(deletedCurso == null)
            {
                return null;
            }

            return new CursoGetDTO
            {
                Id = deletedCurso.Id,
                Nome = deletedCurso.Nome,
                Descricao = deletedCurso.Descricao
            };
        }

        public async Task<List<CursoGetDTO>> GetAllCursosAsync()
        {
            var cursos = await cursoRepostitory.GetAllCursosAsync();
            var cursosDTO = cursos.Select(c => new CursoGetDTO
            {
                Id = c.Id,
                Nome = c.Nome,
                Descricao = c.Descricao
            }).ToList();

            return cursosDTO;
        }

        public async Task<CursoGetDTO> GetCursoByIdAsync(int id)
        {
            var curso = await cursoRepostitory.GetCursoByIdAsync(id);
            if (curso == null) return null;

            return new CursoGetDTO
            {
                Id = curso.Id,
                Nome = curso.Nome,
                Descricao = curso.Descricao
            };
        }

        public async Task<CursoGetDTO> UpdateAsync(CursoPutDTO cursoPutDTO)
        {
            if(await cursoRepostitory.GetCursoByIdAsync(cursoPutDTO.Id) == null)
            {
                return null;
            }
            var curso = new Curso
            {
                Id = cursoPutDTO.Id,
                Nome = cursoPutDTO.Nome,
                Descricao = cursoPutDTO.Descricao
            };

            var updatedCurso = await cursoRepostitory.UpdateAsync(curso);

            return new CursoGetDTO
            {
                Id = updatedCurso.Id,
                Nome = updatedCurso.Nome,
                Descricao = updatedCurso.Descricao
            };
        }
    }
}
