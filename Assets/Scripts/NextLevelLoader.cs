using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelLoader : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag=="Player") {
            LoadNextLevel();
        }
    }

    private void LoadNextLevel() {
        SceneLoader.instance.LoadNextLevel();
    }
}
