using System.Collections.Generic;
using System.Threading.Tasks;
using src.Models;

namespace src.Services
{
    public interface IPessoaService
    {
        Task<List<Pessoa>> BuscarTodos();
        Task<Pessoa> BuscarPorId(int id);
        Task<List<Pessoa>> BuscarPorUF(UF uf);
        Task<Pessoa> AdicionarPessoa(Pessoa novaPessoa);
        Task<Pessoa> AtualizarPessoa(Pessoa AtualizarPessoa);
        Task<List<Pessoa>> RemoverPessoa(int id);
    }
}