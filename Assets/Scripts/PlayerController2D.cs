using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.2f; // alternatifi: public float moveSpeed = 0.2f;
    [SerializeField] private float runValue = 2;
    private SpriteRenderer targetRenderer;
    private float multiplier = 1;

    private void Start() {
        // level 3
        targetRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        float hor = Input.GetAxis("Horizontal") * Time.deltaTime; // A(-) ve D(+) tuslari
        // float ver = Input.GetAxis("Vertical") * Time.deltaTime; // S(-) ve W(+) tuslari
        

        
        
        // // level 1
        // if (hor<0) {
        //     GetComponent<SpriteRenderer>().flipX=true;
        // } else if (hor>0) {
        //     GetComponent<SpriteRenderer>().flipX=true;
        // }


        // // level 2
        // if (hor<0 && !GetComponent<SpriteRenderer>().flipX) {
        //     GetComponent<SpriteRenderer>().flipX=true;
        // } else if (hor>0 && GetComponent<SpriteRenderer>().flipX) {
        //     GetComponent<SpriteRenderer>().flipX=false;
        // }

        // level 3
        if (hor<0 && !targetRenderer.flipX) {
            targetRenderer.flipX=true;
        } else if (hor>0 && targetRenderer.flipX) {
            targetRenderer.flipX=false;
        }

        // if (hor!=0f)
        //     GetComponent<Animator>().SetTrigger("Walk");
        // else 
        //     GetComponent<Animator>().SetTrigger("Idle");

        // if (hor!=0f) {
        //     // shifte basiliysa
        //     if (Input.GetKey(KeyCode.LeftShift)) {
        //         GetComponent<Animator>().SetBool("isRunning", true);
        //     } else {
        //         // shifte basili degilse
        //         GetComponent<Animator>().SetBool("isWalking", true);
        //     }
        // } else 
        //     GetComponent<Animator>().SetBool("isWalking", false);


        if (hor!=0f) {
            // shifte basiliysa
            if (Input.GetKey(KeyCode.LeftShift)) {
                multiplier = runValue;
                GetComponent<Animator>().SetFloat("moveMode", 2f);
            } else {
                // shifte basili degilse
                multiplier = 1;
                GetComponent<Animator>().SetFloat("moveMode", 1f);
            }
        } else 
            GetComponent<Animator>().SetFloat("moveMode", 0);

        
        if (Input.GetKeyDown(KeyCode.Space)) {
            GetComponent<Animator>().SetFloat("moveMode", 4f);
        }

        transform.position += transform.right * (hor * moveSpeed * multiplier);
        CheckGround();
        
    }


    // private void OnCollisionEnter2D(Collision2D other) {
    //     if(other.collider.tag=="Platform") {
    //         transform.SetParent(other.transform);
    //     }
    // }

    private void CheckGround() {
        LayerMask raycastLayer = LayerMask.NameToLayer("Default");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, 1f, raycastLayer);
        // RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, 1f, 1<<0);
        // Debug.Log(hit.transform.name);
        if (hit && hit.transform.tag=="Platform") {
            transform.SetParent(hit.transform);
        } else {
            transform.SetParent(null);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
    }
}
