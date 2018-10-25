using Microsoft.AspNetCore.Http;
using Post3_GoogleReCaptchaV2.Models;
using System.Threading.Tasks;

namespace Post3_GoogleReCaptchaV2.Services
{
    public interface IRecaptchaService
    {
        Task<RecaptchaResponse> Validate(IFormCollection form);
    }
}
