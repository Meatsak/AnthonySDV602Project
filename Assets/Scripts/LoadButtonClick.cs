using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadButtonClick : MonoBehaviour
{

    public void LoadScene(string pSceneName)
    {
        SceneManager.LoadScene(pSceneName);
    }

    public void ShowCanvas(Canvas pCanvas)
    {

        pCanvas.gameObject.SetActive(true);
        Debug.Log(gameObject.name);
        Canvas[] canvases = gameObject.GetComponentsInChildren<Canvas>();

        foreach (Canvas cnv in canvases)
        {
            if (cnv.name != pCanvas.name)
            {
                cnv.gameObject.SetActive(false);
            }
        }

    }
}

