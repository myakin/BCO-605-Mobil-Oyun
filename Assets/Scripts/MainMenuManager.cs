using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour {
    public Button newGameButton;

    private void Start() {
        newGameButton.onClick.AddListener(StartNewGame);
    }

    public void StartNewGame() {
        SceneLoader.instance.LoadSpecificScene("Hafta5-Level1");
    }

}
