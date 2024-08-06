using TelecommunicationWebApp.Application;
using TelecommunicationWebApp.DataAccess;
using TelecommunicationWebApp.Domain;

namespace TelecommunicationWebApp.API.Core
{
    public class EfExceptionLogger : IExceptionLogger
    {
        private readonly TelecommunicationContext _telContext;

        public EfExceptionLogger(TelecommunicationContext aspContext)
        {
            _telContext = aspContext;
        }

        public Guid Log(Exception ex, IApplicationActor actor)
        {
            Guid id = Guid.NewGuid();
            ErrorLog log = new()
            {
                ErrorId = id,
                Message = ex.Message,
                StrackTrace = ex.StackTrace,
                Time = DateTime.UtcNow
            };

            _telContext.ErrorLogs.Add(log);

            _telContext.SaveChanges();

            return id;
        }
    }
}
