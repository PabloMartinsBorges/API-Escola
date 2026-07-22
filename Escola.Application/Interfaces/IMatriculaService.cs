using Escola.Application.DTOs.Matricula;
using Escola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Application.Interfaces
{
    public interface IMatriculaService
    {
        public Task<MatriculaGetDTO> GetMatriculaByIdAsync(int id);
        public Task<List<MatriculaGetDTO>> GetAllMatriculasAsync();
        public Task<MatriculaGetDTO> AddAsync(MatriculaPostDTO matriculaDTO);
        public Task<MatriculaGetDTO> UpdateAsync(MatriculaPutDTO matriculaDTO);
        public Task<MatriculaGetDTO> DeleteAsync(int id);
    }
}
