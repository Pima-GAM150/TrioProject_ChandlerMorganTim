using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBlock : MonoBehaviour
{

    public bool pushForce;
    public Rigidbody2D PushableBlock = new Rigidbody2D();
    float verticalVelocity;

    public bool pushable;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pushForce = true;
        }
        else
        {
            pushForce = false;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
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

        verticalVelocity = PushableBlock.velocity.y;

        if (pushForce == true && PlayerStats.playerStrength == 2)
        {
            pushable = true;
            PushableBlock.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else if(verticalVelocity < 1 && verticalVelocity > -1)
        {
            pushable = false;
            PushableBlock.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else
        {
            pushable = false;
            PushableBlock.constraints = RigidbodyConstraints2D.FreezePositionX;
            PushableBlock.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

    }
}