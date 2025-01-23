using UnityEngine;

public class ARObjectPlacer : MonoBehaviour
{
    public GameObject arObjectPrefab; // The prefab to instantiate
    public float targetLatitude;     // Target GPS latitude
    public float targetLongitude;    // Target GPS longitude
    private Vector3 referencePosition; // Unity world position of the reference GPS point
    public float refLatitude;        // Reference GPS latitude
    public float refLongitude;       // Reference GPS longitude

    void Start()
    {
        // Calculate position relative to the reference point
        Vector3 offset = GPSDifferenceToUnityPosition(targetLatitude, targetLongitude, refLatitude, refLongitude);
        Vector3 worldPosition = referencePosition + offset;

        // Place the object in the world
        Instantiate(arObjectPrefab, worldPosition, Quaternion.identity);
    }

    public Vector3 GPSDifferenceToUnityPosition(float targetLat, float targetLon, float refLat, float refLon)
    {
        float earthRadius = 6378137f; // Earth's radius in meters
        float latDiff = Mathf.Deg2Rad * (targetLat - refLat);
        float lonDiff = Mathf.Deg2Rad * (targetLon - refLon);

        float x = lonDiff * Mathf.Cos(Mathf.Deg2Rad * refLat) * earthRadius;
        float z = latDiff * earthRadius;

        return new Vector3(x, 0, z);
    }
}
