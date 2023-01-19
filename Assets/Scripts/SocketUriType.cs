public class SocketUriType
{
    private const string LocalhostUri = "http://localhost";
    private const string RailwayUri = "...";
    private const int Port = 3000;

    public static string LocalHost => LocalhostUri + ":" + Port;

    public static string Railway => RailwayUri;
}