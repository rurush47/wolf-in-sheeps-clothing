// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GameController.Instance.ResetGame();
    }

    public void ButtonStart()
    {
        //SceneManager.LoadScene("Gameplay", LoadSceneMode.Single);
        SceneManager.LoadScene("PlayersSelection", LoadSceneMode.Single);
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }
    
}
