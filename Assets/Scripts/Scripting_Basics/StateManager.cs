using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle,
    Walking,
    Running,
    Attacking
}
public class StateManager : MonoBehaviour
{
    public PlayerState currState;

    void Start()
    {
        //KeyCode is an enum
        //Input.GetKey(KeyCode.Space);

        currState = PlayerState.Idle;
    }
}
