using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    public string GitHubAvatar { get; set; }

    public string GitHubName { get; set; }

    public string GitHubEmail { get; set; }

    public void OnGet()
    {
        if (User.Identity.IsAuthenticated)
        {
            GitHubName = User.FindFirst(c => c.Type == ClaimTypes.Name)?.Value;
            GitHubAvatar = User.FindFirst(c => c.Type == "urn:github:avatar")?.Value;
            GitHubEmail = User.FindFirst(c => c.Type == "urn:github:email")?.Value;
        }
    }
}