using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace UnilyChallenge.LogApi.Services
{
    public class FileStreamFactory : IStreamFactory
    {
        private readonly string _logFilePath;

        public FileStreamFactory()
        {
            _logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "unilychallenge.log");
        }

        public Stream GetStream()
        {
            return File.OpenWrite(_logFilePath);
        }
    }
}
