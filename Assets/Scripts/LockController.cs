using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockController : MonoBehaviour
{
    [SerializeField] private GameObject lockCanvas;

    private void Awake()
    {
        lockCanvas.SetActive(false);

    }

    public void ActivateLockCanvas() {
        lockCanvas.SetActive(true);

    }

}
