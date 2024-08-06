using System.IdentityModel.Tokens.Jwt;
using TelecommunicationWebApp.Application;
using TelecommunicationWebApp.Implementation;
using TelecommunicationWebApp.Implementation.Logging.UseCases;

namespace TelecommunicationWebApp.API.Extensions
{
    public static class ContainerExtensions
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            // Add every use case and validator
            services.AddTransient<UseCaseHandler>();
            services.AddTransient<IUseCaseLogger, SPUseCaseLogger>();
        }

        public static Guid? GetTokenId(this HttpRequest request)
        {
            if (request == null || !request.Headers.ContainsKey("Authorization"))
            {
                return null;
            }

            string authHeader = request.Headers["Authorization"].ToString();

            if (authHeader.Split("Bearer ").Length != 2)
            {
                return null;
            }

            string token = authHeader.Split("Bearer ")[1];

            var handler = new JwtSecurityTokenHandler();

            var tokenObj = handler.ReadJwtToken(token);

            var claims = tokenObj.Claims;

            var claim = claims.First(x => x.Type == "jti").Value;

            var tokenGuid = Guid.Parse(claim);

            return tokenGuid;
        }
    }
}
