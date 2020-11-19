using ApplicationTest.Models;
using System.Threading.Tasks;

namespace ApplicationTest.Services.Interfaces
{
    public interface IViaCepService
    {
        Task<Endereco> BuscarCep(string cep);
    }
}
