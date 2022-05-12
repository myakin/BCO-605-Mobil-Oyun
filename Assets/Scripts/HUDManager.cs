using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {
    public Text nameText;
    public Image healthProgressbar;
    private Transform mainCamera;

    private void Update() {
        if (!mainCamera) {
            mainCamera = Camera.main.transform;
        }

        transform.rotation = mainCamera.rotation;
    }

    public void SetHealthProgressbar(float ratio) {
        healthProgressbar.fillAmount = ratio;
    }
    
    public void SetCharacterName(string aName) {
        nameText.text = aName;
    }

}
