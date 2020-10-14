
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool hasGameEnded = false;
    public GameObject levelCompleteUI;
    public float restartDelaySeconds = 2f;
    public float loadNextLevelWaitSeconds = 2f;
    public void EndGame() {
        if (hasGameEnded == false) {
            hasGameEnded = true;
            Invoke("Restart", restartDelaySeconds);
        }
    }

    void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CompleteLevel() {
        levelCompleteUI.SetActive(true);
        Invoke("LoadNextLevel", loadNextLevelWaitSeconds);
    }

    public void LoadNextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
