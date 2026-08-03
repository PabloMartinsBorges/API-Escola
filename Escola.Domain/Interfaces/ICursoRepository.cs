using Escola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Domain.Interfaces
{
    public interface ICursoRepository
    {
        //Task - representa uma operação assíncrona que pode retornar um valor no futuro.
        //Curso - representa o tipo de objeto que será retornado pela operação assíncrona.
        //GetCursoByIdAsync - é o nome do método que será implementado na classe que herdar essa interface
        Task<Curso> GetCursoByIdAsync(int id);
        Task<List<Curso>> GetAllCursosAsync();
        Task<Curso> AddAsync(Curso curso);
        Task<Curso> UpdateAsync(Curso curso);
        Task<Curso> DeleteAsync(int id);
    }
}
