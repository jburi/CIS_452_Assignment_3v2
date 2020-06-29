/*
* Jake Buri
* EnableCursor.cs
* Assignment 3
* Enables the cursor after FPS Controller keeps the cursor hidden through scene changes 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCursor : MonoBehaviour
{
    //Enable Cursor
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
