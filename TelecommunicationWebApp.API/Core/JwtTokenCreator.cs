using TelecommunicationWebApp.DataAccess;

namespace TelecommunicationWebApp.API.Core
{
    public class JwtTokenCreator
    {
        private readonly TelecommunicationContext _context;
        private readonly JwtSettings _settings;
        private readonly ITokenStorage _storage;

        public JwtTokenCreator(TelecommunicationContext context, JwtSettings settings, ITokenStorage storage)
        {
            _context = context;
            _settings = settings;
            _storage = storage;
        }

        // Get user from DB when you remake DB
        // Validate his credentials and return JWT token
    }
}
