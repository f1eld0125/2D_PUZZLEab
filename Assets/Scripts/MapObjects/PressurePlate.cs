using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
   
    public int signalNumber;

    private void OnCollisionEnter2D(Collision2D other) 
    {   
        if(other.contacts[0].normal.y< 0f)
        {
            GameObject.FindObjectOfType<SignalManager>().SendSignal(signalNumber);
            Destroy(GetComponent<Collider2D>());
            GetComponentInChildren<Animator>().Play("Press");
        }
    }

    

 }
