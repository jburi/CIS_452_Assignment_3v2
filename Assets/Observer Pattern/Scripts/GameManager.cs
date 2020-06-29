/*
* Jake Buri
* GameManager.cs
* Assignment 3
* Handles the main game functions and is the subject to both observers
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, ISubject
{
    //Observer Variables
    List<IceBlock> iceBlocks;
    Respawn respawn;
    int livesLeft;
    int remainingPlatforms;
    
    //Variables
    public Transform start;
    public Finish finish;
    
    //UI Subject display
    public Text livesText;
    public Text remainingPlatformsText;


    // Start is called before the first frame update
    void Start()
    {
        //Initialize List
        iceBlocks = new List<IceBlock>();

        //Get respawn and lives
        respawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Respawn>();
        livesLeft = respawn.GetLives();

        //Add ice blocks to the list of observers
        foreach (GameObject iceBlock in GameObject.FindGameObjectsWithTag("IceBlock"))
        {
            remainingPlatforms++;
            IceBlock thisObserver = iceBlock.GetComponent<IceBlock>();
            Attach(thisObserver);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Display UI
        livesText.text = livesLeft.ToString();
        remainingPlatformsText.text = iceBlocks.Count.ToString();

        //Break blocks if player is detected
        Notify();

        //Check if the player fell
        if (respawn.GetInBounds() == false)
        {
            Debug.Log("GM Respawn");
            //Call respawn
            respawn.UpdateSubject(this);
        }

        //Check if the player wins
        if (iceBlocks.Count == 0 && finish.hasPlayer == true)
        {
            SceneManager.LoadScene("Win");
        }

        if (livesLeft == 0)
        {
            SceneManager.LoadScene("Lose");
        }
    }

    //Set lives in Respawn.cs
    public void SetLives(int lives)
    {
        livesLeft = lives;
    }

    //Add observer
    public void Attach(IObserver observer)
    {
        this.iceBlocks.Add(observer as IceBlock);
    }

    //Remove observer
    public void Detach(IObserver observer)
    {
        this.iceBlocks.Remove(observer as IceBlock);
    }

    //Detect if an IceBlock is breaking and starts to remove it
    public void Notify()
    {
        foreach (IObserver observer in iceBlocks)
        {
            if ((observer as IceBlock).notBreaking == false) 
            {
                //Remove renderer and mesh
                observer.UpdateSubject(this);

                //Remove IceBlock to update remaining
                Detach(observer);
            }
        }
    }
}
