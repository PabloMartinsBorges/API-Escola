using Escola.Application.DTOs.Matricula;
using Escola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Application.Interfaces
{
    public interface IMatriculaService
    {
        public Task<MatriculaDetailGetDTO> GetMatriculaByIdAsync(int id);
        public Task<List<MatriculaDetailGetDTO>> GetAllMatriculasAsync();
        public Task<MatriculaGetDTO> AddAsync(MatriculaPostDTO matriculaPostDTO);
        public Task<MatriculaGetDTO> UpdateAsync(MatriculaPutDTO matriculaPutDTO);
        public Task<MatriculaGetDTO> DeleteAsync(int id);
    }
}
