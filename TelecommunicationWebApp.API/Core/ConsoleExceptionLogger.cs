﻿using TelecommunicationWebApp.Application;

namespace TelecommunicationWebApp.API.Core
{
    public class ConsoleExceptionLogger : IExceptionLogger
    {
        public Guid Log(Exception ex, IApplicationActor actor)
        {
            var id = Guid.NewGuid();
            Console.WriteLine(ex.Message + " ID: " + id);

            return id;
        }
    }
}
