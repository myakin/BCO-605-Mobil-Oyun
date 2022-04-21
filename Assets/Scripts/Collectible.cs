using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {
    private IEnumerator destroyCoroutine;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            if (destroyCoroutine==null) {
                destroyCoroutine = DestroyCoroutine();
                StartCoroutine(destroyCoroutine);
            }
        }
    }

    private IEnumerator DestroyCoroutine() {
        while (UIManager.instance == null) {
            yield return null;
        }

        DataManager.instance.score++;
        UIManager.instance.SetScore(DataManager.instance.score);

        Destroy(gameObject);
    }
}
