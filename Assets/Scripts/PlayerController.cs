using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float moveSpeed = 0.2f; // alternatifi: public float moveSpeed = 0.2f;
    [SerializeField] private float rotationSpeed = 20f;
    public Transform mainCamera;
    // private float hor, ver, mouseX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        float hor = Input.GetAxis("Horizontal") * Time.deltaTime; // A(-) ve D(+) tuslari
        float ver = Input.GetAxis("Vertical") * Time.deltaTime; // S(-) ve W(+) tuslari
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime;

        // Vector3 offset = transform.forward * (ver * moveSpeed);
        // offset = offset + transform.right * (hor * moveSpeed);
        // transform.position = transform.position + offset;

        // Vector3 offset = transform.forward * (ver * moveSpeed) + transform.right * (hor * moveSpeed);
        // transform.position = transform.position + offset;

        // transform.position = transform.position + transform.forward * (ver * moveSpeed) + transform.right * (hor * moveSpeed);

        transform.position += transform.forward * (ver * moveSpeed) + transform.right * (hor * moveSpeed);
        transform.rotation *= Quaternion.Euler(new Vector3(0, mouseX * rotationSpeed, 0));

        // mainCamera.rotation *= Quaternion.Euler(new Vector3(-mouseY * rotationSpeed,0, 0));
    }

    // private void FixedUpdate() {
    //     transform.position += transform.forward * (ver * moveSpeed) + transform.right * (hor * moveSpeed);
    //     transform.rotation *= Quaternion.Euler(new Vector3(0, mouseX, 0));
    // }


}
