using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Extensions;
using NetworkUtility.DNS;
using NetworkUtility.Ping;
using System.Net.NetworkInformation;

namespace NetworkUtility.Tests.PingTests;

public class NetworkServiceTests
{
    private readonly NetworkService _pingService;
    private readonly IDNS _dNS;

    public NetworkServiceTests()
    {
        // Dependencies
        _dNS=A.Fake<IDNS>();

        // SUT
        _pingService = new NetworkService(_dNS);
    }
    [Fact]
    public void NetworkService_SendPing_ReturnString()
    {
        // Arrange
        A.CallTo(() => _dNS.SendDNS()).Returns(true);

        // Act
        var result = _pingService.SendPing();

        // Assert
        result.Should().NotBeNullOrWhiteSpace();
        result.Should().Be("Success: Ping Sent!");
        result.Should().Contain("Success", Exactly.Once());
    }

    [Theory]
    [InlineData(10, 20, 30)]
    public void NetworkService_SetTimeout_ReturnSum(int a, int b, int expected)
    {
        // Arrange
       // var ping = new NetworkService();

        // Act
        var result = _pingService.SetTimeout(a, b);

        // Assert
        result.Should().Be(expected);
        result.Should().NotBeInRange(-1000, 0);
    }

    [Fact]
    public void NetworkService_GetLastPingDateTime_ReturnDatetime()
    {
        var result= _pingService.GetLastPingDateTime();

        result.Should().BeBefore(1.January(2030));
        result.Should().BeAfter(1.January(2010));
    }

    [Fact]
    public void Network_GetPingOptions_ReturnObject()
    {
        // Arrange
        var expected = new PingOptions
        {
            DontFragment = true,
            Ttl = 1
        };

        // Act 
        var result= _pingService.GetPingOption();

        // Assert WARNING "Be" Carful
        result.Should().BeOfType<PingOptions>();
        result.Should().BeEquivalentTo(expected);
        result.Ttl.Should().Be(1);
    }


    [Fact]
    public void Network_GetMostRecentPingOption_ReturnOIEnumerable()
    {
     
        // Act 
        var result = _pingService.GetMostRecentPingOption();

        // Assert WARNING "Be" Carful
        result.Should().BeOfType<List< PingOptions>>();
        result.Should().Contain(x=>x.DontFragment==true);
    }
}
