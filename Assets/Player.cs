using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private KeyCode keyForward = KeyCode.W;
    [SerializeField] private KeyCode keyBackward = KeyCode.S;
    [SerializeField] private KeyCode keyLeft = KeyCode.A;
    [SerializeField] private KeyCode keyRight = KeyCode.D;
    [SerializeField] private Vector3 moveDirection = Vector3.forward;
    [SerializeField] private Vector3 moveSide = Vector3.right;
    public bool[,] map = {{true, true}, {true, true}};

    private void Update()
    {
        if (Input.GetKeyDown(keyForward))
        {
            if (Check(GetComponent<Transform>().position + moveDirection))
                GetComponent<Transform>().position += moveDirection;
        }
        if (Input.GetKeyDown(keyBackward))
        {
            if (Check(GetComponent<Transform>().position - moveDirection))
                GetComponent<Transform>().position -= moveDirection;
        }
        if (Input.GetKeyDown(keyRight))
        {
            if (Check(GetComponent<Transform>().position + moveSide))
                GetComponent<Transform>().position += moveSide;
        }
        if (Input.GetKeyDown(keyLeft))
        {
            if (Check(GetComponent<Transform>().position - moveSide))
                GetComponent<Transform>().position -= moveSide;
        }
    }
    
    public bool Check(Vector3 vector)
    {
        // return vector.x >= 0 && vector.x < map.GetLength(0) &&
        //        vector.z >= 0 && vector.z < map.GetLength(1) &&
        //        map[(int) vector.x, (int) vector.z];
        return true;
    }
}
