using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public static UIManager instance;

    private bool isMenuOpen;

    private void Awake() {
        instance = this;
    }

    public Text scoreText;
    public Button menuButton;


    private void Start() {
        menuButton.onClick.AddListener(LoadMenu);
        SceneLoader.instance.LoadSceneAdditive("JoystickScene");
    }

    public void SetScore(int value) {
        scoreText.text = value.ToString();
    }

    public void LoadMenu() {
        if (!isMenuOpen) {
            isMenuOpen = true;
            SceneLoader.instance.LoadSceneAdditive("Hafta5-Menu", DisableExtraCamerasAndEventSystems);

        } else {
            isMenuOpen = false;
            SceneLoader.instance.UnloadScene("Hafta5-Menu", EnablePhysics);
        }
    }

    public void DisableExtraCamerasAndEventSystems() {
        MainMenuManager.instance.DisableSceneCameraAndEventSystem();
        DisablePhysics();
    }

    public void DisablePhysics() {
        Time.timeScale = 0;
    }
    public void EnablePhysics() {
        Time.timeScale = 1;
    }

}
    
