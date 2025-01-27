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
    [SerializeField] private Button selectButton;

    public GameObject dummyPlane; // Assign a dummy plane for testing
    public GameObject parentGO;   // The ParentGO (root of the house model)

    private BlueprintsInfo.Item houseItem;
    private LoginManager loginManager;

    private bool spawningHouse;

    public HousePlacementController housePlacementController;

    public void Initialize(BlueprintsInfo.Item houseItem, LoginManager loginManager)
    {
        this.houseItem = houseItem;
        this.loginManager = loginManager;

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
        if (selectButton != null)
        {
            selectButton.onClick.AddListener(OnSelectButtonClicked);
        }

        // parentGO = GameObject.FindGameObjectWithTag("Parent");
        // dummyPlane = GameObject.FindGameObjectWithTag("Plane");

        // if (parentGO == null)
        // {
        //     Debug.LogError("ParentGO not found! Ensure it has the tag 'Parent'.");
        // }

        // if (dummyPlane == null)
        // {
        //     Debug.LogError("DummyPlane not found! Ensure it has the tag 'Plane'.");
        // }
    }

    private void OnSelectButtonClicked()
    {
        if (loginManager != null)
        {
            Debug.Log(id.text);
            Debug.Log("Button inside!");
            loginManager.GetBlueprint(houseItem.id.ToString(), houseItem.name);
            // HandlePlacement();
        }
    }

    // void Update() {
    //     // Debug.Log($"{spawningHouse}");

    //     if (spawningHouse) {
    //         Debug.Log("Spawning house");


    //         if (!NRInput.GetButtonDown(ControllerButton.TRIGGER))
    //         {
    //             Debug.Log($"Trigger not clicked");
    //             return;
    //         }
    //         Debug.Log($"Trigger clicked");
    //         var handControllerAnchor = NRInput.DomainHand == ControllerHandEnum.Left ? ControllerAnchorEnum.LeftLaserAnchor : ControllerAnchorEnum.RightLaserAnchor;
    //         Transform laserAnchor = NRInput.AnchorsHelper.GetAnchor(NRInput.RaycastMode == RaycastModeEnum.Gaze ? ControllerAnchorEnum.GazePoseTrackerAnchor : handControllerAnchor);

    //         // Perform a raycast
    //         RaycastHit hitResult;
    //         if (Physics.Raycast(new Ray(laserAnchor.position, laserAnchor.forward), out hitResult, 10))
    //         {
    //             if (hitResult.collider != null && hitResult.collider.gameObject == dummyPlane)
    //             {
    //                 // Move ParentGO to the hit position
    //                 parentGO.transform.position = hitResult.point;
    //                 parentGO.transform.rotation = Quaternion.identity; // Optional: Align to the plane's rotation

    //                 Debug.Log($"House placed at: {hitResult.point}");

    //                 loginManager.GetBlueprint(houseItem.id.ToString(), houseItem.name);
    //             }
    //         }
    //     }

        
    // }

    public void HandlePlacement()
    {
        Debug.Log("Button clicked");

        spawningHouse = true;

        // housePlacementController.HandlePlacement(houseItem.id.ToString(), houseItem.name);
    }

    /// <summary>
    /// Triggers the JSONParser to invoke house generation.
    /// </summary>
    // private void TriggerHouseGeneration()
    // {
    //     if (jsonParser != null)
    //     {
    //         // Simulate the house generation by re-invoking the JSONParser's parsing process
    //         jsonParser.ParseJson(jsonParser.GetCurrentJson()); // Assumes JSONPasrser has a way to get the current JSON
    //         Debug.Log("House generation triggered via JSONParser.");
    //     }
    //     else
    //     {
    //         Debug.LogError("JSONParser reference is not assigned!");
    //     }
    // }
}
