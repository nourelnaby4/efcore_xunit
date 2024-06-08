using System.Net.NetworkInformation;

namespace NetworkUtility.Ping;

public class NetworkService
{
    public string SendPing()
    {
        // SearchDNS();
        // BuildPacket();
        return "Success: Ping Sent!";
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
