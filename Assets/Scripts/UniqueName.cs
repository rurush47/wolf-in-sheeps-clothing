using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniqueName : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        
        foreach (var found_game_object in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {
            if (found_game_object.name == gameObject.name && found_game_object.GetInstanceID() != gameObject.GetInstanceID())
            {
                Destroy(gameObject);
            }
        }

    }

}