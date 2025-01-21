using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseItemListDisplay : MonoBehaviour
{
    [SerializeField] private Transform parentTransform;
    [SerializeField] private HouseItemDisplay houseDisplayPrefab;
    [SerializeField] private LoginManager loginManager;

    public void InitializeHouseItems(List<BlueprintsInfo.Item> houseItems)
    {
        foreach (BlueprintsInfo.Item houseItem in houseItems)
        {
            HouseItemDisplay display = (HouseItemDisplay)Instantiate(houseDisplayPrefab);
            display.transform.SetParent(parentTransform, false);
            display.Initialize(houseItem, loginManager);
        }
    }
}
