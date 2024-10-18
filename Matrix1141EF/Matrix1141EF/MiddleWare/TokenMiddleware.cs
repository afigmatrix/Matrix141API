using Matrix1141EF.Data;
using Matrix1141EF.Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Matrix1141EF.MiddleWare
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppDbContext _context;

        public TokenMiddleware(RequestDelegate next, AppDbContext context)
        {
            _next = next;
            _context = context;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (!string.IsNullOrEmpty(token))
            {
                var user = await ValidateTokenAsync(token);

                if (user != null)
                {
                    context.Items["User"] = user;
                }
                else
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Invalid token!");
                    return;
                }
            }

            await _next(context);
        }

        private async Task<User> ValidateTokenAsync(string token)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Token == token);
            return user;
        }
    }
}
