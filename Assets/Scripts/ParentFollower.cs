using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NRKernal;

public class ParentFollower : MonoBehaviour

{
    public Transform centerCamera; // Assign the center camera from the NRCameraRig
    [SerializeField] private float distanceFromCamera = 10.0f;
    [SerializeField] private Vector3 offset = Vector3.zero; 

    void Update()
    {
        if (centerCamera == null)
        {
            Debug.LogError("Center Camera not assigned!");
            return;
        }

        Vector3 forwardPosition = centerCamera.position + centerCamera.forward * distanceFromCamera;

        transform.position = forwardPosition + offset;

        transform.rotation = Quaternion.LookRotation(transform.position - centerCamera.position);
    }

}
