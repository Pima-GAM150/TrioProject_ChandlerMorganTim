﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBlock : MonoBehaviour
{

    public bool pushForce;
    public Rigidbody2D PushableBlock = new Rigidbody2D();

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            print("The player is trying to push a block!");
            pushForce = true;
        }
        else
        {
            pushForce = false;
        }
    }

    // Use this for initialization
    private void Start()
    {
        PushableBlock.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {

        if (pushForce = true && PlayerStats.playerStrength == 2)
        {
            PushableBlock.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            PushableBlock.constraints = RigidbodyConstraints2D.FreezeAll;
        }

    }
}