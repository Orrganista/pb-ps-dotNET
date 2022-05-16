namespace Middleware
{
    public class UrlTransformerMiddleware
    {
        private RequestDelegate _next;

        public UrlTransformerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            var r = context.Request.Headers["User-Agent"].ToString();

            if (r.Contains("Edg"))
            {
                context.Response.Redirect("https://www.mozilla.org/pl/firefox/new/");
            }

            return _next(context);
        }
    }

    public static class UrlTransformerMiddlewareExtensions
    {
        public static IApplicationBuilder UseUrlTransformerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UrlTransformerMiddleware>();
        }
    }
}
