﻿using PersonalCare.Application.Validation;
using System.ComponentModel.DataAnnotations;

namespace PersonalCare.Application.Models.Requests.Conta
{
    public class AtualizarContaRequest
    {
        [Obrigatorio]
        public int Id { get; set; }

        [Obrigatorio]
        public string Nome { get; set; }

        [Obrigatorio, EmailAddress]
        public string Email { get; set; }

        [Obrigatorio, Cpf]
        public string Cpf { get; set; }

        public decimal? Altura { get; set; }

        public string? Biotipo { get; set; }

        [Obrigatorio]
        public DateTime DataNascimento { get; set; }
    }
}
