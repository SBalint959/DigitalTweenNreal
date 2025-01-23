using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoginUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject loginCanvas;
    [SerializeField] private GameObject housePickCanvas;
    [SerializeField] private TMP_InputField usernameField; 
    [SerializeField] private TMP_InputField passwordField;
    [SerializeField] private Button loginButton;

    private LoginManager loginManager;
    private HouseItemListDisplay houseDisplay;

    private void Awake()
    {
        loginCanvas.SetActive(true);
        housePickCanvas.SetActive(false);

        loginManager = GetComponent<LoginManager>();
        houseDisplay = housePickCanvas.GetComponent<HouseItemListDisplay>();

        if (loginManager == null)
        {
            Debug.LogError("LoginManager component not found!");
        }
    }

    private void OnEnable()
    {
        if (loginManager != null)
        {
            loginManager.onLoginSuccess += HandleLoginSuccess;
            loginManager.onListBlueprintsReady += HandleBlueprintsReady;
        }
    }

    private void OnDisable()
    {
        if (loginManager != null)
        {
            loginManager.onLoginSuccess -= HandleLoginSuccess;
            loginManager.onListBlueprintsReady -= HandleBlueprintsReady;
        }
    }

    public void OnLoginButtonClicked()
    {
        string username = usernameField.text;
        string password = passwordField.text;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            Debug.LogError("Username or password cannot be empty!");
            return;
        }
        usernameField.text = "";
        passwordField.text = "";

        // Call the LogIn method from LoginManager
        loginManager.LogIn(username, password);
    }

    public void onFillInfoButtonClicked()
    {
        usernameField.text = "project";
        passwordField.text = "glAR!1234";
    }

    private void HandleLoginSuccess()
    {
        loginCanvas.SetActive(false);
        housePickCanvas.SetActive(true);
    }

    private void HandleBlueprintsReady(BlueprintsInfo blueprintsInfo)
    {
        Debug.Log("Success!");
        Debug.Log(blueprintsInfo.data.blueprints.totalCount);
        Debug.Log(houseDisplay);
        if (houseDisplay != null)
        {
            houseDisplay.InitializeHouseItems(blueprintsInfo.data.blueprints.items);
        }
    }

}
