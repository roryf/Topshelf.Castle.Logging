using System;
using Castle.Core.Logging;
using Castle.Windsor;
using Topshelf.Logging;

namespace TopShelf.Castle.Logging.Logging
{
    public class CastleLoggingLogWriterFactory : LogWriterFactory
    {
        private readonly Func<IWindsorContainer> containerAccessor;
        private IWindsorContainer windsorContainer;

        public CastleLoggingLogWriterFactory(Func<IWindsorContainer> containerAccessor)
        {
            this.containerAccessor = containerAccessor;
        }

        protected IWindsorContainer WindsorContainer
        {
            get
            {
                if (windsorContainer == null)
                {
                    windsorContainer = containerAccessor();
                }
                return windsorContainer;
            }
        }

        public LogWriter Get(string name)
        {
            return new CastleLoggingLogWriter(WindsorContainer.Resolve<ILoggerFactory>().Create(name));
        }

        public void Shutdown()
        {
        }

        public static void Use(Func<IWindsorContainer> containerAccessor)
        {
            HostLogger.UseLogger(new CastleLoggingLoggerConfigurator(containerAccessor));
        }

        [Serializable]
        public class CastleLoggingLoggerConfigurator : HostLoggerConfigurator
        {
            private readonly Func<IWindsorContainer> containerAccessor;

            public CastleLoggingLoggerConfigurator(Func<IWindsorContainer> containerAccessor)
            {
                this.containerAccessor = containerAccessor;
            }

            public LogWriterFactory CreateLogWriterFactory()
            {
                return new CastleLoggingLogWriterFactory(containerAccessor);
            }
        }
    }
}