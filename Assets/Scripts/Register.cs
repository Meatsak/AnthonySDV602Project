using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
using System.Text.RegularExpressions;

public class Register : MonoBehaviour
{

    public GameObject username;
    public GameObject password;
    public GameObject email;
    public GameObject confPassword;
    private string Username;
    private string Email;
    private string Password;
    private string ConfPassword;  

    // Use this for initialization
    void Start()
    {

    }

    public void RegisterButton()
    //Checks to see if username already exists
    {
        bool UN = false;
        bool EM = false;
        bool PW = false;
        bool CPW = false;
        DataService aDs = new DataService();

       
        
        
        if (Username != "")
        {
            if (!System.IO.File.Exists(@"C:/Unityfile/" + Username + ".txt"))
            {
                UN = true;
            }
            else
            {
                Debug.LogWarning("Username already exists");
            }
        }
        else
        {
            Debug.LogWarning("Username field empty");
        }
        
        if (Password != "")
        {
            if (Password.Length > 5)
            {
                PW = true;
            }
            else
            {
                Debug.LogWarning("Password must be at 6 characters long");
            }
        }
        else
        {
            Debug.LogWarning("Password field is empty");
        }
        if (ConfPassword != "")
        {
            if (ConfPassword == Password)
            {
                CPW = true;
            }
            else
            {
                Debug.LogWarning("Passwords DO NOT match");
            }
        }
        else
        {
            Debug.LogWarning("Confirm password field empty");
        }

        if (aDs.DbExists("GameDB.db") && UN && CPW && EM && PW)
        {
            aDs.Connect();
            if (Username != "" && Password != "")
            {
               // if (aDs.CheckLogin(Username, Password))
                {
                    // MOVE TO THE START SCENE TextIO 

                    SceneManager.LoadScene("TextIO");

                }
            }
        }
    }




    // Update is called once per frame
    void Update()
    {
        //Allows the user to tab through input fields
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (username.GetComponent<InputField>().isFocused)
            {
                email.GetComponent<InputField>().Select();
            }

            if (email.GetComponent<InputField>().isFocused)
            {
                password.GetComponent<InputField>().Select();
            }

            if (password.GetComponent<InputField>().isFocused)
            {
                confPassword.GetComponent<InputField>().Select();
            }

        }
        //Checks too make sure input fields are full before regestering
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Username != "" && Email != "" && Password != "" && ConfPassword != "")
            {
                RegisterButton();
            }
        }


        Username = username.GetComponent<InputField>().text;
        Email = email.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
        ConfPassword = confPassword.GetComponent<InputField>().text;

    }

}
