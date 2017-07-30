using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelectionScript : MonoBehaviour {

    public void Button1v1()
    {
        GameController.Instance.AddPlayerData("Pies", 1, 1, 1);
        GameController.Instance.AddPlayerData("Wilk", 2, 1, 2);
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    public void Button2v1()
    {
        GameController.Instance.AddPlayerData("Pies", 1, 1, 1);
        GameController.Instance.AddPlayerData("Pies", 2, 2, 1);
        GameController.Instance.AddPlayerData("Wilk", 3, 1, 2);
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    public void Button2v2()
    {
        GameController.Instance.AddPlayerData("Pies", 1, 1, 1);
        GameController.Instance.AddPlayerData("Pies", 2, 2, 1);
        GameController.Instance.AddPlayerData("Wilk", 3, 1, 2);
        GameController.Instance.AddPlayerData("Wilk", 4, 2, 2);
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    public void ButtonBackToMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    

}
