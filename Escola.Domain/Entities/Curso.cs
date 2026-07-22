using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Domain.Entities
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        //Collection of Turmas associated with the Curso
        public ICollection<Turma> Turmas { get; set; }

        public bool Excluido { get; set; } // Property to indicate if the course is excluded (soft delete)


    }
}
