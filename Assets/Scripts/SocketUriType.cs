public class SocketUriType
{
    private const string LocalhostUri = "http://localhost";
    private const string RailwayUri = "https://simple-chat-backend-production.up.railway.app";
    private const int Port = 3000;

    public static string LocalHost => LocalhostUri + ":" + Port;

    public static string Railway => RailwayUri;
}