using ApplicationTest.Models;
using ApplicationTest.Services.Interfaces;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ApplicationTest.Services
{
    public class ViaCepService : IViaCepService
    {
        private readonly HttpService httpService;

        public ViaCepService(HttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<Endereco> BuscarCep(string cep)
        {
            var url = $"https://viacep.com.br/ws/{cep}/json/";

            var response = await this.httpService.Client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<Endereco>(await response.Content.ReadAsStringAsync());
        }
    }
}
