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
}
