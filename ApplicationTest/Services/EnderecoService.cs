using ApplicationTest.Models;
using ApplicationTest.Repositories.Interfaces;
using ApplicationTest.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace ApplicationTest.Services
{

    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository enderecoRepository;
        private readonly IViaCepService viaCepService;

        public EnderecoService(IEnderecoRepository enderecoRepository, IViaCepService viaCepService)
        {
            this.enderecoRepository = enderecoRepository;
            this.viaCepService = viaCepService;
        }

        public async Task<int> Cadastrar(string cep)
        {
            cep = SanitizarCep(cep);

            ValidarCep(cep);

            var endereco = await viaCepService.BuscarCep(cep);

            if (endereco.Erro)
                throw new Exception("Endereço não encontrado no WS!");

            endereco.Cep = cep;

            return await enderecoRepository.CadastrarEndereco(endereco);
        }

        public async Task<Endereco> GetEndereco(string cep)
        {
            cep = SanitizarCep(cep);

            ValidarCep(cep);

            var endereco = await enderecoRepository.GetEnderecoAsync(cep);

            if (endereco == null)
                throw new Exception("Endereço não encontrado na base de dados!");

            return endereco;
        }

        private void ValidarCep(string cep)
        {
            if (string.IsNullOrEmpty(cep))
                throw new Exception("CEP Inválido!");
        }

        private string SanitizarCep(string cep)
        {
            return cep.Trim().Replace("-", "");
        }
    }
}