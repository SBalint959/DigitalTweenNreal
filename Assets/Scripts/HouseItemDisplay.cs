using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using NRKernal;

public class HouseItemDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text id;
    [SerializeField] private TMP_Text username;
    [SerializeField] private Button createButton;
    [SerializeField] private Button lockButton;


    public GameObject parentGO;   // The ParentGO (root of the house model)

    private GameObject LockCanvas;
    private BlueprintsInfo.Item houseItem;
    private LoginManager loginManager;
    private HouseMover houseMover;
    private JSONSender jsonSender;
    private GPSReceiver.GPSData gpsData;
    private GameObject lockControllerObject;

    private bool spawningHouse;

    public HousePlacementController housePlacementController;

    public void Initialize(BlueprintsInfo.Item houseItem, 
                           LoginManager loginManager, 
                           HouseMover houseMover,
                           JSONSender jsonSender,
                           GPSReceiver.GPSData gpsData)
    {
        this.houseItem = houseItem;
        this.loginManager = loginManager;
        this.houseMover = houseMover;
        this.jsonSender = jsonSender;
        this.gpsData = gpsData;

        if (id != null)
        {
            id.text = "ID: " + houseItem.id;
            id.fontSize = 12;
        }
        if (username != null)
        {
            username.text = houseItem.name;
            username.fontSize = 12;
        }
        if (createButton != null)
        {
            createButton.onClick.AddListener(OncreateButtonClicked);
        }

        parentGO = GameObject.FindGameObjectWithTag("Parent");
        lockControllerObject = GameObject.FindGameObjectWithTag("LockController");
        // LockCanvas = GameObject.FindGameObjectWithTag("LockCanvas");

        // if (LockCanvas == null)
        // {
        //     Debug.LogError("LockCanvas not found! Ensure it has the tag 'LockCanvas'.");
        // }
        // else {
        //     LockCanvas.SetActive(false);
        //     Debug.Log("LockCanvas is now inactive.");
        // }

        if (parentGO == null)
        {
            Debug.LogError("ParentGO not found! Ensure it has the tag 'Parent'.");
        }

    }

    private void OncreateButtonClicked()
    {
        if (loginManager != null)
        {
            Debug.Log(id.text);
            Debug.Log("Button inside!");

            //Alternative house spawning
            loginManager.GetBlueprint(houseItem.id.ToString(), houseItem.name);
            // RemoveParentFollower();
            housePlacementController.centerParent();

            //Raycast house spawning
            //HandlePlacement();
            
            createButton.gameObject.SetActive(false);
            // LockCanvas.SetActive(true);

            LockController lockController = lockControllerObject.GetComponent<LockController>();


            // Call the ActivateLockPosition function
            
            lockController.ActivateLockCanvas();
            gameObject.transform.parent.gameObject.SetActive(false);
            

        }
    }

    // }

    void Update()
    {
        // Debug.Log($"{spawningHouse}");

        if (spawningHouse)
        {
            Debug.Log("Spawning house");


            if (!NRInput.GetButtonDown(ControllerButton.TRIGGER))
            {
                Debug.Log($"Trigger not clicked");
                return;
            }
            Debug.Log($"Trigger clicked");
            var handControllerAnchor = NRInput.DomainHand == ControllerHandEnum.Left ? ControllerAnchorEnum.LeftLaserAnchor : ControllerAnchorEnum.RightLaserAnchor;
            Transform laserAnchor = NRInput.AnchorsHelper.GetAnchor(NRInput.RaycastMode == RaycastModeEnum.Gaze ? ControllerAnchorEnum.GazePoseTrackerAnchor : handControllerAnchor);

            // Perform a raycast
            RaycastHit hitResult;
            if (Physics.Raycast(new Ray(laserAnchor.transform.position, laserAnchor.transform.forward), out hitResult, 10))
            {
                if (hitResult.collider.gameObject != null && hitResult.collider.gameObject.GetComponent<NRTrackableBehaviour>() != null)
                {
                    var behaviour = hitResult.collider.gameObject.GetComponent<NRTrackableBehaviour>();
                    if (behaviour.Trackable.GetTrackableType() != TrackableType.TRACKABLE_PLANE)
                    {
                        return;
                    }
                    parentGO.transform.position = hitResult.point;
                    parentGO.transform.rotation = Quaternion.identity; // Optional: Align to the plane's rotation

                    Debug.Log($"House placed at: {hitResult.point}");

                    loginManager.GetBlueprint(houseItem.id.ToString(), houseItem.name);
                }
            }
        }


    }

    public void HandlePlacement()
    {
        Debug.Log("Button clicked");

        spawningHouse = true;

        // housePlacementController.HandlePlacement(houseItem.id.ToString(), houseItem.name);
    }

    public void RemoveParentFollower()
    {
        if (parentGO == null)
        {
            Debug.LogError("Target object is null. Cannot remove component.");
            return;
        }

        // Attempt to find and remove the ParentFollower component
        var parentFollower = parentGO.GetComponent("ParentFollower");
        if (parentFollower != null)
        {
            Destroy(parentFollower);
            Debug.Log($"ParentFollower component removed from {parentGO.name}.");
        }
        else
        {
            Debug.Log($"ParentFollower component not found on {parentGO.name}.");
        }
    }
}
