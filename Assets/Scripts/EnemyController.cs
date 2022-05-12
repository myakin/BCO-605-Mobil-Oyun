using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public float moveSpeed;
    public float damage;

    public virtual void Fire() {
        Debug.Log("Enemy fires");
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("EnemyController -> "+other.name);
    }
}
