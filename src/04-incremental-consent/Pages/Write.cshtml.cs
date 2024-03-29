using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Web;
using System.IdentityModel.Tokens.Jwt;

namespace Incremental.Pages
{
    [AuthorizeForScopes(Scopes = new[] { "user.readwrite" })]
    public class WriteModel : PageModel
    {
        private readonly ITokenAcquisition _tokenAcquisition;
        public JwtSecurityToken JwtSecurityToken { get; set; } = new JwtSecurityToken();
        public WriteModel(ITokenAcquisition tokenAcquisition)
        {
            _tokenAcquisition = tokenAcquisition;
        }

        public string Token { get; set; } = "";

        public async Task OnGet()
        {
            Token = await _tokenAcquisition.GetAccessTokenForUserAsync(new[] { "user.readwrite" });
            JwtSecurityToken = new JwtSecurityToken(Token);
        }
    }
}
