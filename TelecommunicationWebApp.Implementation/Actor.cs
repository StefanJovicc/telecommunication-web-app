using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelecommunicationWebApp.Application;

namespace TelecommunicationWebApp.Implementation
{
    public class Actor : IApplicationActor
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public IEnumerable<int> AllowedUseCases { get; set; }
    }

    public class UnauthorizedActor : IApplicationActor
    {
        public int Id => 0;
        public string Fullname => "unauthorized";
        public string Email => "/";
        public IEnumerable<int> AllowedUseCases => new List<int> { /* FILL THIS UP */ };
    }
}
