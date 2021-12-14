using System;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Creek.HelpfulExtensions
{
    public class DisposableStopWatch : IDisposable
    {
        private readonly ILogger _logger;
        private Stopwatch _stopWatch;
        private string _message;
        private bool _useConsole;
        private bool _useConsoleOnly;

        public DisposableStopWatch(ILogger logger, string message = null, bool useConsole = false)
        {
            _logger = logger;
            _useConsoleOnly = false;
            _stopWatch = new Stopwatch();
            _message = message ?? string.Empty;
            _useConsole = useConsole;

            string startMessage = $"Start: {message}";

            if (_useConsole)
            {
                _logger.LogInformation(startMessage);
                Console.WriteLine(startMessage);
            }
            else
            {
                _logger.LogInformation(startMessage);
            }

            _stopWatch.Start();
        }

        public DisposableStopWatch(string message = null)
        {
            _useConsoleOnly = true;
            _stopWatch = new Stopwatch();
            _message = message ?? string.Empty;

            string startMessage = $"Start: {message}";

            Console.WriteLine(startMessage);

            _stopWatch.Start();
        }

        public void Dispose()
        {
            _stopWatch.Stop();

            string endMessage = $"Complete:{_message}: Elapsed: {_stopWatch.Elapsed}";

            if (_useConsoleOnly)
            {
                Console.WriteLine(endMessage);
            }
            else if (_useConsole)
            {
                _logger.LogInformation(endMessage);
                Console.WriteLine(endMessage);
            }
            else
            {
                _logger.LogInformation(endMessage);
            }
        }
    }

    public static class DisposableStopWatchExtension
    {
        public static DisposableStopWatch DisposableStopWatch(this ILogger logger, string message = null, bool useConsole = false) => new DisposableStopWatch(logger, message, useConsole);

        public static DisposableStopWatch DisposableStopWatch(this string message) => new DisposableStopWatch(message);
    }
}
