using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    public static SceneLoader instance;
    
    private void Awake() {
        if (instance==null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            if (instance!=this) {
                Destroy(gameObject);
            }
        }
    }

    public void LoadSpecificScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadNextLevel() {
        // su anki levelin indexini tespit et
        int currentIndex = SceneManager.GetActiveScene().buildIndex;

        // indexi 1 artir
        int nextLevel = currentIndex + 1;

        // index+1'deki leveli yukle
        SceneManager.LoadScene(nextLevel);
    }

    public void ReloadCurrentLevel() {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
    }
}
