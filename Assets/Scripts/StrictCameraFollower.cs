using UnityEngine;
using NRKernal;
public class StrictCameraFollower : MonoBehaviour
{
    private Transform cameraCenter { get { return NRInput.CameraCenter; } }

    private Vector3 positionOffset;
    private void Awake()
    {
        positionOffset = Vector3.zero;
    }

    void Update()
    {
        transform.position = cameraCenter.position + positionOffset;
        transform.rotation = cameraCenter.rotation;
    }
}
