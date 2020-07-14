namespace AuthorizeNet.Utilities
{
    using System;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Debug;

    public static class LogFactory
    {
        private static ILoggerFactory LoggerFactory { get; } = CreateLoggerFactory();

        //TODO: Better to inject factory at app initialization
        //private static ILoggerFactory LoggerFactory { get; set; }

        //public static void Initialize(ILoggerFactory loggerFactory)
        //{
        //    LoggerFactory = loggerFactory;
        //}

        public static ILogger getLog(Type classType)
        {
            if (LoggerFactory == null)
            {
                throw new ArgumentNullException(
                    nameof(LoggerFactory),
                    $"Make sure you called LogFactory.Initialize() on application startup");
            }
            return LoggerFactory.CreateLogger(classType.FullName);
        }

        private static LoggerFactory CreateLoggerFactory()
        {
            var factory = new LoggerFactory();
            factory.AddProvider(new DebugLoggerProvider());
            return factory;
        }
    }
}