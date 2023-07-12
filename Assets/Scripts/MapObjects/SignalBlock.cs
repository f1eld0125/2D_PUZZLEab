using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalBlock : Signal
{
public int signalNumber;
   

    public override void ReceieveSignal()
    {
        gameObject.SetActive(true);
    }

    void Start() 
    {
        GameObject.FindObjectOfType<SignalManager>().RegisterSignal(signalNumber, this);
        gameObject.SetActive(false);    
    }
}
