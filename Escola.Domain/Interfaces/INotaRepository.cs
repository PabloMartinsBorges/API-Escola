using Escola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Domain.Interfaces
{
    public interface INotaRepository
    {
        Task<Nota> GetNotaByIdAsync(int id);
        Task<List<Nota>> GetAllNotasAsync();
        Task<Nota> AddAsync(Nota nota);

    }
}
