using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
    public float horizontal, vertical, jump;
    public bool run;
    private Vector2 touchBeginPoint, touchMovePoint, touchEndPoint;

    private void Update() {
        GetKeyboardInput();
        GetTouchInput();
    }

    private void GetKeyboardInput() {
        horizontal = Input.GetAxis("Horizontal") * Time.deltaTime; // A(-) ve D(+) tuslari
        vertical = Input.GetAxis("Vertical") * Time.deltaTime; // S(-) ve W(+) tuslari
        jump = Input.GetAxis("Jump");
        run = Input.GetKey(KeyCode.LeftShift);
    }

    private void GetTouchInput() {
        int touchCount = Input.touchCount;
        if (touchCount>0) {
            if (touchCount==1) {
                Touch touch = Input.touches[0];
                
                if (touch.phase==TouchPhase.Began) {
                    touchBeginPoint = touch.position;
                } else if (touch.phase==TouchPhase.Moved) {
                    touchMovePoint = touch.position;
                } else if (touch.phase==TouchPhase.Ended) {
                    touchEndPoint = touch.position;
                    float deltaY = (touchEndPoint - touchBeginPoint).magnitude;
                    jump = deltaY>200 ? 1 : 0;
                }

                Vector2 direction = (touchMovePoint - touchBeginPoint).normalized;
                float delta = (touchMovePoint - touchBeginPoint).magnitude;

                horizontal = direction.x>0 ? Time.deltaTime : -Time.deltaTime;
                run = delta>300 ? true : false;
                

            } else if (touchCount==2) {
                Touch[] touches = Input.touches;
                
            }
        } else {
            jump = 0;
        }
    }

}
