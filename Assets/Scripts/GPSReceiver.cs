using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GPSReceiver : MonoBehaviour
{
    private string serverUrl = "https://diplomskiprojektpythonserver.onrender.com/get";
    private float fetchInterval = 10.0f; // Time interval to fetch data (in seconds).

    void Start()
    {
        StartCoroutine(FetchLocationPeriodically());
    }

    private IEnumerator FetchLocationPeriodically()
    {
        while (true)
        {
            yield return StartCoroutine(FetchLocationCoroutine());
            yield return new WaitForSeconds(fetchInterval);
        }
    }

    private IEnumerator FetchLocationCoroutine()
    {
        UnityWebRequest request = UnityWebRequest.Get(serverUrl);

        // Send GET request
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Received location: " + request.downloadHandler.text);

            // Parse JSON response (example: {"latitude": 45.812, "longitude": 15.956})
            GPSData gpsData = JsonUtility.FromJson<GPSData>(request.downloadHandler.text);
            Debug.Log("Latitude: " + gpsData.X + ", Longitude: " + gpsData.Z);

            // You can now use the latitude and longitude in your app.
        }
        else
        {
            Debug.LogError("Error fetching location: " + request.error);
        }
    }

    [System.Serializable]
    private class GPSData
    {
        public float X;
        public float Z;
    }
}
