using System.Threading.Tasks;

namespace NetCoreRecaptcha.Application.Interface.Api
{
    public interface IGoogleRecaptchaRepository
    {
        Task<bool> ValidateCaptchaToken(string token);
    }
}
