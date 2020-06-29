/*
* Jake Buri
* Respawn.cs
* Assignment 3
* Respawns the player when they fall and is a concrete observer for the amount of lives left
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour, IObserver
{
    //Variables
    int lives = 5;
    bool inBounds = true;
    GameObject player;

    void Start()
    {
        //Get player
        player = GameObject.FindGameObjectWithTag("Player");
    }

    //Call respawn and update GameManager
    public void UpdateSubject(ISubject subject)
    {
        //Update lives locally and in the GameManager
        lives--;
        (subject as GameManager).SetLives(lives);

        //Respawn player
        RespawnPlayer(subject as GameManager);

        Debug.Log("Should've Respawn");

        //Reset player inBounds
        inBounds = true;
    }

    //Get remaining lives
    public int GetLives()
    {
        return lives;
    }

    //Get inBounds state
    public bool GetInBounds()
    {
        return inBounds;
    }

    //Respawn player
    public void RespawnPlayer(GameManager gm)
    {
        Debug.Log("Respawning");

        //Disable Character Controller's control of position
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;

        //Transform player to spawn
        player.transform.position = gm.start.position;
        player.transform.rotation = gm.start.rotation;

        //Enable Character Controller's control of position
        player.GetComponent<CharacterController>().enabled = true;
        player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;

        //Re-enable broken IceBlocks
        foreach (GameObject iceBlock in GameObject.FindGameObjectsWithTag("IceBlock"))
        {
            //Disable breaking
            IceBlock theIceBlock = iceBlock.GetComponent<IceBlock>();
            theIceBlock.notBreaking = true;
            theIceBlock.StopAllCoroutines();

            //Enable Renderer
            iceBlock.GetComponent<Renderer>().enabled = true;

            //Use the action of enabling the collider to restore the remaining platforms counter
            Collider collider = iceBlock.GetComponent<Collider>();
            if (collider.enabled == false)
            {
                gm.Attach(theIceBlock);
                collider.enabled = true;
            }
        }
    }

    //Lets the GameManager notify when the player needs to respawn
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == player)
        {
            Debug.Log("Collision");
            inBounds = false;
        }
    }

    
}
