﻿
using ProjetoMvcWeb.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMvcWeb.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do usuário.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o login do usuário.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite o e-mail do usuário.")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é valido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite a senha do usuário.")]
        public string Senha { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAlteracao { get; set; }

        [Required(ErrorMessage = "Digite o perfil do usuário.")]
        public PerfilEnum? Perfil { get; set; }
    }
}
