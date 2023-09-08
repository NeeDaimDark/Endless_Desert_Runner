using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class RegisterScript : MonoBehaviour
{
    




    private string registrationUrl = "http://localhost:8000/user/register"; // Replace with your registration endpoint URL

    public TMP_InputField usernameInput;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public string UserId;

    public void RegisterUser()
    {
        string username = usernameInput.text;
        string email = emailInput.text;
        string password = passwordInput.text;

        StartCoroutine(RegisterUserCoroutine(username, email, password));
    }
    IEnumerator RegisterUserCoroutine(string username, string email, string password)
    {
        UserId = System.Guid.NewGuid().ToString();
        // Create a form to send data
        WWWForm form = new WWWForm();
        form.AddField("UserId", UserId);
        form.AddField("username", username);
        form.AddField("email", email);
        form.AddField("password", password);

        // Send a POST request to the registration endpoint
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8000/user/register", form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Registration Error: " + www.error);
            }
            else
            {
                // Registration successful, you can handle the response here
                Debug.Log("Registration Successful: " + www.downloadHandler.text);
            }
        }
    }
}
