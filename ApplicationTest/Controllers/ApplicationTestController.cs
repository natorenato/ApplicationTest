using ApplicationTest.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ApplicationTest.Controllers
{
    public class ApplicationTestController : Controller
    {
        private readonly IViaCepService viaCepService;
        private readonly IEnderecoService enderecoService;

        public ApplicationTestController(IViaCepService viaCepService, IEnderecoService enderecoService)
        {
            this.viaCepService = viaCepService;
            this.enderecoService = enderecoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: ApplicationTest/BuscarCep
        [HttpGet]
        public async Task<ActionResult> BuscarCep(string cep)
        {
            var result = await viaCepService.BuscarCep(cep);

            if (result.Erro)
                return BadRequest("Endereço não encontrado");

            return Ok(result);
        }

        // GET: ApplicationTest/BuscarCep
        [HttpGet]
        public async Task<ActionResult> BuscarEndereco(string cep)
        {
            try
            {
                var result = await enderecoService.GetEndereco(cep);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: ApplicationTest/CadastrarEndereco
        [HttpPost]
        public async Task<ActionResult> CadastrarEndereco(string cep)
        {
            try
            {
                var result = await enderecoService.Cadastrar(cep);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}