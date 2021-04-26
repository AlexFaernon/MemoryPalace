using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private KeyCode keyForward = KeyCode.W;
    [SerializeField] private KeyCode keyBackward = KeyCode.S;
    [SerializeField] private KeyCode keyLeft = KeyCode.A;
    [SerializeField] private KeyCode keyRight = KeyCode.D;
    [SerializeField] private Vector3 moveDirection = Vector3.forward;
    [SerializeField] private Vector3 moveSide = Vector3.right;

    public Map Map = new Map(
        @"********************
*###*##############*
*###*###*####*****#*
*###*##****##*###*#*
***#######*#**#####*
*#**######*##*###*#*
*##*****##**#*****#*
*######**#*######***
*######*##*#*##*#*#*
*#***##*#**#****#*##
*#*#*#**##*#*##*#*#*
*#*#*#####*######*#*
*#*#**************#*
*#*#########*####*#*
*#*##*#***##*##*#*#*
*#*##*#*#######***#*
*#****#*#*##*##*###*
*#*####*#*******#*#*
*######*###########*
********************", new Point(1,0));
    public GameObject Platform;

    private void Start()
    {
        for (var x = 0; x < Map.map.GetLength(0); x++)
        {
            for (var z = 0; z < Map.map.GetLength(0); z++)
            {
                if (Map.map[x,z])
                {
                    Instantiate(Platform, new Vector3(x, 0, z), new Quaternion());
                }
            }
        }
        
        GetComponent<Transform>().position = Map.start;
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
    public readonly Vector3 start;

    public Map(string map, Point pos)
    {
        this.map = CreateMap(map);
        start = new Vector3(pos.X, 0.2f, pos.Y);
    }

    public bool Check(Vector3 vector)
    {
        return vector.x >= 0 && vector.x < map.GetLength(0) &&
               vector.z >= 0 && vector.z < map.GetLength(1) &&
               map[(int) vector.x, (int) vector.z];
    }
    
    private static bool[,] CreateMap(string map)
    {
        var lines = map.Split(new[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
        var result = new bool[lines[0].Length, lines.Length];
        for (var x = 0; x < lines[0].Length; x++)
        for (var y = 0; y < lines.Length; y++)
            result[x, y] = lines[y][x] == '#';
        return result;
    }
}
