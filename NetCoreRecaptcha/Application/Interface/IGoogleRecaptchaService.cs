using NetCoreRecaptcha.Application.Request;
using NetCoreRecaptcha.Application.Response;
using System.Threading.Tasks;

namespace NetCoreRecaptcha.Application.Interface
{
    public interface IGoogleRecaptchaService
    {
        Task<GoogleRecaptchaResponse> ValidateReCaptcha(GoogleRecaptchaRequest request);
    }
}
