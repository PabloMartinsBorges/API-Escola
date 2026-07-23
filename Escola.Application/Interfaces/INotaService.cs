using Escola.Application.DTOs.Notas;
using Escola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Application.Interfaces
{
    public interface INotaService
    {
        Task<NotaGetDTO> GetNotaByIdAsync(int id);
        Task<List<NotaGetDTO>> GetAllNotasAsync();
        Task<NotaGetDTO> AddAsync(NotaPostDTO notaDTO);

        Task<NotaGetDTO> UpdateAsync(NotaPostDTO notaDTO);
    }
}
