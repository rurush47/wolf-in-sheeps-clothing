// using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public struct PlayerStruct
{
    public string name;
    public int id;
    public int skin;    //model data?
    public int team;    //0-sheep, 1-dog, 2-wolf
    //public int score;   //applicable?
}

public class GameController : MonoBehaviour
{

    public List<PlayerStruct> player_data_list;

    public static GameController Instance = null;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        player_data_list = new List<PlayerStruct>();
    }

    // Use this for initialization
    void Start() {
        //SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
        SceneManager.LoadScene("Intro", LoadSceneMode.Additive);
    }
    
    public void AddPlayerData(string player_name, int player_id, int player_skin_id, int team = 1)
    {
        PlayerStruct new_player = new PlayerStruct();

        new_player.name = player_name;
        new_player.id = player_id;
        new_player.skin = player_skin_id;
        new_player.team = team;    //0-sheep, 1-dog, 2-wolf

        player_data_list.Add(new_player);
    }

    public void ResetGame()
    {
        player_data_list.Clear();
    }

}
