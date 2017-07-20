using System;
using NLog;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    public class NLogAdapter : ILog
    {
        private Logger logger = LogManager.GetCurrentClassLogger();

        public void Debug(string message) => logger.Debug(message);

        public void Info(string message) => logger.Info(message);

        public void Warn(string message) => logger.Warn(message);

        public void Error(string message) => logger.Error(message);

        public void Fatal(string message) => logger.Fatal(message);
    }
}
