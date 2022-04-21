using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    public static SceneLoader instance;

    public delegate void DelegateWithNoArguments();
    public DelegateWithNoArguments onSceneLoadedAction, onSceneUnloadedAction;

    
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

    
    public void LoadSceneAdditive(string aSceneName, DelegateWithNoArguments continueWith = null) {
        onSceneLoadedAction = continueWith;
        SceneManager.sceneLoaded+=OnSceneLoaded;
        SceneManager.LoadScene(aSceneName, LoadSceneMode.Additive);
    }
        
    public void UnloadScene(string aSceneName, DelegateWithNoArguments continueWith = null) {
        onSceneUnloadedAction = continueWith;
        SceneManager.sceneUnloaded+=OnSceneUnloaded;
        SceneManager.UnloadSceneAsync(aSceneName);   
        if (continueWith!=null) {
            continueWith();
        }
    }

    private void OnSceneLoaded(Scene aScene, LoadSceneMode aLoadSceneMode) {
        if (onSceneLoadedAction!=null) {
            onSceneLoadedAction();
            onSceneLoadedAction = null;
        }
        SceneManager.sceneLoaded-=OnSceneLoaded;
    }

    private void OnSceneUnloaded(Scene aScene) {
        if (onSceneUnloadedAction!=null) {
            onSceneUnloadedAction();
            onSceneUnloadedAction = null;
        }
        SceneManager.sceneUnloaded-=OnSceneUnloaded;
    }
}
