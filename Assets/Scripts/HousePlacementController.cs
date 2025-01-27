using UnityEngine;
using NRKernal;

public class HousePlacementController : MonoBehaviour
{
    public GameObject dummyPlane; // Assign a dummy plane for testing
    public GameObject parentGO;   // The ParentGO (root of the house model)
    private LoginManager loginManager;
    // public JSONPasrser jsonParser; // Reference to JSONParser for triggering house generation

//     private bool isPlacementMode = false; // Whether the app is in placement mode

//     void Update()
//     {
//         if (isPlacementMode)
//         {
//             HandlePlacement();
//         }
//     }

//     /// <summary>
//     /// Enters placement mode when the user clicks the "Create" button.
//     /// </summary>
//     public void StartPlacementMode()
//     {
//         isPlacementMode = true;
//         Debug.Log("Placement mode started. Point and click to place the house.");
//     }

    public void HandlePlacement(string id, string name)
    {
//         // Check if the user clicks the trigger button
//         if (NRInput.GetButtonDown(ControllerButton.TRIGGER))
        {
            Debug.Log($"Inside HandlePlacement");
            // Get controller laser origin
            var handControllerAnchor = NRInput.DomainHand == ControllerHandEnum.Left ? ControllerAnchorEnum.LeftLaserAnchor : ControllerAnchorEnum.RightLaserAnchor;
            Transform laserAnchor = NRInput.AnchorsHelper.GetAnchor(NRInput.RaycastMode == RaycastModeEnum.Gaze ? ControllerAnchorEnum.GazePoseTrackerAnchor : handControllerAnchor);

            // Perform a raycast
            RaycastHit hitResult;
            if (Physics.Raycast(new Ray(laserAnchor.position, laserAnchor.forward), out hitResult, 10))
            {
                if (hitResult.collider != null && hitResult.collider.gameObject == dummyPlane)
                {
                    // Move ParentGO to the hit position
                    parentGO.transform.position = hitResult.point;
                    parentGO.transform.rotation = Quaternion.identity; // Optional: Align to the plane's rotation

                    Debug.Log($"House placed at: {hitResult.point}");

                    // Exit placement mode and start house generation
                    // isPlacementMode = false;
                    // TriggerHouseGeneration();
                    loginManager.GetBlueprint(id, name);
                }
            }
        }
    }
}

//     /// <summary>
//     /// Triggers the JSONParser to invoke house generation.
//     /// </summary>
//     private void TriggerHouseGeneration()
//     {
//         if (jsonParser != null)
//         {
//             // Simulate the house generation by re-invoking the JSONParser's parsing process
//             jsonParser.ParseJson(jsonParser.GetCurrentJson()); // Assumes JSONPasrser has a way to get the current JSON
//             Debug.Log("House generation triggered via JSONParser.");
//         }
//         else
//         {
//             Debug.LogError("JSONParser reference is not assigned!");
//         }
//     }
// }
