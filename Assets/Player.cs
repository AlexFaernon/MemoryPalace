using System;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private KeyCode keyForward = KeyCode.W;
    [SerializeField] private KeyCode keyBackward = KeyCode.S;
    [SerializeField] private KeyCode keyLeft = KeyCode.A;
    [SerializeField] private KeyCode keyRight = KeyCode.D;
    [SerializeField] private Vector3 moveDirection = Vector3.forward;
    [SerializeField] private Vector3 moveSide = Vector3.right;
    public GameObject Platform;
    public GameObject ExitPlatform;
    private const float playerHeight = 0.65f;

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
********************", new Point(2,2), new Point(19,9));

    private void Start()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("maze"));
        Cursor.lockState = CursorLockMode.Locked;
        GetComponent<Transform>().position = new Vector3(Map.start.X, playerHeight, Map.start.Y);
        for (var x = 0; x < Map.map.GetLength(0); x++)
        {
            for (var z = 0; z < Map.map.GetLength(0); z++)
            {
                if (Map.map[x,z])
                {
                    if (Map.exit.X == x && Map.exit.Y == z)
                    {
                        Instantiate(ExitPlatform, new Vector3(x, 0, z), new Quaternion());
                        continue;
                    }
                    var instantiate = Instantiate(Platform, new Vector3(x, 0, z), new Quaternion());
                    var plat = instantiate.transform.Find("Platform").gameObject;
                    var playerCoord = GetComponent<Transform>().position;
                    var platformCoord = instantiate.GetComponent<Transform>().position;
                    if (!((platformCoord - playerCoord).magnitude > 3)) continue;
                    plat.GetComponent<Renderer>().enabled = false;
                }
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(keyForward))
        {
            if (Map.Check(GetComponent<Transform>().position + moveDirection))
            {
                GetComponent<Transform>().position += moveDirection;
                Map.IfExitLeaveScene(GetComponent<Transform>().position);
            }
        }
        if (Input.GetKeyDown(keyBackward))
        {
            if (Map.Check(GetComponent<Transform>().position - moveDirection))
            {
                GetComponent<Transform>().position -= moveDirection;
                Map.IfExitLeaveScene(GetComponent<Transform>().position);
            }
        }
        if (Input.GetKeyDown(keyRight))
        {
            if (Map.Check(GetComponent<Transform>().position + moveSide))
            {
                GetComponent<Transform>().position += moveSide;
                Map.IfExitLeaveScene(GetComponent<Transform>().position);
            }
        }
        if (Input.GetKeyDown(keyLeft))
        {
            if (Map.Check(GetComponent<Transform>().position - moveSide))
            {
                GetComponent<Transform>().position -= moveSide;
                Map.IfExitLeaveScene(GetComponent<Transform>().position);
            }
        }
    }
}

public class Map
{
    public readonly bool[,] map;
    public readonly Point start;
    public readonly Point exit;

    public Map(string map, Point start, Point exit)
    {
        this.map = CreateMap(map);
        this.start = start;
        this.exit = exit;
        
        if (!this.map[exit.X, exit.Y])
            throw new ArgumentException();
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

    public void IfExitLeaveScene(Vector3 position)
    {
        if (new Point((int) position.x, (int) position.z) == exit)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        }
    }
}
