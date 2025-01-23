using UnityEngine;
using System.Collections;

public class GPSManager : MonoBehaviour
{
    public static GPSManager Instance { get; private set; }
    public float latitude;
    public float longitude;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    IEnumerator  Start()
    {
        if (!Input.location.isEnabledByUser)
        {
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
            Debug.LogError("Timed out initializing location services.");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.LogError("Failed to determine device location.");
            yield break;
        }
        else
        {
            latitude = Input.location.lastData.latitude;
            longitude = Input.location.lastData.longitude;
            Debug.Log($"Location: {latitude}, {longitude}");
        }
    }
}
