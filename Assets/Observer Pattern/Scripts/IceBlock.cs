/*
* Jake Buri
* IceBlock.cs
* Assignment 3
* Removes the ice platforms and is an concrete observer for the number of remaining platforms
*/
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IceBlock : MonoBehaviour, IObserver
{
    public bool notBreaking;
    public float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        notBreaking = true;
    }

    //After the countdown ends, stop it and disable the block
    public void UpdateSubject(ISubject subject)
    {
        StopCoroutine("Countdown");
        this.gameObject.GetComponent<Collider>().enabled = false;
        this.gameObject.GetComponent<Renderer>().enabled = false;
    }

    //Destroy ice block after 2 seconds
    private void OnTriggerEnter(Collider collision)
    {
        //Detect Player
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine("Countdown");
        }
    }

    //Countdown Coroutine
    private IEnumerator Countdown()
    {
        //Test if countdown started
        Debug.Log("Start Countdown");

        //Reset time
        //timeLeft = 2f;
        //float duration = timeLeft;
        
        //Timer
        float totalTime = 0;
        while (totalTime <= 2)
        {
            totalTime += Time.deltaTime;
            timeLeft -= Time.deltaTime;
            yield return null;
        }
        
        //Set timeLeft to zero
        //timeLeft = 0.0f;
        notBreaking = false;
    }
}
