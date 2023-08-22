using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using System.Net;
using WebClient.Infrastructure;

namespace WebClient.Tests;

public class ExceptionHandlerMiddlewareTests
{
    private Mock<ILogger<ExceptionHandlerMiddleware>> _loggerMock;
    private ExceptionHandlerMiddleware _middleware;
    private const string ExceptionMsg = "Middleware exception";

    public ExceptionHandlerMiddlewareTests()
    {
        _loggerMock = new Mock<ILogger<ExceptionHandlerMiddleware>>();
        _middleware = new ExceptionHandlerMiddleware(
            _ => throw new Exception(ExceptionMsg),
            _loggerMock.Object
        );
    }

    [Fact]
    public async Task InvokeAsync_LogsException_WhenExceptionOccurs()
    {
        // Arrange
        var context = new DefaultHttpContext();

        // Act
        await _middleware.InvokeAsync(context);

        // Assert
        _loggerMock.Verify(
            logger => logger.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((o, t) => o.ToString().Contains("Middleware exception")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once
        );
    }

    [Fact]
    public async Task InvokeAsync_WritesErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var context = new DefaultHttpContext();
        context.Response.Body = new MemoryStream();

        // Act
        await _middleware.InvokeAsync(context);

        // Assert
        Assert.Equal((int)HttpStatusCode.InternalServerError, context.Response.StatusCode);

        context.Response.Body.Seek(0, SeekOrigin.Begin);
        var body = new StreamReader(context.Response.Body).ReadToEnd();

        Assert.Contains("Internal Server Error.", body);
    }


    [Fact]
    public async Task InvokeAsync_CallsNextMiddleware_WhenNoExceptionOccurs()
    {
        bool nextCalled = false;

        // Arrange
        var context = new DefaultHttpContext();

        _middleware = new ExceptionHandlerMiddleware(
            _ =>
            {
                nextCalled = true;
                return Task.CompletedTask;
            },
            _loggerMock.Object
        );

        // Act
        await _middleware.InvokeAsync(context);

        // Assert
        Assert.True(nextCalled);
    }
}
