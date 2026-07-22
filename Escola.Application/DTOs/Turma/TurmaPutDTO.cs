using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Escola.Application.DTOs.Turma
{
    public class TurmaPutDTO
    {
        [Required(ErrorMessage = "O ID da turma é obrigatório")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome da turma é obrigatório")]
        [MaxLength(100, ErrorMessage = "O nome da turma deve ter no máximo 100 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "A descrição da turma é obrigatória")]
        [MaxLength(500, ErrorMessage = "A descrição da turma deve ter no máximo 500 caracteres")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O curso é obrigatório")]
        public int CursoId { get; set; }
    }
}
