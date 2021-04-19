using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    public bool[,] map = {{true, true}, {true, true}};

    public bool Check(Vector3 vector)
    {
        return vector.x >= 0 && vector.x < map.GetLength(0) &&
               vector.z >= 0 && vector.z < map.GetLength(1) &&
               map[(int) vector.x, (int) vector.z];
    }
}
