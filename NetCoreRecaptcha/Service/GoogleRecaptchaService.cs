using Microsoft.AspNet.SignalR.Hubs;
using NetCoreRecaptcha.Application.Interface;
using NetCoreRecaptcha.Application.Interface.Api;
using NetCoreRecaptcha.Application.Request;
using NetCoreRecaptcha.Application.Response;
using System;
using System.Threading.Tasks;

namespace NetCoreRecaptcha.Service
{
    public class GoogleRecaptchaService : IGoogleRecaptchaService
    {
        private readonly IGoogleRecaptchaRepository _googleRecaptchaRepository;

        public GoogleRecaptchaService(IGoogleRecaptchaRepository googleRecaptchaRepository)
        {
            _googleRecaptchaRepository = googleRecaptchaRepository;
        }

        public async Task<GoogleRecaptchaResponse> ValidateReCaptcha(GoogleRecaptchaRequest request)
        {
            try
            {
                var recaptchaValidationResult = await _googleRecaptchaRepository.ValidateCaptchaToken(request.Token);
                return new GoogleRecaptchaResponse() { ValidToken = recaptchaValidationResult };
            }
            catch (Exception e)
            {
                return await Task.FromException<GoogleRecaptchaResponse>(new NotAuthorizedException(e.Message));
            }
        }
    }
}
