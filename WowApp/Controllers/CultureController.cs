using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace WowApp.Controllers
{
    [ApiController]
    public class CultureController : Controller
    {
        [HttpGet("/set-culture")]
        public IActionResult SetCulture(string culture, string returnUrl)
        {            
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1),
                    IsEssential = true
                }
            );
                        
            var localPath = new Uri(returnUrl).PathAndQuery;

            return LocalRedirect(localPath);
        }
    }
}
