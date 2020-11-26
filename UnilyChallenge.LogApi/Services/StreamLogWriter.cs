using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace UnilyChallenge.LogApi.Services
{
    public class StreamLogWriter : ILogWriter
    {
        private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        private readonly IStreamFactory _streamFactory;

        public StreamLogWriter(IStreamFactory streamFactory)
        {
            _streamFactory = streamFactory;
        }

        public async Task WriteLogAsync(Guid id, DateTime timeStamp, string message)
        {
            if (string.IsNullOrEmpty(message)) throw new ArgumentException("Message argument is required.");

            await _semaphore.WaitAsync();
            try
            {
                using var stream = _streamFactory.GetStream();
                stream.Position = stream.Length;
                using StreamWriter outputFile = new StreamWriter(stream);
                await outputFile.WriteLineAsync($"{timeStamp:s} {id} {message}");
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}
