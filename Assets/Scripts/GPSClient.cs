using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class GPSClient : MonoBehaviour
{
    public string serverIP = "192.168.1.100"; // Local IP address of the NReal device
    public int serverPort = 5555; // Port to send data to

    public void SendGPSCoordinates(double latitude, double longitude)
    {
        // Example GPS data in JSON format
        string gpsData = $"{{\"X\":{latitude},\"Y\":{longitude}}}";
        byte[] data = Encoding.UTF8.GetBytes(gpsData);

        // Send data using UDP
        using (UdpClient udpClient = new UdpClient())
        {
            udpClient.Send(data, data.Length, serverIP, serverPort);
            Debug.Log("GPS coordinates sent: " + gpsData);
        }
    }
}
