using UnityEngine;
using UnityEngine.UI;
using TMPro; // Import TextMeshPro namespace

public class LoginUIManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField usernameField; // Use TMP_InputField
    [SerializeField] private TMP_InputField passwordField; // Use TMP_InputField
    [SerializeField] private Button loginButton;
    [SerializeField] private LoginManager loginManager;
    // [SerializeField] private TextMeshProUGUI feedbackText; // Optional for feedback messages

    private void Start()
    {
        // Ensure the login button triggers the login process
        loginButton.onClick.AddListener(OnLoginButtonClicked);

        
        // if (feedbackText != null)
        //     feedbackText.text = string.Empty;
    }

    private void OnLoginButtonClicked()
    {
        string username = usernameField.text; 
        string password = passwordField.text; 

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            // if (feedbackText != null)
            // {
            //     feedbackText.text = "Username or password cannot be empty!";
            //     feedbackText.color = Color.red;
            // }
            Debug.LogError("Username or password cannot be empty!");
            return;
        }

        // Call the LogIn method from LoginManager
        loginManager.LogIn(username, password);
    }

    // public void DisplayFeedback(string message, bool isSuccess)
    // {
    //     if (feedbackText != null)
    //     {
    //         feedbackText.text = message;
    //         feedbackText.color = isSuccess ? Color.green : Color.red;
    //     }
    // }
}
