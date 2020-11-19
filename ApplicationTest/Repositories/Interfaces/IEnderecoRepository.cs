using ApplicationTest.Models;
using System.Threading.Tasks;

namespace ApplicationTest.Repositories.Interfaces
{
    public interface IEnderecoRepository
    {
        Task<int> CadastrarEndereco(Endereco endereco);
        Task<Endereco> GetEnderecoAsync(string cep);
    }
}