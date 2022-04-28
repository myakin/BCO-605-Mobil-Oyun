using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorController : MonoBehaviour {
    public UnityEvent OnEnterTriggerEvent, OnExitTriggerEvent;

    private Animator anim;


    private void Start() {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag=="Player") {
            OpenDoor();
            if (OnEnterTriggerEvent!=null) {
                OnEnterTriggerEvent.Invoke();
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag=="Player") {
            CloseDoor();
            if (OnExitTriggerEvent!=null) {
                OnExitTriggerEvent.Invoke();
            }
        }
    }

    public void OpenDoor() {
        anim.SetBool("shouldOpen", true);
    }

    public void CloseDoor() {
        anim.SetBool("shouldOpen", false);
    }

    
}
