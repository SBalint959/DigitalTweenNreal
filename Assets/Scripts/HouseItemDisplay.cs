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
            selectButton.onClick.AddListener(HandlePlacement);
        }
    }

    // private void OnSelectButtonClicked()
    // {
    //     if (loginManager != null)
    //     {
    //         Debug.Log(id.text);
    //         Debug.Log("Button inside!");
    //         // loginManager.GetBlueprint(houseItem.id.ToString(), houseItem.name);
    //         HandlePlacement();
    //     }
    // }

    public void HandlePlacement()
    {
        // Check if the user clicks the trigger button
        // if (NRInput.GetButtonDown(ControllerButton.TRIGGER))
        // {
        //     // Get controller laser origin
        //     var handControllerAnchor = NRInput.DomainHand == ControllerHandEnum.Left ? ControllerAnchorEnum.LeftLaserAnchor : ControllerAnchorEnum.RightLaserAnchor;
        //     Transform laserAnchor = NRInput.AnchorsHelper.GetAnchor(NRInput.RaycastMode == RaycastModeEnum.Gaze ? ControllerAnchorEnum.GazePoseTrackerAnchor : handControllerAnchor);

        //     // Perform a raycast
        //     RaycastHit hitResult;
        //     if (Physics.Raycast(new Ray(laserAnchor.position, laserAnchor.forward), out hitResult, 10))
        //     {
        //         if (hitResult.collider != null && hitResult.collider.gameObject == dummyPlane)
        //         {
        //             // Move ParentGO to the hit position
        //             parentGO.transform.position = hitResult.point;
        //             parentGO.transform.rotation = Quaternion.identity; // Optional: Align to the plane's rotation

        //             Debug.Log($"House placed at: {hitResult.point}");

        //             // Exit placement mode and start house generation
        //             // isPlacementMode = false;
        //             // TriggerHouseGeneration();
        //             loginManager.GetBlueprint(houseItem.id.ToString(), houseItem.name);
        //         }
        //     }
        // }
        housePlacementController.HandlePlacement(houseItem.id.ToString(), houseItem.name);
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
