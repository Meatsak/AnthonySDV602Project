﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextInput : MonoBehaviour
{
    InputField input;
    InputField.SubmitEvent se;
    InputField.OnChangeEvent ce;
    public Text output;

    public void TextUpdate(string aStr)
    {
        output.text = aStr;
    }

    // Handles the input field for users to enter choices and submit
    void Start()
    {
        //GameModel.makeScenes();
        input = this.GetComponent<InputField>();
        se = new InputField.SubmitEvent();
        se.AddListener(SubmitInput);
        /*
		ce = new InputField.OnChangeEvent();
		ce.AddListener(ChangeInput);
		*/
        input.onEndEdit = se;
        output.text = GameModel.currentPlayer.CurrentScene.Description;
        //input.onValueChanged = ce;

    }


    //Gets current text and outputs the correct text via the command processor
    private void SubmitInput(string arg0)
    {
        string currentText = output.text;

        CommandProcessor aCmd = new CommandProcessor();


        aCmd.Parse(arg0, TextUpdate);

        input.text = "";
        input.ActivateInputField();



    }
    
    private void ChangeInput(string arg0)
    {
        Debug.Log(arg0);
    }
}
