using FluentAssertions;
using NetworkUtility.Ping;

namespace NetworkUtility.Tests.PingTests;

public class NetworkServiceTests
{
    [Fact]
    public void NetworkService_SendPing_ReturnString()
    {
        // Arrange - variable, class, mocks
        var pingService = new NetworkService();

        // Act
        var result= pingService.SendPing();

        // Assert
        result.Should().NotBeNullOrWhiteSpace();
        result.Should().Be("Success: Ping Sent!");
        result.Should().Contain("Success",Exactly.Once());
    }

    [Theory]
    [InlineData(10,20,30)]
    public void NetworkService_SetTimeout_ReturnSum(int a , int b, int expected)
    {
        // Arrange
        var ping= new NetworkService();

        // Act
        var result=ping.SetTimeout(a,b);

        // Assert
        result.Should().Be(expected);
        result.Should().NotBeInRange(-1000,0);
    }
}
