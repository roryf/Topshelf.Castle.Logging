using System;
using System.Globalization;
using Castle.Core.Logging;
using Topshelf.Logging;

namespace TopShelf.Castle.Logging.Logging
{
    public class CastleLoggingLogWriter : LogWriter
    {
        private readonly ILogger logger;

        public CastleLoggingLogWriter(ILogger logger)
        {
            this.logger = logger;
        }

        private string MessageAsString(object message)
        {
            return message == null || message is string
                       ? message as string
                       : message.ToString();
        }

        public void Debug(object message)
        {
            logger.Debug(MessageAsString(message));
        }

        public void Debug(object message, Exception exception)
        {
            logger.Debug(MessageAsString(message), exception);
        }

        public void Debug(LogWriterOutputProvider messageProvider)
        {
            if (!IsDebugEnabled)
                return;

            logger.Debug(MessageAsString(messageProvider()));
        }

        public void DebugFormat(string format, params object[] args)
        {
            logger.DebugFormat(format, args);
        }

        public void DebugFormat(IFormatProvider provider, string format, params object[] args)
        {
            logger.DebugFormat(provider, format, args);
        }

        public void Info(object message)
        {
            logger.Info(MessageAsString(message));
        }

        public void Info(object message, Exception exception)
        {
            logger.Info(MessageAsString(message), exception);
        }

        public void Info(LogWriterOutputProvider messageProvider)
        {
            if (!IsInfoEnabled)
                return;

            logger.Info(MessageAsString(messageProvider()));
        }

        public void InfoFormat(string format, params object[] args)
        {
            logger.InfoFormat(format, args);
        }

        public void InfoFormat(IFormatProvider provider, string format, params object[] args)
        {
            logger.InfoFormat(provider, format, args);
        }

        public void Warn(object message)
        {
            logger.Warn(MessageAsString(message));
        }

        public void Warn(object message, Exception exception)
        {
            logger.Warn(MessageAsString(message), exception);
        }

        public void Warn(LogWriterOutputProvider messageProvider)
        {
            if (!IsWarnEnabled)
                return;

            logger.Warn(MessageAsString(messageProvider()));
        }

        public void WarnFormat(string format, params object[] args)
        {
            logger.WarnFormat(format, args);
        }

        public void WarnFormat(IFormatProvider provider, string format, params object[] args)
        {
            logger.WarnFormat(provider, format, args);
        }

        public void Error(object message)
        {
            logger.Error(MessageAsString(message));
        }

        public void Error(object message, Exception exception)
        {
            logger.Error(MessageAsString(message), exception);
        }

        public void Error(LogWriterOutputProvider messageProvider)
        {
            if (!IsErrorEnabled)
                return;

            logger.Error(MessageAsString(messageProvider()));
        }

        public void ErrorFormat(string format, params object[] args)
        {
            logger.ErrorFormat(format, args);
        }

        public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
        {
            logger.ErrorFormat(provider, format, args);
        }

        public void Fatal(object message)
        {
            logger.Fatal(MessageAsString(message));
        }

        public void Fatal(object message, Exception exception)
        {
            logger.Fatal(MessageAsString(message), exception);
        }

        public void Fatal(LogWriterOutputProvider messageProvider)
        {
            if (!IsFatalEnabled)
                return;

            logger.Fatal(MessageAsString(messageProvider()));
        }

        public void FatalFormat(string format, params object[] args)
        {
            logger.FatalFormat(format, args);
        }

        public void FatalFormat(IFormatProvider provider, string format, params object[] args)
        {
            logger.FatalFormat(provider, format, args);
        }

        public bool IsDebugEnabled
        {
            get { return logger.IsDebugEnabled; }
        }

        public bool IsInfoEnabled
        {
            get { return logger.IsInfoEnabled; }
        }

        public bool IsWarnEnabled
        {
            get { return logger.IsWarnEnabled; }
        }

        public bool IsErrorEnabled
        {
            get { return logger.IsErrorEnabled; }
        }

        public bool IsFatalEnabled
        {
            get { return logger.IsFatalEnabled; }
        }

        public void Log(LoggingLevel level, object obj)
        {
            if (level == LoggingLevel.Fatal)
                Fatal(obj);
            else if (level == LoggingLevel.Error)
                Error(obj);
            else if (level == LoggingLevel.Warn)
                Warn(obj);
            else if (level == LoggingLevel.Info)
                Info(obj);
            else if (level >= LoggingLevel.Debug)
                Debug(obj);
        }

        public void Log(LoggingLevel level, object obj, Exception exception)
        {
            if (level == LoggingLevel.Fatal)
                Fatal(obj, exception);
            else if (level == LoggingLevel.Error)
                Error(obj, exception);
            else if (level == LoggingLevel.Warn)
                Warn(obj, exception);
            else if (level == LoggingLevel.Info)
                Info(obj, exception);
            else if (level >= LoggingLevel.Debug)
                Debug(obj, exception);
        }

        public void Log(LoggingLevel level, LogWriterOutputProvider messageProvider)
        {
            if (level == LoggingLevel.Fatal)
                Fatal(messageProvider);
            else if (level == LoggingLevel.Error)
                Error(messageProvider);
            else if (level == LoggingLevel.Warn)
                Warn(messageProvider);
            else if (level == LoggingLevel.Info)
                Info(messageProvider);
            else if (level >= LoggingLevel.Debug)
                Debug(messageProvider);
        }

        public void LogFormat(LoggingLevel level, string format, params object[] args)
        {
            if (level == LoggingLevel.Fatal)
                FatalFormat(CultureInfo.InvariantCulture, format, args);
            else if (level == LoggingLevel.Error)
                ErrorFormat(CultureInfo.InvariantCulture, format, args);
            else if (level == LoggingLevel.Warn)
                WarnFormat(CultureInfo.InvariantCulture, format, args);
            else if (level == LoggingLevel.Info)
                InfoFormat(CultureInfo.InvariantCulture, format, args);
            else if (level >= LoggingLevel.Debug)
                DebugFormat(CultureInfo.InvariantCulture, format, args);
        }

        public void LogFormat(LoggingLevel level, IFormatProvider formatProvider, string format, params object[] args)
        {
            if (level == LoggingLevel.Fatal)
                FatalFormat(formatProvider, format, args);
            else if (level == LoggingLevel.Error)
                ErrorFormat(formatProvider, format, args);
            else if (level == LoggingLevel.Warn)
                WarnFormat(formatProvider, format, args);
            else if (level == LoggingLevel.Info)
                InfoFormat(formatProvider, format, args);
            else if (level >= LoggingLevel.Debug)
                DebugFormat(formatProvider, format, args);
        }
    }
}