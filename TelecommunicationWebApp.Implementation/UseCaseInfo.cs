using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelecommunicationWebApp.Application.UseCases;

namespace TelecommunicationWebApp.Implementation
{
    public static class UseCaseInfo
    {
        public static IEnumerable<int> AllUseCases
        {
            get
            {
                var type = typeof(IUseCase);
                var types = typeof(UseCaseInfo).Assembly.GetTypes()
                    .Where(p => type.IsAssignableFrom(p)).Select(x => Activator.CreateInstance(x));

                return null;
            }
        }

        // I need to update this part every time I add new use case
        // Could be better if used reflexions instead maybe? (maybe even database?)
        public static int MaxUseCaseId => 1;
    }
}
