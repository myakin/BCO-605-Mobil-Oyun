using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroSceneManager : MonoBehaviour {
    public InputField userNameInput;
    public Button[] modelButtons;

    private void Start() {
        for (int i=0; i<modelButtons.Length; i++) {
            int buttonIndexNo = i;
            modelButtons[i].onClick.AddListener(
                delegate {
                    LoadPlayerWithPrefabIndex(buttonIndexNo); 
                }
            );
        }
    }

    private void LoadPlayerWithPrefabIndex(int index) {
        MultiPlayerManager.instance.LoadPlayer(modelButtons[index].GetComponentInChildren<Text>().text, userNameInput.text);
    }

}
