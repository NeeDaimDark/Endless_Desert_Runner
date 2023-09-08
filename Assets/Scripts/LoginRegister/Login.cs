using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

[Serializable]
public class LoginData
{
    public string email;
    public string password;
}

public class Login : MonoBehaviour
{
    private string loginUrl = "http://localhost:8000/user/login"; // Replace with your login endpoint URL
    private string serverUrl = "http://localhost:8000/user/geInventorybymail/mohamedamine.koubaa@esprit.tn"; // Replace with your endpoint

    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public static string coins;
    public static string score;
    public static string username;

    public void LoginUser()
    {
        string email = emailInput.text;
        string password = passwordInput.text;

        LoginData loginData = new LoginData
        {
            email = email,
            password = password
        };

        string jsonData = JsonUtility.ToJson(loginData);

        StartCoroutine(LoginUserCoroutine(jsonData));
    }

    IEnumerator LoginUserCoroutine(string jsonData)
    {
        UnityWebRequest request = UnityWebRequest.Post(loginUrl, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Login Error: " + request.error);
        }
        else
        {
            string responseText = request.downloadHandler.text;
            Debug.Log("Login Successful: " + responseText);
            // You can parse the JSON response here to access the token or other data.
            StartCoroutine(GetUserData());
            Debug.Log(coins);
            Debug.Log(score);
            Debug.Log(username);
            SceneManager.LoadScene(0);
        }
    }
    IEnumerator GetUserData()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(serverUrl))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + www.error);
            }
            else
            {
                string userDataJSON = www.downloadHandler.text;

                // Parse the JSON response
                UserData userData = JsonUtility.FromJson<UserData>(userDataJSON);
                Debug.Log("userDataJSON: " + userDataJSON);

                // Store the retrieved data as strings
                coins = userData.coins.ToString();
                score = userData.score.ToString();
                username = userData.username;

                // Now that you have set the values, you can use them here
                Debug.Log("Coins: " + coins);
                Debug.Log("Score: " + score);
                Debug.Log("Username: " + username);

                SceneManager.LoadScene(0);
            }
        }
    }


}
[System.Serializable]

public class UserData
{
    public int coins;  // Change to string if coins are represented as strings
    public int score;  // Change to string if score is represented as strings
    public string username;
}

