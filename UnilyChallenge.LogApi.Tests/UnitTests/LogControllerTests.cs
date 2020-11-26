using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UnilyChallenge.LogApi.Controllers;
using UnilyChallenge.LogApi.Models;
using Xunit;
using Moq;
using UnilyChallenge.LogApi.Services;

namespace UnilyChallenge.LogApi.Tests.UnitTests
{
    public class LogControllerTests
    {
        readonly LogController sut;
        readonly LogEntry logEntry = new LogEntry()
        {
            Id = Guid.Empty,
            Timestamp = DateTime.UtcNow,
            Message = "Lorem ipsum"
        };

        public LogControllerTests()
        {
            var mockLogWriter = new Mock<ILogWriter>().Object;
            sut = new LogController(mockLogWriter);
        }

        [Fact]
        public async Task WriteLog_InvalidModel_ReturnsBadRequest()
        {
            // Arrange
            sut.ModelState.AddModelError("message", "error");

            // Act
            var result = await sut.WriteLog(logEntry);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task WriteLog_ValidModel_ReturnsOk()
        {
            // Act
            var result = await sut.WriteLog(logEntry);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
