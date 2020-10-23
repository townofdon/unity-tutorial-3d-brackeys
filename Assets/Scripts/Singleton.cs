using UnityEngine;
using UnityEngine.SceneManagement;

// THIS IS AN EXAMPLE OF A SINGLETON DESIGN PATTERN.

public class Singleton : MonoBehaviour
{
    private static Singleton _instance;
    private static string _parentSceneName;

    // Start is called before the first frame update
    private void Start() {
        _parentSceneName = SceneManager.GetActiveScene().name;
        if (_instance != null) {
            Destroy(this.gameObject);
            return;
        }

        // We are the highlander. There can be only one.
        _instance = this;

        // Become immortal
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    public static Singleton getInstance() {
        return _instance;
    }

    public static string getScene() {
        return _parentSceneName;
    }
}
