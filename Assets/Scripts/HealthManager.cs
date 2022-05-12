using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {
    public float maxHealth = 100;
    public float currentHealth = 100;

    public void ReduceHealth(float damage) {
        currentHealth-=damage;
        if (currentHealth<0) {
            currentHealth = 0;
        }
        if (currentHealth==0) {
            // die
            GetComponent<Animator>().SetBool("Die", true);
        }
        GetComponent<HUDManagerController>().hudManager.SetHealthProgressbar(currentHealth / maxHealth);
    }
}
