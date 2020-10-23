
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool hasGameEnded = false;
    public GameObject levelCompleteUI;
    public bool ignoreMissingUI = false;
    public float restartDelaySeconds = 2f;
    public float loadNextLevelWaitSeconds = 2f;

    private static GameManager _instance;
    private string _parentSceneName;

    private void Start() {
        if (_instance != null) {
            _instance.hasGameEnded = false;
            ResetLevelCompleteUI(this.ignoreMissingUI);
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        _parentSceneName = SceneManager.GetActiveScene().name;

        // Become immortal
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    public static GameManager getInstance() {
        return _instance;
    }

    void ResetLevelCompleteUI(bool ignoreMissing = false) {
        if (_instance == null) return;

        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas == null) {
            if (!ignoreMissing) {
                Debug.LogError(string.Format("Canvas object missing in scene \"{0}\".", SceneManager.GetActiveScene().name));
            }
            return;
        }

        Transform found = canvas.transform.Find("LevelCompleteUI");
        if (found != null) {
            _instance.levelCompleteUI = found.gameObject;
        } else if (ignoreMissing) {
            return;
        } else {
            Debug.LogError(string.Format("Could not find a levelCompleteUI component in scene \"{0}\". Make sure LevelCompleteUI exists, and has a component script of the same name.", SceneManager.GetActiveScene().name));
        }
    }

    public void StartFirstLevel() {
        SceneManager.LoadScene(1);
        hasGameEnded = false;
        GameData.ResetData();
    }

    public void CompleteLevel() {
        GameData.OnLevelWin();
        if (levelCompleteUI) {
            levelCompleteUI.SetActive(true);
            Invoke("LoadNextLevel", loadNextLevelWaitSeconds);
        } else {
            Debug.LogError(string.Format("levelCompleteUI was not set in GameManager for scene \"{0}\"", _parentSceneName));
        }
    }

    void LoadNextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        hasGameEnded = false;
        GameData.OnLevelStart();
        ResetLevelCompleteUI();
    }

    public void EndGame() {
        if (hasGameEnded == false) {
            hasGameEnded = true;
            Invoke("Restart", restartDelaySeconds);
        }
    }

    void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        hasGameEnded = false;
        GameData.OnLevelStart();
        ResetLevelCompleteUI();
    }
}
