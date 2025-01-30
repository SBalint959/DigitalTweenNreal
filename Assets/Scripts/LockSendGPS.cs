using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockSendGPS : MonoBehaviour
{
    [SerializeField] private HouseMover houseMover;
    [SerializeField] private JSONSender jsonSender;
    [SerializeField] private GPSReceiver gpsReceiver;
    [SerializeField] private LoginManager loginManager;


    // Update is called once per frame

    // gpsReceiver.gpsData
    public void OnLockButtonClicked()
    {
        // disable house movement
        houseMover.isHouseLocked = true;
        // get geolocation
        // put geolocation inside the house json
        string json = loginManager.getActiveHouseJSON();
        //.Replace("−", "-");
        // send final json to server
        string finalJson = "{\"GPS\":{\"X\":" + gpsReceiver.gpsData.X.ToString() + ",\"Z\":" + gpsReceiver.gpsData.Z.ToString() + "}," + json.Substring(1);
        jsonSender.SendJSON("model.json", finalJson);

        gameObject.SetActive(false);
    }
}
