using TelecommunicationWebApp.Application;

namespace TelecommunicationWebApp.API.Core
{
    public interface IExceptionLogger
    {
        Guid Log(Exception ex, IApplicationActor actor);
    }
}
