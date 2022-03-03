using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.2f; // alternatifi: public float moveSpeed = 0.2f;
    private SpriteRenderer targetRenderer;

    private void Start() {
        // level 3
        targetRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        float hor = Input.GetAxis("Horizontal") * Time.deltaTime; // A(-) ve D(+) tuslari
        // float ver = Input.GetAxis("Vertical") * Time.deltaTime; // S(-) ve W(+) tuslari
        

        transform.position += transform.right * (hor * moveSpeed);
        
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

    }
}
