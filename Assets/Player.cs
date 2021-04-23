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

    public Map Map = new Map(new[,]
        {{true, true, true, true}, {true, true, true, true}, {true, true, true, true}, {true, true, true, true}});
    public GameObject Platform;

    private void Start()
    {
        for (var x = 0; x < Map.map.GetLength(0); x++)
        {
            for (var z = 0; z < Map.map.GetLength(0); z++)
            {
                Instantiate(Platform, new Vector3(x, 0, z), new Quaternion());
            }
        }
        
        GetComponent<Transform>().position = new Vector3(0,0.2f,0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(keyForward))
        {
            if (Map.Check(GetComponent<Transform>().position + moveDirection))
                GetComponent<Transform>().position += moveDirection;
        }
        if (Input.GetKeyDown(keyBackward))
        {
            if (Map.Check(GetComponent<Transform>().position - moveDirection))
                GetComponent<Transform>().position -= moveDirection;
        }
        if (Input.GetKeyDown(keyRight))
        {
            if (Map.Check(GetComponent<Transform>().position + moveSide))
                GetComponent<Transform>().position += moveSide;
        }
        if (Input.GetKeyDown(keyLeft))
        {
            if (Map.Check(GetComponent<Transform>().position - moveSide))
                GetComponent<Transform>().position -= moveSide;
        }
    }
}

public class Map
{
    public readonly bool[,] map;

    public Map(bool[,] map)
    {
        this.map = map;
    }

    public bool Check(Vector3 vector)
    {
        return vector.x >= 0 && vector.x < map.GetLength(0) &&
               vector.z >= 0 && vector.z < map.GetLength(1) &&
               map[(int) vector.x, (int) vector.z];
    }
}
