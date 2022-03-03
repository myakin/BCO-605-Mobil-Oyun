using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationOnAxis : MonoBehaviour
{
    public float speed = 5;
    public enum RotationAxis { aroundForwardAxis, aroundUpAxis, aroundRightAxis };
    public RotationAxis axisChoice;
    private Vector3 rotationPattern;

    
    void Update()
    {
        if (axisChoice==RotationAxis.aroundForwardAxis) {
            rotationPattern = new Vector3(0, 0, speed * Time.deltaTime);

        } else if (axisChoice==RotationAxis.aroundUpAxis) {
            rotationPattern = new Vector3(0, speed * Time.deltaTime, 0);

        } else if (axisChoice==RotationAxis.aroundRightAxis) {
            rotationPattern = new Vector3(speed * Time.deltaTime, 0, 0);

        }

        transform.rotation *= Quaternion.Euler(rotationPattern);
    }
}
