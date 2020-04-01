namespace NetCoreRecaptcha.Application.Infra.Helper
{
    public class ConstantsHelper
    {
        /// <summary>
        /// para criar um novo secret do recaptcha para um dominio utlize o site https://www.google.com/recaptcha/admin/create
        /// </summary>
        public static string ApiGoogleRecaptchaUrl => "https://www.google.com/recaptcha/api/siteverify";
        public static string ApiGoogleRecaptchaSecret => "6Le2g-UUAAAAAAWea2CiY1ajQ56zAITPsW-9SCB0";
    }
}
