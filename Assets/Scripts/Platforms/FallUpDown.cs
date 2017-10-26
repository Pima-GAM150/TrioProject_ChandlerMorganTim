using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallUpDown : UpDownPlatform
{
    public float timeToDestroy = 2.0f;

    private void Oncollisionfall2D(Collision2D collision)
    {

        
        
        if (collision.gameObject.tag == "platform")
        {
            Debug.Log("touching");
            Destroy(collision.gameObject, timeToDestroy);

        }
    }
}
