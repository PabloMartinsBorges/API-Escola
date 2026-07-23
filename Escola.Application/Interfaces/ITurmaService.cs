using Escola.Application.DTOs.Turma;
using Escola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Application.Interfaces
{
    public interface ITurmaService
    {
        Task<TurmaDetailGetDTO> GetTurmaByIdAsync(int id);
        Task<List<TurmaDetailGetDTO>> GetAllTurmasAsync();
        Task<TurmaGetDTO> AddAsync(TurmaPostDTO turmaPostDTO);
        Task<TurmaGetDTO> UpdateAsync(TurmaPutDTO turmaPutDTO);
        Task<TurmaGetDTO> DeleteAsync(int id);
    }
}
