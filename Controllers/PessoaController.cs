using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using src.Models;
using src.Services;
using Newtonsoft.Json;

namespace src.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {   
        //Injeção de dependencia
        private readonly IPessoaService _pessoaService;
        public PessoaController(IPessoaService pessoaService) => _pessoaService = pessoaService;

        //Rotas
        [Route("BuscarTodos")]
         public async Task<IActionResult> Get() => Ok(await _pessoaService.BuscarTodos());

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id) => Ok(_pessoaService.BuscarPorId(id));

        [HttpGet("{uf}")]
        public async Task<IActionResult> BuscarPorUF(UF uf) => Ok(_pessoaService.BuscarPorUF(uf));
      
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverPessoa(int id) => Ok(_pessoaService.RemoverPessoa(id));

        [HttpPost]
        public async Task<IActionResult> AdicionarPessoa(Pessoa adicionarPessoa)
        {
           
            return Ok(_pessoaService.AdicionarPessoa(adicionarPessoa));
        }
        [HttpPut]
        public async Task<IActionResult> AtualizarPessoa(Pessoa atualizarPessoa) => Ok(_pessoaService.AtualizarPessoa(atualizarPessoa));

    }
}