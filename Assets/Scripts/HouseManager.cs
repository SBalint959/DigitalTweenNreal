using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseManager : MonoBehaviour
{
    [SerializeField] JSONPasrser jsonParser;

    private void OnEnable()
    {
        jsonParser.JSONParseAction += moveHouse;
    }

    private void OnDisable()
    {
        jsonParser.JSONParseAction -= moveHouse;
    }

    private void moveHouse(HouseInfo houseInfo)
    {
        // Debug.LogWarning("TU SAM " + houseInfo.Items.Count);
        // foreach (Item item in houseInfo.Items)
        // {
        //     Debug.Log(item.Type + " " + item.Name + ": position " + item.Position + "; orientation " + item.Orientation);
        // }
    }
}
