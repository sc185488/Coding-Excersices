using Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.BusinessComponents.TLog
{
    public class TransactionTimeCalculationLogWriter
    {        
        private readonly ILog _logger;

        public TransactionTimeCalculationLogWriter()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        public void transactionTimeCalculationLogWrite<T>(T t)
        {
            _logger.Info($"Time taken for the transaction is : { t.ToString() }");
        }
    }
}
