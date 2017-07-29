// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    
    public void ButtonStart()
    {
   
        // audioComponent.button_press();
        // menuButton.GetComponent<Image>().sprite = menuButton.spriteState.pressedSprite;

        //SceneManager.LoadScene("Gameplay", LoadSceneMode.Additive);
        SceneManager.LoadScene("Gameplay", LoadSceneMode.Single);

    }

    public void ButtonQuit()
    {

        //		Debug.Log ("LoadMainMenu");
        //		Application.LoadLevel("menu");
        //audioComponent.button_press();
        //		menuButton.spriteState = menuButton.spriteState.pressedSprite;
        //menuButton.GetComponent<Image>().sprite = menuButton.spriteState.pressedSprite;

        Application.Quit();

    }
    
}
