using System;
using Xunit;
using Moq;
using UnilyChallenge.LogApi.Services;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace UnilyChallenge.LogApi.Tests.UnitTests
{
    public class StreamLogWriterTests
    {
        private readonly Guid _id = Guid.Empty;
        private readonly DateTime _timeStamp = DateTime.UtcNow;
        private readonly string _message = "Lorem ipsum dolor sit amet sanct tetur";

        [Fact]
        public async Task WriteLog_ValidInput_WritesLogEntryToStream()
        {
            // Arrange
            using var memStream = new MemoryStream();
            var mockStreamFactory = Mock.Of<IStreamFactory>(sf => sf.GetStream() == memStream);
            var sut = new StreamLogWriter(mockStreamFactory);

            // Act
            await sut.WriteLogAsync(_id, _timeStamp, _message);
            var result = Encoding.Default.GetString(memStream.ToArray());

            // Assert
            Assert.Contains(_id.ToString(), result);
            Assert.Contains(_timeStamp.ToString("s"), result);
            Assert.Contains(_message.ToString(), result);
        }

        [Fact]
        public async Task WriteLog_EmptyString_ThrowsException()
        {
            // Arrange
            using var memStream = new MemoryStream();
            var mockStreamFactory = Mock.Of<IStreamFactory>(sf => sf.GetStream() == memStream);
            var sut = new StreamLogWriter(mockStreamFactory);

            // Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => sut.WriteLogAsync(_id, _timeStamp, string.Empty));
        }

        //[Fact]
        //public async Task WriteLog_ConsecutiveCalls_AppendToStream()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
