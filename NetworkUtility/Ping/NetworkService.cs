using NetworkUtility.DNS;
using System.Net.NetworkInformation;

namespace NetworkUtility.Ping;

public class NetworkService
{
    private readonly IDNS _dNS;

    public NetworkService(IDNS dNS)
    {
        _dNS = dNS;
    }

    public string SendPing()
    {
        var dnsSuccess= _dNS.SendDNS();

        return dnsSuccess ? "Success: Ping Sent!" : "Failed: Ping Not Sent!";
    }

    public int SetTimeout(int a, int b)
    {
        return a + b;
    }

    public DateTime GetLastPingDateTime()
    {
        return DateTime.Now;
    }

    public PingOptions GetPingOption()
    {
        return new PingOptions
        {
            DontFragment = true,
            Ttl = 1
        };
    }

    public List<PingOptions> GetMostRecentPingOption()
    {
        List<PingOptions> pingOptions = new();

        pingOptions.Add(

            new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            }
           
        );

        return pingOptions;
    }
}
