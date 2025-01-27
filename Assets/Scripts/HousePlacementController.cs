using UnityEngine;
using NRKernal;

public class HousePlacementController : MonoBehaviour
{
    public GameObject dummyPlane; // Assign a dummy plane for testing
    public GameObject parentGO;   // The ParentGO (root of the house model)
    private LoginManager loginManager;
    private bool spawningHouse;
    private string idLocal;
    private string nameLocal;

    void Start()
    {
        // Find ParentGO and DummyPlane by their tags
        parentGO = GameObject.FindGameObjectWithTag("Parent");
        dummyPlane = GameObject.FindGameObjectWithTag("Plane");

        if (parentGO == null)
        {
            Debug.LogError("ParentGO not found! Ensure it has the tag 'Parent'.");
        }

        if (dummyPlane == null)
        {
            Debug.LogError("DummyPlane not found! Ensure it has the tag 'Plane'.");
        }
    }
    void Update() {
        // Debug.Log($"{spawningHouse}");

        if (spawningHouse) {
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
            if (Physics.Raycast(new Ray(laserAnchor.position, laserAnchor.forward), out hitResult, 10))
            {
                if (hitResult.collider != null && hitResult.collider.gameObject == dummyPlane)
                {
                    // Move ParentGO to the hit position
                    parentGO.transform.position = hitResult.point;
                    parentGO.transform.rotation = Quaternion.identity; // Optional: Align to the plane's rotation

                    Debug.Log($"House placed at: {hitResult.point}");

                    loginManager.GetBlueprint(idLocal, nameLocal);
                }
            }
        }

        
    }

    public void HandlePlacement(string id, string name)
    {

        // Debug.Log($"Inside HandlePlacement");

        spawningHouse = true;

        idLocal = id;
        nameLocal = name;
        Debug.Log($"spawningHouse is now: {spawningHouse}");
        // Debug.Log($"Plane: {parentGO.name}");

    }
}
