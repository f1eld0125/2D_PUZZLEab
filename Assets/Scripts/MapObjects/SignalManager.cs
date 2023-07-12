using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalManager : MonoBehaviour
{
    public List<List<Signal>> signals;

    public void SendSignal(int signalNumber)
    {
        foreach (Signal signal in signals[signalNumber])
        {
            signal.ReceieveSignal();
        }
    }

    public void RegisterSignal(int signalNumber, Signal signal)
    {
        while (signals.Count <= signalNumber)
        {
            signals.Add(new List<Signal>());
        }
        signals[signalNumber].Add(signal);
        Debug.Log("signals.Count="+signals.Count);
        Debug.Log("signals[signalNumber].Count="+signals[signalNumber].Count);
        
    }
    
    void Awake() 
    {
        signals = new List<List<Signal>>();    
    }
}
