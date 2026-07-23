using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Escola.Application.DTOs.Usuario
{
    public class UsuarioPostDTO
    {
        [Required(ErrorMessage = "O nome do usuário é obrigatório")]
        [MaxLength(100, ErrorMessage = "O nome do usuário deve ter no máximo 100 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O email do usuário é obrigatório")]
        [MaxLength(100, ErrorMessage = "O email do usuário deve ter no máximo 100 caracteres")]
        
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha do usuário é obrigatória")]
        [MinLength(8, ErrorMessage = "A senha do usuário deve ter no mínimo 8 caracteres")]
        [MaxLength(100, ErrorMessage = "A senha do usuário deve ter no máximo 100 caracteres")]
        public string Senha { get; set; }
    }
}
