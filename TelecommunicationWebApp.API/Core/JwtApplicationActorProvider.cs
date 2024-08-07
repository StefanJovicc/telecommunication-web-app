using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using TelecommunicationWebApp.Application;
using TelecommunicationWebApp.Implementation;

namespace TelecommunicationWebApp.API.Core
{
    public class JwtApplicationActorProvider : IApplicationActorProvider
    {
        private string _authorizationHeader;

        public JwtApplicationActorProvider(string authorizationHeader)
        {
            _authorizationHeader = authorizationHeader;
        }

        public IApplicationActor GetActor()
        {
            if (_authorizationHeader.Split("Bearer ").Length != 2)
            {
                return new UnauthorizedActor();
            }

            string token = _authorizationHeader.Split("Bearer ")[1];

            var handler = new JwtSecurityTokenHandler();

            var tokenObj = handler.ReadJwtToken(token);

            var claims = tokenObj.Claims;

            var claim = claims.First(x => x.Type == "jti").Value;

            var actor = new Actor
            {
                Fullname = claims.First(x => x.Type == "Fullname").Value,
                Id = int.Parse(claims.First(x => x.Type == "Id").Value),
                AllowedUseCases = JsonConvert.DeserializeObject<List<int>>(claims.First(x => x.Type == "UseCaseIds").Value)
            };

            return actor;
        }
    }
}
