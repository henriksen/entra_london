using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Abstractions;
using Microsoft.Identity.Web;
using weather;

namespace client.Pages;

[Authorize]
[AuthorizeForScopes(ScopeKeySection = "Weather:Scopes")]
public class IndexModel(IDownstreamApi downstreamApi, ILogger<IndexModel> logger) : PageModel
{
    private readonly ILogger<IndexModel> _logger = logger;
    private const string ServiceName = "Weather";

    public WeatherForecast[]? Forecasts { get; private set; }

    public async Task OnGet()
    {
        Forecasts = await downstreamApi.CallApiForUserAsync<WeatherForecast[]>(
          ServiceName);
    }
}
