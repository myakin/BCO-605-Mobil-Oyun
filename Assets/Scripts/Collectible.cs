using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            DataManager.instance.score++;
            UIManager.instance.SetScore(DataManager.instance.score);

            Destroy(gameObject);
        }
    }
}
