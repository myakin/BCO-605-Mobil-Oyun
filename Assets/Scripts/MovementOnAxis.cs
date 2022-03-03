using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementOnAxis : MonoBehaviour {
    public float speed = 0.1f;
    public float range = 4;
    public enum MovementDirection { forward, up, right };
    public MovementDirection direction;


    private float multiplier = 1;
    private Vector3 controlPosition;
    private Vector3 movementDirection;

    
    void Start()
    {
        controlPosition = transform.position;
    }

    void Update()
    {
        if (direction==MovementDirection.forward) {
            movementDirection = transform.forward;
        } else if (direction==MovementDirection.up) {
            movementDirection = transform.up;
        } else if (direction==MovementDirection.right) {
            movementDirection = transform.right;
        }

        transform.position += movementDirection * (speed * multiplier);

        if ((transform.position - controlPosition).magnitude > range) {
            multiplier *= -1;
            controlPosition = transform.position;
        }
    }
}
