using System.Collections.Generic;
using System.Threading.Tasks;
using src.DTO;
using src.Models;

namespace src.Services
{
    public interface IPessoaService
    {
        Task<List<Pessoa>> BuscarTodos();
        Task<Pessoa> BuscarPorId(int id);
        Task<List<Pessoa>> BuscarPorUF(UF uf);
        Task<Pessoa> AdicionarPessoa(AdicionarPessoaDTO novaPessoaDTO);
        Task<Pessoa> AtualizarPessoa(AtualizarPessoaDTO AtualizarPessoa);
        Task<List<Pessoa>> RemoverPessoa(int id);
    }
}