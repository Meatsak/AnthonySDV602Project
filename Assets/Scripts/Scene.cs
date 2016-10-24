using System;
using System.Collections.Generic;

[Serializable]

//Creates instances of players and the number of scenes
public class Scene
{
    private Players _players = new Players();
    private Scene[] _connected_scenes = new Scene[4];
    private string _description = "default";
    private int _id;
    public static List<Scene> AllScenes = new List<Scene>();

    public int ID
    {
        get
        {
            return _id;
        }
        set
        {
            _id = value;
        }
    }

    public string Description
    {
        get
        {
            return _description;
        }
        set
        {
            _description = value;
        }
    }
   // Creates a scene referanece for choices made from text input
    public Scene Shoot
    {
        get
        {
            return _connected_scenes[(int)GameModel.DIRECTION.Shoot];
        }
        set
        {
            _connected_scenes[(int)GameModel.DIRECTION.Shoot] = value;
        }
    }



    public Scene Brother
    {
        get
        {
            return _connected_scenes[(int)GameModel.DIRECTION.Brother];
        }
        set
        {
            _connected_scenes[(int)GameModel.DIRECTION.Brother] = value;
        }
    }
    //for next scene
    public Scene()
    {
        Scene.AllScenes.Add(this);
    }


}


