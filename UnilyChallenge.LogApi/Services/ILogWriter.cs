using System;
using System.Threading.Tasks;

namespace UnilyChallenge.LogApi.Services
{
    public interface ILogWriter
    {
        Task WriteLogAsync(Guid id, DateTime timeStamp, string message);
    }
}
