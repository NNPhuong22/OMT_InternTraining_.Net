using Ex2_OMT.Repositories;

namespace Ex2_OMT.Auth
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserRepository userRepo, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = jwtUtils.ValidateToken(token);
            if (token != null)
            {
                // attach user to context on successful jwt validation
                context.Items["User"] = token;
            }

            await _next(context);
        }
    }
}
