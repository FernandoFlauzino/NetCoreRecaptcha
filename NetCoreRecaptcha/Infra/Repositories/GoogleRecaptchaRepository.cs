using NetCoreRecaptcha.Application.Infra.Helper;
using NetCoreRecaptcha.Application.Interface.Api;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NetCoreRecaptcha.Infra.Repositories
{
    public class GoogleRecaptchaRepository : IGoogleRecaptchaRepository
    {
        public async Task<bool> ValidateCaptchaToken(string token)
        {
            try
            {
                using HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(ConstantsHelper.ApiGoogleRecaptchaUrl)
                };

                var content = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>("secret", ConstantsHelper.ApiGoogleRecaptchaSecret),
                        new KeyValuePair<string, string>("response", token)
                });

                var resultApi = await client.PostAsync(String.Empty, content);
                string resultStr = await resultApi.Content.ReadAsStringAsync();
                var resultDeserialized = (JObject)JsonConvert.DeserializeObject(resultStr);

                return Convert.ToBoolean(resultDeserialized["success"].ToString());
            }
            catch
            {
                return false;
            }
        }
    }
}
