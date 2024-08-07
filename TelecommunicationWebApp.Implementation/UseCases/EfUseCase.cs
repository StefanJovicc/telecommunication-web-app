using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelecommunicationWebApp.DataAccess;

namespace TelecommunicationWebApp.Implementation.UseCases
{
    public abstract class EfUseCase
    {
        private readonly TelecommunicationContext _context;

        protected EfUseCase(TelecommunicationContext context)
        {
            _context = context;
        }

        protected TelecommunicationContext Context => _context;
    }
}
