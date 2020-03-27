using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using src.Models;
using src.Services;
using src.DTO;

namespace src.Controllers
{
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
        public async Task<IActionResult> BuscarPorId(int id) => Ok(await _pessoaService.BuscarPorId(id));

        [HttpGet("{uf}")]
        public async Task<IActionResult> BuscarPorUF(UF uf) => Ok(await _pessoaService.BuscarPorUF(uf));

        [HttpPost]
        public async Task<IActionResult> AdicionarPessoa([FromBody]AdicionarPessoaDTO adicionarPessoa) => Ok(await _pessoaService.AdicionarPessoa(adicionarPessoa));
        
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarPessoa(int id,[FromBody]AtualizarPessoaDTO atualizarPessoa)
        {
            atualizarPessoa.Id = id;
            return Ok(await _pessoaService.AtualizarPessoa(atualizarPessoa));
        }
      
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverPessoa(int id) => Ok(await _pessoaService.RemoverPessoa(id));

        
    }
}