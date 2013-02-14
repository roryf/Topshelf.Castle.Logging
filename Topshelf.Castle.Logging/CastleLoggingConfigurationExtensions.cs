using System;
using Castle.Windsor;
using TopShelf.Castle.Logging.Logging;
using Topshelf.HostConfigurators;

namespace TopShelf.Castle.Logging
{
    public static class CastleLoggingConfigurationExtensions
    {
        public static void UseCastleLogging(this HostConfigurator configurator, IWindsorContainer windsorContainer)
        {
            configurator.UseCastleLogging(() => windsorContainer);
        }

        public static void UseCastleLogging(this HostConfigurator configurator, Func<IWindsorContainer> containerAccessor)
        {
            CastleLoggingLogWriterFactory.Use(containerAccessor);
        }
    }
}