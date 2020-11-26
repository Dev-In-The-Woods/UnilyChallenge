using System.IO;

namespace UnilyChallenge.LogApi.Services
{
    public interface IStreamFactory
    {
        Stream GetStream();
    }
}
