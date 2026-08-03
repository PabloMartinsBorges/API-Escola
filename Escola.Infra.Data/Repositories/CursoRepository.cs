using Escola.Domain.Entities;
using Escola.Domain.Interfaces;
using Escola.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Infra.Data.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        // Implement the methods of ICursoRepository using Entity Framework Core and the ApplicationDbContext
        // Use async methods and proper error handling
        private readonly ApplicationDbContext _context;

        public CursoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Curso> AddAsync(Curso curso)
        {
            _context.Curso.Add(curso);
            await _context.SaveChangesAsync();
            return curso;
        }

        public async Task<Curso> DeleteAsync(int id)
        {
            var curso = await _context.Curso.Where(x => x.Excluido == false && x.Id == id).FirstOrDefaultAsync();

            if(curso == null) {
                return null;
            }
            
            curso.Excluido = true;
            _context.Curso.Update(curso);
            await _context.SaveChangesAsync();
            return curso;

        }

        public async Task<List<Curso>> GetAllCursosAsync()
        {
            return await _context.Curso.Where( x => x.Excluido == false).ToListAsync();
        }

        public async Task<Curso> GetCursoByIdAsync(int id)
        {
            return await _context.Curso.FindAsync(id);
        }

        public async Task<Curso> UpdateAsync(Curso curso)
        {
            _context.Curso.Update(curso);
            await _context.SaveChangesAsync();
            return curso;
        }
    }
}
