using Microsoft.AspNetCore.Builder;
using HotelSys.Models;

namespace HotelSys.Middleware
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseContentLengthRestriction(this IApplicationBuilder builder, ContentLengthRestrictionOptions contentLengthRestrictionOptions)
            => builder.UseMiddleware<ContentLengthRestrictionMiddleware>(contentLengthRestrictionOptions);
    }
}
