using Escola.Domain.Entities;
using Escola.Domain.Interfaces;
using Escola.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Infra.Data.Repositories
{
    public class NotaRepository : INotaRepository
    {
        private readonly ApplicationDbContext _context;

        public NotaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Nota> AddAsync(Nota nota)
        {
            _context.Notas.Add(nota);
            await _context.SaveChangesAsync();
            return nota;
        }

        public async Task<List<Nota>> GetAllNotasAsync()
        {
            return await _context.Notas.Where(n => n.Excluido == false).ToListAsync();

        }

        public async Task<Nota> GetNotaByIdAsync(int id)
        {
            return await _context.Notas.FirstOrDefaultAsync(n => n.Id == id && n.Excluido == false);
        }

        public async Task<Nota> UpdateAsync(Nota nota)
        {
            _context.Notas.Update(nota);
            await _context.SaveChangesAsync();
            return nota;
        }
    }
}
