using CompartilhaUtilidades.Model.Dtos;
using System.Threading.Tasks;

namespace CompartilhaUtilidades.ExternalServices
{
    public interface IBuscaCepExternalService
    {
        Task<EnderecoDto> ConsultaCep(string cep);
    }
}
