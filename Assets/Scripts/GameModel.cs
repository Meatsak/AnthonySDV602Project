using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System.IO;



using System.Text;

// Is this a factory?

public static class GameModel
{
    //Creates a storage area for instances scenes and players
    private static String _name;
    private static Player _player = new Player();
    public enum DIRECTION { Brother, Shoot, South, East, West };
    private static Scene _start_scene; // ??
    public static Players PlayersInGame = new Players();

    //Gets and returns the value of the object
    public static Scene Start_scene
    {
        get
        {
            return _start_scene;
        }
        set
        {
            _start_scene = value;
        }

    }

    public static string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }

    }

    public static Player currentPlayer
    {
        get
        {
            return _player;
        }
        set
        {
            _player = value;
        }

    }
    //Defines the direction or move of the current player
    public static void go(DIRECTION pDirection)
    {
        currentPlayer.Move(pDirection);
    }

    //Creates the first scene
    public static void makeScenes()
    {
        Scene tmp;
        DataService theService = new DataService();

        // uncomment the following two lines to start with an empty database
       // if(theService.DbExists("GameNameDb"))
        	//theService.deleteDatabaseFile();

        // Watch out DbExists has a side effect!
        if (theService.DbExists("GameNameDb"))
        {
            theService.Connect();
            theService.LoadScenes();
            currentPlayer.InitialisePlayerState();
            currentPlayer.CurrentScene = Scene.AllScenes[0];
        }
        else
        {

            Start_scene = new Scene();

            tmp = new Scene();
            Start_scene.ID = 1;
            Start_scene.Brother = tmp;
            Start_scene.Description = @"It’s been one week now since you and your brother had to kill your neighbours and friends in an effort to escape your home
town and flee into the mountains to stop a fate worse than death happening to either of you. After the meteorite landed in your home town releasing the contagion 
the government have called element 115 the infection was very rapid releasing the mysterious element into the air, within hour’s people started to lose control of 
their minds and started eating the brains of people who were not infected. It is still unknown to you why you or your brother have not been affected by the incomprehensible
virus but you take no chances at finding out after seeing your best friend attacked by one of these ‘Zombies’ and almost instantly after, watching his eyes turn glassy 
glowing blue and running straight at you screaming trying to attack you….Luckily you still had one shot left in your shotgun to quickly detach his head from his body.
You and your brother arrived at your family’s hunting hut up in the mountains two days ago after a four day walk across the country. Hungry scared and thirsty the hut was
like heaven as it was always full of food and contained water to sustain five people for about 6 months, you don’t trust the spring water. Also the hut is packed full
of weapons and ammunition.You and your brother managed to save your two dogs before leaving for the mountains who are happily lying down in front of the open fire.
Your brother is asleep in the bunk room, when you hear one of the dogs with a low growl rumbling in his throat, you grab the shot gun and open the door to hear footsteps 
coming from the bush up the walk track. You shut the door and tell your dogs to be quiet.As the footsteps grow louder coming towards the hut you
A)  Wake up brother
B)	Shoot through door
C)	Open the door";



            //The next descriptions after one of the options from the first scene has been input
            tmp.ID = 2;
            Start_scene.Brother.Description = "You wake up your brother and organise a plan to ambush whoever is outside, your brother goes round the back of the hut";
            tmp.Shoot = Start_scene;

            tmp.Shoot = new Scene();
            tmp.Shoot.ID = 3;
            Start_scene.Shoot.Description = "You shoot through door";

            currentPlayer.InitialisePlayerState();
            currentPlayer.CurrentScene = Start_scene;

            theService.Connect();
            theService.SaveScenes();

        }
    }
}

