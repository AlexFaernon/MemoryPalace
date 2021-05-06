using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Renderer>().enabled = true;
    }

    private void OnTriggerExit(Collider other1)
    {
        GetComponent<Renderer>().enabled = false;
    }
}
