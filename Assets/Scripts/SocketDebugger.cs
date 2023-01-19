using UnityEngine;

public class SocketDebugger : MonoBehaviour
{
    private SocketConnector socketConnector;

    [ContextMenu("Open")]
    public void Open()
    {
        if (socketConnector != null)
        {
            return;
        }
        
        socketConnector = new SocketConnector(SocketUriType.LocalHost);
        socketConnector.Open();
    }

    [ContextMenu("Disconnect")]
    public void Disconnect()
    {
        if (socketConnector == null)
        {
            return;
        }
        
        socketConnector.Disconnect();
    }

    [ContextMenu("Close")]
    public void Close()
    {
        if (socketConnector == null)
        {
            return;
        }
        
        socketConnector.Close();
    }
}