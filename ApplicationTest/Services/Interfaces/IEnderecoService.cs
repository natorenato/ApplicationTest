using ApplicationTest.Models;
using System.Threading.Tasks;

namespace ApplicationTest.Services.Interfaces
{
    public interface IEnderecoService
    {
        Task<int> Cadastrar(string cep);
        Task<Endereco> GetEndereco(string cep);
    }
}