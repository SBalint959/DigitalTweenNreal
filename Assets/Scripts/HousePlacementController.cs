using UnityEngine;
using NRKernal;

public class HousePlacementController : MonoBehaviour
{
    private GameObject HousePlace;
    private GameObject parentGO;
    private LoginManager loginManager;
    private bool spawningHouse;
    private string idLocal;
    private string nameLocal;

    // void Start()
    // {

    // }
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

    //                 loginManager.GetBlueprint(idLocal, nameLocal);
    //             }
    //         }
    //     }

        
    // }

    public void centerParent() {
        Invoke("HandlePlacement", 0.5f);
    }

    public void HandlePlacement()
    {

        parentGO = GameObject.FindGameObjectWithTag("Parent");
        HousePlace = GameObject.FindGameObjectWithTag("HousePlace");
        Vector3 currentPosition = HousePlace.transform.position;
        Quaternion currentRotation = HousePlace.transform.rotation;
        Debug.Log("Centering house");

        parentGO.transform.position = new Vector3(currentPosition.x, -1, currentPosition.z);

        // Set rotation, keeping x and z unchanged, setting only y to 0
        parentGO.transform.rotation = Quaternion.Euler(0, currentRotation.eulerAngles.y, 0);

    }
}
