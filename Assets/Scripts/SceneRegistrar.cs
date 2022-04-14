using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneRegistrar : MonoBehaviour
{
    public JumpButton jumpButton, runButton;
    public FixedJoystick fixedJoystick;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<InputManager>().runButton = runButton;
        player.GetComponent<InputManager>().jumpButton = jumpButton;
        player.GetComponent<InputManager>().fixedJoystick = fixedJoystick;
        Destroy(GetComponent<SceneRegistrar>());
        
    }

    
}
