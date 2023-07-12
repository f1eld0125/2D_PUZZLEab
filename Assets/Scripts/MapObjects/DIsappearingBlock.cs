using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIsappearingBlock : MonoBehaviour
{
    
    private SpriteRenderer sr;
    private Collider2D collider;
    private void OnCollisionEnter2D(Collision2D other) 
    {   
        if(other.gameObject.CompareTag("Player") && other.contacts[0].normal.y< 0f)
        {
            StartCoroutine(DisappearingDelay());
        }
    }

    void Start() {
        {
            sr = GetComponentInChildren<SpriteRenderer>();
            collider = GetComponentInChildren<Collider2D>();
        }
    }

    IEnumerator DisappearingDelay()
    {
       
        yield return new WaitForSeconds(0.5f);   
        StartCoroutine(AppearingDelay());
    }
    IEnumerator AppearingDelay()
    {
        collider.enabled = false;
        sr.enabled = false;
        yield return new WaitForSeconds(3f);   
        collider.enabled = true;
        sr.enabled = true;
    }

}
