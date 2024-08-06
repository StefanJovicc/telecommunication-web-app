using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelecommunicationWebApp.Application;

namespace TelecommunicationWebApp.Implementation.Logging.UseCases
{
    public class SPUseCaseLogger : IUseCaseLogger
    {
        private IDbConnection _connection;

        public SPUseCaseLogger(IDbConnection connection)
        {
            _connection = connection;
        }

        void IUseCaseLogger.Log(UseCaseLog log)
        {
            _connection.Query("AddUseCaseLog", new
            {
                log.UseCaseName,
                log.Fullname,
                Data = JsonConvert.SerializeObject(log.UseCaseData),
                ExecutedAt = DateTime.UtcNow
            }, commandType: CommandType.StoredProcedure);
        }
    }
}
