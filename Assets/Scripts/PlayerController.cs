using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    [SerializeField] private float rotationSpeed = 20f;
    [SerializeField] private WeaponController weaponController;
    public Transform mainCamera;
    private Animator animator;
    

    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
        GetComponent<HUDManagerController>().hudManager.SetCharacterName("Murat");
    }

    // Update is called once per frame
    void Update() {
        float hor = Input.GetAxis("Horizontal"); // A(-) ve D(+) tuslari
        float ver = Input.GetAxis("Vertical"); // S(-) ve W(+) tuslari
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime;
        float fire = Input.GetAxis("Fire1");

        animator.SetFloat("horizontal", hor);
        animator.SetFloat("vertical", ver);
        transform.rotation *= Quaternion.Euler(new Vector3(0, mouseX * rotationSpeed, 0));
        mainCamera.transform.rotation *= Quaternion.Euler(new Vector3(-mouseY * rotationSpeed, 0, 0));

        if (fire>0) {
            weaponController.Fire();
        }
        
    }
}
