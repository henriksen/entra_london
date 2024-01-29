using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Web;
using System.IdentityModel.Tokens.Jwt;

namespace Incremental.Pages
{
    [AuthorizeForScopes(Scopes = new[] { "user.read" })]
    public class ReadModel : PageModel
    {
        private readonly ITokenAcquisition _tokenAcquisition;
        public JwtSecurityToken JwtSecurityToken { get; set; } = new JwtSecurityToken();

        public string Token { get; set; } = "";

        public ReadModel(ITokenAcquisition tokenAcquisition)
        {
            _tokenAcquisition = tokenAcquisition;
        }

        public async Task OnGet()
        {
            Token = await _tokenAcquisition.GetAccessTokenForUserAsync(new[] { "user.read" });
            JwtSecurityToken = new JwtSecurityToken(Token);

        }

    }
}
