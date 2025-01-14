using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoginUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject loginCanvas;
    [SerializeField] private GameObject housePickCanvas;
    [SerializeField] private TMP_Text message;
    [SerializeField] private TMP_InputField usernameField; 
    [SerializeField] private TMP_InputField passwordField; 

    private LoginManager loginManager;

    private void Awake()
    {
        message.text = "";
        loginManager = GetComponent<LoginManager>();

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
        }
    }

    private void OnDisable()
    {
        if (loginManager != null)
        {
            loginManager.onLoginSuccess -= HandleLoginSuccess;
        }
    }

    private void HandleLoginSuccess()
    {
        StartCoroutine(ShowSuccessMessageCoroutine());
    }

    private IEnumerator ShowSuccessMessageCoroutine()
    {
        // When successfully logged in turn off the canvas
        loginCanvas.SetActive(false);
        housePickCanvas.SetActive(true);
        yield break;
    }

}
