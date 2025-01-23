using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HouseItemDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text id;
    [SerializeField] private TMP_Text username;
    [SerializeField] private Button selectButton;

    private BlueprintsInfo.Item houseItem;
    private LoginManager loginManager;

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
    }

    private void OnSelectButtonClicked()
    {
        Debug.Log("Button pressed!");
        if (loginManager != null)
        {
            Debug.Log(id.text);
            Debug.Log("Button inside!");
            loginManager.GetBlueprint(houseItem.id.ToString(), houseItem.name);
        }
    }
}
