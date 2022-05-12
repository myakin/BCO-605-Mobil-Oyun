using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {
    public float speed = 10;
    public bool byPass = true;
    private float sqrRange, damage;
    private Vector3 initialPosition;
    public ParticleSystem sparkleEffect, bloodEffect;
    private List<ContactPoint> contactPoints = new List<ContactPoint>();

    public void Move(float aRange, float aDamage) {
        sqrRange = aRange * aRange;
        damage = aDamage;
        initialPosition = transform.position;
        byPass = false;
    }

    private void Update() {
        if (!byPass) {
            transform.position+=transform.forward * speed * Time.deltaTime;
            if ((transform.position - initialPosition).sqrMagnitude>sqrRange) {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision other) {
        // detect if enemy is hit, reduce its health
        // if (other.collider.tag=="Enemy") {
        if (other.collider.GetComponent<EnemyController>()) {
            other.collider.GetComponent<HealthManager>().ReduceHealth(damage);
            if (bloodEffect!=null) {
                other.GetContacts(contactPoints);
                bloodEffect.transform.position = contactPoints[0].point;
                bloodEffect.transform.rotation = Quaternion.LookRotation(contactPoints[0].normal, sparkleEffect.transform.up);
            }
        } else {
            if (sparkleEffect!=null) {
                other.GetContacts(contactPoints);
                sparkleEffect.transform.position = contactPoints[0].point;
                sparkleEffect.transform.rotation = Quaternion.LookRotation(contactPoints[0].normal, sparkleEffect.transform.up);
            }
        }
        Destroy(gameObject);
    }

}
