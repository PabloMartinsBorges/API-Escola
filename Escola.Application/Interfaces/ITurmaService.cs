using Escola.Application.DTOs.Turma;
using Escola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Application.Interfaces
{
    public interface ITurmaService
    {
        Task<TurmaGetDTO> GetTurmaByIdAsync(int id);
        Task<List<TurmaGetDTO>> GetAllTurmasAsync();
        Task<TurmaGetDTO> AddAsync(TurmaPostDTO turmaDTO);
        Task<TurmaGetDTO> UpdateAsync(TurmaPutDTO turmaDTO);
        Task<TurmaGetDTO> DeleteAsync(int id);
    }
}
