using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Escola.Application.DTOs.Curso
{
    public class CursoPostDTO
    {
        [Required(ErrorMessage = "O nome do curso é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O nome do curso não pode exceder 50 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição do curso é obrigatória.")]
        [MaxLength(150, ErrorMessage = "A descrição do curso não pode exceder 150 caracteres.")]
        public string Descricao { get; set; }
    }
}
