using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalDoor : Signal
{
public int signalNumber;
   

    public override void ReceieveSignal()
    {
        gameObject.SetActive(false);
    }

    void Start() 
    {
        GameObject.FindObjectOfType<SignalManager>().RegisterSignal(signalNumber, this);
        gameObject.SetActive(true);    
    }
}
