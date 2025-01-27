using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class GPSReceiver : MonoBehaviour
{
    public int listenPort = 5555; // Port to listen on

    private UdpClient udpClient;
    private Thread receiveThread;
    private bool isRunning = true;

    void Start()
    {
        udpClient = new UdpClient(listenPort);
        receiveThread = new Thread(ReceiveData);
        receiveThread.IsBackground = true;
        receiveThread.Start();
        Debug.Log("UDP Server started, listening on port " + listenPort);
    }

    void ReceiveData()
    {
        while (isRunning)
        {
            try
            {
                IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, listenPort);
                byte[] data = udpClient.Receive(ref remoteEndPoint);
                string receivedMessage = Encoding.UTF8.GetString(data);

                Debug.Log("Received GPS data: " + receivedMessage);
                // Process the received GPS data as needed
            }
            catch (SocketException ex)
            {
                Debug.LogError("Socket exception: " + ex.Message);
            }
        }
    }

    void OnApplicationQuit()
    {
        isRunning = false;
        udpClient.Close();
        receiveThread.Abort();
    }
}
