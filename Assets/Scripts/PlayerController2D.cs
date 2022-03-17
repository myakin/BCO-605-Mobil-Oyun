using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.2f; // alternatifi: public float moveSpeed = 0.2f;
    [SerializeField] private float runValue = 2;
    [SerializeField] private float jumpForce = 200;
    [SerializeField] private Animator animator;
    private SpriteRenderer targetRenderer;
    private float multiplier = 1;
    private bool isJumping, isFalling, willFall;
    private Vector2 originalOffset, originalSize;
    private IEnumerator jumpResetCoroutine;
    private float oldY;
    
    

    private void Start() {
        // level 3
        targetRenderer = GetComponent<SpriteRenderer>();

        UIManager.instance.SetScore(DataManager.instance.score);

        originalOffset = GetComponent<CapsuleCollider2D>().offset;
        originalSize = GetComponent<CapsuleCollider2D>().size;
    }
    
    void Update()
    {
        float hor = Input.GetAxis("Horizontal") * Time.deltaTime; // A(-) ve D(+) tuslari
        // float ver = Input.GetAxis("Vertical") * Time.deltaTime; // S(-) ve W(+) tuslari
        float jump = Input.GetAxis("Jump");
        

        // level 3
        if (hor<0 && !targetRenderer.flipX) {
            targetRenderer.flipX=true;
        } else if (hor>0 && targetRenderer.flipX) {
            targetRenderer.flipX=false;
        }

        
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

        
        if (jump>0 && !isJumping) {
            isJumping = true;
            animator.SetFloat("moveMode",4);

            GetComponent<CapsuleCollider2D>().offset = new Vector2(originalOffset.x, 1.68f);
            GetComponent<CapsuleCollider2D>().size = new Vector2(originalSize.x, 1.53f);
            // GetComponent<Rigidbody2D>().simulated = false;
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce);
        }

        transform.position += transform.right * (hor * moveSpeed * multiplier);
        CheckGround();
        oldY = transform.position.y;
    }

    private void CheckGround() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, 0.3f, 1<<31);
        if (!hit) {
            willFall = true;
        }
        if(isJumping && willFall && hit && transform.position.y<oldY) {
            willFall = false;
            animator.SetTrigger("fall");
            ResetColliderSizeAndOffset();
        }

        if (hit && hit.transform.tag=="Platform") {
            transform.SetParent(hit.transform);
        } else {
            transform.SetParent(null);
        }   
    }

    public void ResetColliderSizeAndOffset() {
        GetComponent<CapsuleCollider2D>().offset = originalOffset;
        GetComponent<CapsuleCollider2D>().size = originalSize;
        // GetComponent<Rigidbody2D>().simulated = true;
        if (jumpResetCoroutine==null) {
            jumpResetCoroutine = Resetjump();
            StartCoroutine(jumpResetCoroutine);
        }
    }

    private IEnumerator Resetjump() {
        yield return new WaitForSeconds(0.2f);
        isJumping = false;
        animator.SetBool("proceedToJumpEnd", false);
        jumpResetCoroutine = null;
    }
}
