using System;
using src.Models;

namespace src.DTO
{
    public class AdicionarPessoaDTO
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public UF UF { get; set; }
    }
}