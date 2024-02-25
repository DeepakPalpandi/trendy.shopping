using Microsoft.AspNetCore.Routing;
using System.Text.RegularExpressions;

namespace trendy.shopping.domain.Helpers
{
    public class SlugifyParameterTransformer : IOutboundParameterTransformer
    {
        public string TransformOutbound(object? value)
        {
            // Slugify value
            return value == null ? String.Empty :
                Regex.Replace(value.ToString() ?? string.Empty, "([a-z])([A-Z])", "$1-$2").ToLower();
        }
    }
}
