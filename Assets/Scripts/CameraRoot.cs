using UnityEngine;
using System.Collections;
//Destroys and creates the same part in the game when a new screen is opened
public class CameraRoot : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    //This is used to initialize
    void Start()
    {
        GameModel.makeScenes();
    }
    //Updated once per frame
    void Update()
    {

    }
}
