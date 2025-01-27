using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GPSSender : MonoBehaviour
{
    private string serverUrl = "https://diplomskiprojektpythonserver.onrender.com/send"; 

    public void SendLocation(float latitude, float longitude)
    {
        StartCoroutine(SendDataCoroutine(latitude, longitude));
    }

    private IEnumerator SendDataCoroutine(float latitude, float longitude)
    {
        // Create JSON payload
        string json = JsonUtility.ToJson(new GPSData(latitude, longitude));

        // Create POST request
        UnityWebRequest request = new UnityWebRequest(serverUrl, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        // Send the request
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Location sent successfully: " + request.downloadHandler.text);
        }
        else
        {
            Debug.LogError("Error sending location: " + request.error);
        }
    }

    // Data structure for JSON serialization
    [System.Serializable]
    private class GPSData
    {
        public float X;
        public float Z;

        public GPSData(float lat, float lon)
        {
            X = lat;
            Z = lon;
        }
    }
}
