using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HouseItemDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text id;
    [SerializeField] private TMP_Text name;

    private BlueprintsInfo.Item houseItem;

    public void Initialize(BlueprintsInfo.Item houseItem)
    {
        this.houseItem = houseItem;
        if (id != null)
        {
            id.text = "ID: " + houseItem.id;
            id.fontSize = 12;
        }
        if (name != null)
        {
            name.text = houseItem.name;
            name.fontSize = 12;
        }
    }
}
