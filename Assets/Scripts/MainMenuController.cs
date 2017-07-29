// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    
    public void ButtonStart()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }
    
}
