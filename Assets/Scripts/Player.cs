using System;
[Serializable]

public class Player
{
  
    private static int _player_number = 0;

    // Instance
    private int _number = (Player._player_number++);
    private string _name;
    private Item[] _inventory;    // Wrong type?
    private Scene _currentScene;

    //Gets and returns the value of the inatance
    public Scene CurrentScene
    {
        get
        {
            return _currentScene;
        }
        set
        {
            _currentScene = value;
        }
    }
    public String Name
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
    private void AddExperience()
    {
        Persist.control.Experience = Persist.control.Experience + 1;
    }
    //Defines the direction of the current scene for what the user types in
    //I could change move to choice seeming I dont use N, E, S, W
    public void Move(GameModel.DIRECTION pDirection)
    {
        switch (pDirection)
        {
            case GameModel.DIRECTION.Brother: 

                if (_currentScene.Brother != null)
                {
                    _currentScene = _currentScene.Brother;
                }
                break;
            case GameModel.DIRECTION.Shoot:
                if (_currentScene.Shoot != null)
                {
                    _currentScene = _currentScene.Shoot;
                }
                break;
                //Not using these ones yet
            case GameModel.DIRECTION.East:
                break;
            case GameModel.DIRECTION.West:
                break;
        }
    }
    public void InitialisePlayerState()
    {
        if (Persist.control != null)
        {
            Persist.control.Experience = 10;
            Persist.control.Health = 5;
        }
    }
    public Player()
    {
        //InitialisePlayerState();
    }
}


