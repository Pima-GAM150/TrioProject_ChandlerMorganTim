using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FallingThing : MonoBehaviour
{
   public Rigidbody2D fallingThing;
    void OnTriggerEnter2D(Collider2D player)
    {
        
        if (player.gameObject.tag == "Player")
        {
            //Debug.Log("ding");
            fallingThing.gravityScale = .1f;


        }
    }
}