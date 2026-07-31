using Escola.Domain;
using Escola.Domain.Entities;
using Escola.Domain.Interfaces;
using Escola.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Infra.Data.Repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {

        private readonly ApplicationDbContext _context;

        public MatriculaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    
        public async Task<Matricula> AddAsync(Matricula matricula)
        {
            _context.Matricula.Add(matricula);
            await _context.SaveChangesAsync();
            return matricula;
        }

        public async Task<Matricula> DeleteAsync(int id)
        {
            var matricula = _context.Matricula.Where(m => m.Excluido==false && m.Id == id).FirstOrDefault();

            if (matricula != null) return null;

            matricula.Excluido = true;
            _context.Update(matricula);

            await _context.SaveChangesAsync();

            return matricula;


        }


        public async Task<List<Matricula>> GetAllMatriculasAsync()
        {
            return await _context.Matricula.Include(m=>m.Usuario).Include(m => m.Turma).Where(m => m.Excluido == false).ToListAsync();
        }

        public async Task<Matricula> GetMatriculaByIdAsync(int id)
        {
            return await _context.Matricula.Include(m => m.Usuario).Include(m => m.Turma).Where(m => !m.Excluido && m.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Matricula> UpdateAsync(Matricula matricula)
        {
            _context.Matricula.Update(matricula);
            await _context.SaveChangesAsync();
            return matricula;
        }
    }
}
