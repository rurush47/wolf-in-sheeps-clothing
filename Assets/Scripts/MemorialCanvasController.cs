using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemorialCanvasController : MonoBehaviour {

    public GameObject Menu;
    public Text memorial_text_field;
    public string current_memorial_text;

    public float PreviousTimeScale;
    //public float PreviousTimeScale;

    public static MemorialCanvasController Instance = null;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        current_memorial_text = "lorem ipsum";
        
        
        PreviousTimeScale = Time.timeScale;
    }

    // Use this for initialization
    void Start()
    {
        // IngameMenuCanvas/MenuButtons
        Menu = GameObject.Find("MemorialCanvas/Memorial");
        memorial_text_field = GameObject.Find("MemorialCanvas/Memorial/TextField").GetComponent<Text>();
        if (Menu.activeInHierarchy)
        {
            ToggleMenu();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Input.GetAxis is useful only for continuous input - like for joystick
        //for keypresses use Event.current.type == EventType.KeyDown.
        // https://docs.unity3d.com/ScriptReference/KeyCode.html

        //// enable pause and ingame menu
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    //Debug.Log("Escape button pressed.");
        //    ToggleMenu();
        //}

    }

    // PAUSE
    public void ToggleMenu()
    {

        //  Time.timeScale = 0;
        //  public static float unscaledTime;
        // https://docs.unity3d.com/ScriptReference/Time-unscaledTime.html

        memorial_text_field.text = current_memorial_text;

        //if (Menu.activeInHierarchy)
        //{
        //    //PreviousTimeScale = Time.timeScale;
        //    //Time.timeScale = 0;
        //}
        //else
        //{
        //    Time.timeScale = PreviousTimeScale;
        //}

        Menu.SetActive(!Menu.activeInHierarchy);

        if (Menu.activeInHierarchy)
        {
            Debug.Log("Menu.activeInHierarchy");
            PreviousTimeScale = Time.timeScale;
            Time.timeScale = 0;
        }
        else
        {
            Debug.Log("not Menu.activeInHierarchy");
            Time.timeScale = PreviousTimeScale;
        }
          
    }
    
    
    public void ButtonQuit()
    {
        ToggleMenu();
    }

}
