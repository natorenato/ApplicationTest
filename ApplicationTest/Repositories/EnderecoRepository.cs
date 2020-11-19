using ApplicationTest.Models;
using ApplicationTest.Repositories.Contexts;
using ApplicationTest.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTest.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly ApplicationTestContext context;

        public EnderecoRepository(ApplicationTestContext context)
        {
            this.context = context;
        }

        public async Task<int> CadastrarEndereco(Endereco endereco)
        {
            await context.AddAsync(endereco);

            await context.SaveChangesAsync();

            return endereco.Id;
        }

        public async Task<Endereco> GetEnderecoAsync(string cep)
        {
            return context.Enderecos.FirstOrDefault(x => x.Cep.Equals(cep));
        }
    }
}