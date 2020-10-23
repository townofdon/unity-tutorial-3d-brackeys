
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public void PlayAgain()
    {
        GameManager.getInstance().StartFirstLevel();
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
