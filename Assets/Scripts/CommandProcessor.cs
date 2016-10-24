using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System.IO;

public delegate void aDisplayer(String value);

public class CommandProcessor
{
    public CommandProcessor()
    {
    }
    //A message to be displayed if text does not match any options given
    public void Parse(String pCmdStr, aDisplayer display)
    {
        String strResult = "Do not understand";
        //Splits the case words individually into parts so input text can be recognised and advance the game flow
        char[] charSeparators = new char[] { ' ' };
        pCmdStr = pCmdStr.ToLower();
        String[] parts = pCmdStr.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);

        // this is for picking up items, this is looking for two parts, pick and up. If these are inputted via text 
        switch (parts[0])
        {
            case "pick":
                if (parts[1] == "up")
                {
                    Debug.Log("Got Pick up");
                    strResult = "Got Pick up";

                    if (parts.Length == 3)
                    {
                        String param = parts[2];
                    }// do pick up command
                     // GameModel.Pickup();
                }
                break;
            //Looking for the parts or three words for the options in game and matching the result with current scene and current player
            case "shoot":
                if ((parts[1] == "through" && parts[2] == "door") || parts[1] == "door")
                {
                    GameModel.go(GameModel.DIRECTION.Shoot);
                    strResult = GameModel.currentPlayer.CurrentScene.Description;
                    display(strResult);
                }

                break;

            case "wake":
                switch (parts[1])
                {
                    case "brother":
                        Debug.Log("Got wake Brother");
                        GameModel.go(GameModel.DIRECTION.Brother);

                        break;
                    case "south":
                        Debug.Log("Got go South");
                        strResult = "Got Go South";
                        break;
                    default:
                        Debug.Log(" do not know how to go there");
                        strResult = "Do not know how to go there";
                        break;
                }// end switch

                strResult = GameModel.currentPlayer.CurrentScene.Description;
                display(strResult);
                break;
            default:
                Debug.Log("Do not understand");
                strResult = "Do not understand";
                break;

        }



    }
}


