using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        
        //Input.GetAxis is useful only for continuous input - like for joystick
        //for keypresses use Event.current.type == EventType.KeyDown.

        // https://docs.unity3d.com/ScriptReference/KeyCode.html

        // enable pause and ingame menu
        if (Input.GetKeyDown(KeyCode.Escape))
            Debug.Log("Escape button pressed.");

        //  Time.timeScale = 0;
        //  public static float unscaledTime;
        // https://docs.unity3d.com/ScriptReference/Time-unscaledTime.html


    }

}
