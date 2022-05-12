using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienEnemyController : EnemyController {
    public float specialForceDamage;

    public void UseSpecialForce() {

    }

    public override void Fire() {
        Debug.Log("Alien Enemy fires");
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("AlienEnemyController -> "+other.name);
    }
}
