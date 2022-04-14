using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public static UIManager instance;

    private void Awake() {
        instance = this;
    }
    

    public Text scoreText;

    private void Start() {
        SceneLoader.instance.LoadSceneAdditive("JoystickScene");
    }

    public void SetScore(int value) {
        scoreText.text = value.ToString();
    }

}
    
