using UnityEngine;
using System.Collections;
using TMPro;

public class GPSManager : MonoBehaviour
{
    [SerializeField] private TMP_Text statusMessage;

    public float latitude;
    public float longitude;

    private float mockLatitude = 420.6969f;
    private float mockLongitude = 69.3333f;

    public void StartGPS()
    {
        StartCoroutine(GetLocation());
    }

    IEnumerator GetLocation()
    {
        if (!Input.location.isEnabledByUser)
        {
            statusMessage.text = "Location services are not enabled by the user.";
            Debug.LogError("Location services are not enabled by the user.");
            yield break;
        }

        Input.location.Start();

        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait <= 0)
        {
            statusMessage.text = "Timed out initializing location services.";
            Debug.LogError("Timed out initializing location services.");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            statusMessage.text = "Failed to determine device location.";
            Debug.LogError("Failed to determine device location.");
            yield break;
        }
        else
        {
            latitude = Input.location.lastData.latitude;
            longitude = Input.location.lastData.longitude;
            statusMessage.text = $"Location: {latitude}, {longitude}";
            Debug.Log($"Location: {latitude}, {longitude}");
            SendLocationToNReal(latitude, longitude);
        }

        Input.location.Stop();
    }

    private void SendLocationToNReal(float latitude, float longitude)
    {
        Debug.Log($"Sending Location: {latitude}, {longitude} to NReal app...");
        GetComponent<GPSSender>().SendLocation(latitude, longitude);
    }

    public void SendMockLocation()
    {
        SendLocationToNReal(mockLatitude, mockLongitude);
    }
}
