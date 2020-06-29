/*
* Jake Buri
* Finish.cs
* Assignment 3
* Checks if the player is on the finish platform
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public bool hasPlayer;

    private void Start()
    {
        hasPlayer = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        //Detect Player
        if (collision.gameObject.tag == "Player")
        {
            hasPlayer = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        //Detect Player
        if (collision.gameObject.tag == "Player")
        {
            hasPlayer = false;
        }
    }
}
