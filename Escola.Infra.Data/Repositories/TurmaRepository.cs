using Escola.Domain.Entities;
using Escola.Domain.Interfaces;
using Escola.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Infra.Data.Repositories
{
    public class TurmaRepository : ITurmaRepository
    {
        private readonly ApplicationDbContext _context;

        public TurmaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Turma> AddAsync(Turma turma)
        {
            _context.Turma.Add(turma);
            await _context.SaveChangesAsync();
            return turma;
        }

        public async Task<Turma> DeleteAsync(int id)
        {
            var turma = await _context.Turma.Where(t => !t.Excluido && t.Id == id).FirstOrDefaultAsync();

            if (turma == null) return null;

            turma.Excluido = true;

            _context.Update(turma);

            await _context.SaveChangesAsync();

            return turma;


        }

        public async Task<List<Turma>> GetAllTurmasAsync()
        {
            return await _context.Turma.Include(x => x.Curso).Where(t => !t.Excluido).ToListAsync();

        }

        public async Task<Turma> GetTurmaByIdAsync(int id)
        {
            //Problema: Quando a entidade é carregada com o AsNoTracking, o EF Core não rastreia as alterações feitas na entidade. Isso significa que, se você modificar a entidade e tentar salvar as alterações no banco de dados, o EF Core não saberá que a entidade foi modificada e não aplicará as alterações.
            //O EF core estava salvando a entidade em memómria, então ocorria um erro ao tentar atualizar a entidade, pois o EF core não estava rastreando a entidade carregada.
            //_context.Turma.AsNoTracking() .FirstOrDefaultAsync(t => t.Id == id);

            //Utilizar .AsNoTracking() é útil quando você deseja apenas ler dados do banco de dados sem a intenção de modificá-los. Isso pode melhorar o desempenho, pois o EF Core não precisa rastrear as alterações na entidade. No entanto, se você pretende modificar a entidade e salvar as alterações, não deve usar .AsNoTracking(), pois isso impede que o EF Core rastreie as alterações feitas na entidade.
            return await _context.Turma.Include(x => x.Curso).Where(t => !t.Excluido && t.Id == id).FirstOrDefaultAsync();           
        }

      

        public async Task<Turma> UpdateAsync(Turma turma)
        {    
            _context.Turma.Update(turma);
            await _context.SaveChangesAsync();
            return turma;
        }
    }
}
