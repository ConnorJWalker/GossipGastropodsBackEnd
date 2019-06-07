using Microsoft.AspNetCore.Http;
using GossipGastropodsBackEnd.Models;

namespace GossipGastropodsBackEnd.Helpers
{
    public static class Extensions
    {
        public static CurrentUser GetCurrentUser(this IHttpContextAccessor httpContext)
        {
            return new CurrentUser(httpContext);
        }
    }
}
