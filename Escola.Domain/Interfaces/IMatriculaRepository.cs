using Escola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Domain.Interfaces
{
    public interface IMatriculaRepository
    {
        public Task<Matricula> GetMatriculaByIdAsync(int id);
        public Task<List<Matricula>> GetAllMatriculasAsync();
        public Task<Matricula> AddAsync(Matricula matricula);
        public Task<Matricula> UpdateAsync(Matricula matricula);
        public Task<Matricula> DeleteAsync(int id);

    }
}
