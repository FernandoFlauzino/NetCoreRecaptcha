using System.Collections.Generic;

namespace NetCoreRecaptcha.Application.Response
{
    public class GoogleRecaptchaResponse
    {
        public bool ValidToken { get; set; }

        private readonly IList<string> _errors = new List<string>();

        public IEnumerable<string> Erros => _errors;

        public void AddError(string message)
        {
            _errors.Add(message);
        }
    }
}
