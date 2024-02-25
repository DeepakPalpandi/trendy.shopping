using Microsoft.AspNetCore.Http;

namespace trendy.shopping.domain.Helpers
{
    public static class CommonHelper
    {
        public static string? GetIPAddress(HttpContext httpContext)
        {
            var myIP = httpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            if (string.IsNullOrEmpty(myIP))
            {
                myIP = httpContext.Connection?.RemoteIpAddress?.ToString();
            }
            return myIP;
        }
    }
}
