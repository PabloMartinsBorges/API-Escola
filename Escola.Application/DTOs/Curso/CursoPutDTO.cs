using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Escola.Application.DTOs.Curso
{
    public class CursoPutDTO
    {
        [Required(ErrorMessage = "O nome do Identificador do Curso é obrigatório.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome do curso é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O nome do curso não pode exceder 50 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição do curso é obrigatória.")]
        [MaxLength(150, ErrorMessage = "A descrição do curso não pode exceder 150 caracteres.")]
        public string Descricao { get; set; }
    }
}
