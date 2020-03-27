using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using src.Models;
using System;
using src.DTO;

namespace src.Services
{
    public class PessoaService : IPessoaService
    {

        public async Task<List<Pessoa>> BuscarTodos() => pessoas;
       
        public async Task<Pessoa> BuscarPorId(int id) => pessoas.FirstOrDefault(c => c.Id == id);

        public async Task<Pessoa> AdicionarPessoa(AdicionarPessoaDTO novaPessoaDTO)
        {           
            Pessoa novapessoa = new Pessoa();
            novapessoa.Id = pessoas.Max(c => c.Id) + 1;
            novapessoa.Nome = novaPessoaDTO.Nome;
            novapessoa.CPF = novaPessoaDTO.CPF;
            novapessoa.DataNascimento = novaPessoaDTO.DataNascimento;
            novapessoa.UF = novaPessoaDTO.UF;
            pessoas.Add(novapessoa);

            return novapessoa;
        }

        public async Task<Pessoa> AtualizarPessoa(AtualizarPessoaDTO AtualizarPessoa)
        {
            Pessoa pessoa = pessoas.FirstOrDefault(p => p.Id == AtualizarPessoa.Id);

            //Null Propagation Operator
            pessoa.Nome = AtualizarPessoa.Nome ?? pessoa.Nome;
            pessoa.CPF = AtualizarPessoa.CPF ?? pessoa.CPF;
            pessoa.DataNascimento = AtualizarPessoa.DataNascimento ?? pessoa.DataNascimento;
            pessoa.UF = AtualizarPessoa.UF ?? pessoa.UF;
            return pessoa;
        }

         public async Task<List<Pessoa>> BuscarPorUF(UF uf)
         {     
            var pessoas = new List<Pessoa>();
            pessoas.Where(p => p.UF == uf).ToList();
            return pessoas;
        }

        public async Task<List<Pessoa>> RemoverPessoa(int id)
        {
            Pessoa pessoa = pessoas.FirstOrDefault(p => p.Id == id);
            pessoas.Remove(pessoa);
            return pessoas;
        }

        private static List<Pessoa> pessoas = new List<Pessoa>

        {
            
            new Pessoa {Id = 1, Nome = "Lucas", CPF = "51113132132", DataNascimento = new System.DateTime(day: 12, month: 6, year: 1996), UF = UF.Acre},
            new Pessoa {Id = 2, Nome = "Luciana", CPF = "67465645621", DataNascimento = new System.DateTime(day: 12, month: 5, year: 1986), UF= UF.Alagoas},
            new Pessoa {Id = 3, Nome = "Luciano", CPF = "67125645621", DataNascimento = new System.DateTime(day: 30, month: 10, year: 1994), UF= UF.Tocantins}
            
        };
    }
}