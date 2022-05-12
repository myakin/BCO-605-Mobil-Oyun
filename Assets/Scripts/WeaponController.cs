using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {
    public float range = 100;
    public float damage = 10;
    public Transform bulletGenerationDummy, effectGenerationDummy;
    private bool isFiring;
    

    public void Fire() {
        if (!isFiring) {
            isFiring = true;
            Debug.Log("Fired a bullet");
            // generate a bullet prefab
            GameObject bulletObject = Instantiate(Resources.Load("Bullet") as GameObject, bulletGenerationDummy.position, bulletGenerationDummy.rotation);

            // move bullet in its forward direction
            bulletObject.GetComponent<BulletManager>().Move(range, damage);

            StartCoroutine(ReleaseFire());
        }
    }

    private IEnumerator ReleaseFire() {
        yield return new WaitForSeconds(1f);
        isFiring = false;
    }
}
