using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.getInstance().StartFirstLevel();
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
