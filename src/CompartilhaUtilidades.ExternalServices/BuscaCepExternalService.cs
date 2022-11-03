using CompartilhaUtilidades.Model.Dtos;
using System.Linq;
using System.Threading.Tasks;

namespace CompartilhaUtilidades.ExternalServices
{
    public class BuscaCepExternalService : IBuscaCepExternalService
    {
        public BuscaCepExternalService()
        {

        }

        public async Task<EnderecoDto> ConsultaCep(string cep)
        {
            var addresses = await new Correios.NET.Services().GetAddressesAsync(cep);
            var enderecoCorreio = addresses.FirstOrDefault();
            if (enderecoCorreio != default)
            {
                return new EnderecoDto
                {
                    Bairro = enderecoCorreio.District,
                    Cep = enderecoCorreio.ZipCode,
                    Cidade = enderecoCorreio.City,
                    Estado = enderecoCorreio.State,
                    Logradouro = enderecoCorreio.Street
                };
            }

            return new EnderecoDto();
        }
    }

}