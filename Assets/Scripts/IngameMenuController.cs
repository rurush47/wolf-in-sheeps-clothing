// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameMenuController : MonoBehaviour
{

    public GameObject IngameMenu;

    public float PreviousTimeScale;

    void Awake()
    {
        // get instance of menu
    }

    // Use this for initialization
    void Start ()
    {
        // IngameMenuCanvas/MenuButtons
        IngameMenu = GameObject.Find("IngameMenuCanvas/MenuButtons");
        if (IngameMenu.activeInHierarchy)
        {
            IngameMenu.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Input.GetAxis is useful only for continuous input - like for joystick
        //for keypresses use Event.current.type == EventType.KeyDown.
        // https://docs.unity3d.com/ScriptReference/KeyCode.html

        // enable pause and ingame menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Debug.Log("Escape button pressed.");
            ToggleIngameMenu();
        }

    }

    // PAUSE
    public void ToggleIngameMenu()
    {

        //  Time.timeScale = 0;
        //  public static float unscaledTime;
        // https://docs.unity3d.com/ScriptReference/Time-unscaledTime.html

        IngameMenu.SetActive(!IngameMenu.activeInHierarchy);

        if (IngameMenu.activeInHierarchy)
        {
            PreviousTimeScale = Time.timeScale;
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = PreviousTimeScale;
        }
            
    }

    public void ButtonResume()
    {
        ToggleIngameMenu();
    }

    public void ButtonOptions()
    {
        Debug.Log("ButtonOptions(): not implemented.");
    }

    public void ButtonBackToMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }

}
