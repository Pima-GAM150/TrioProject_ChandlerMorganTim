using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallUpDown : UpDownPlatform
{
    public float timeToDestroy = 2.0f;
    public GameObject platform;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("touching");
            StartCoroutine(WaitAndDestroy(collision.gameObject, timeToDestroy));
           
        }
    }

    IEnumerator WaitAndDestroy( GameObject playerObj, float time )
    {
        yield return new WaitForSeconds(time);
        playerObj.transform.parent = null;
        Destroy(platform);
    }
}
