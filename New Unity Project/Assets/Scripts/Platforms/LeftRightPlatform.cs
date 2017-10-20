using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightPlatform : MonoBehaviour
{

    private Vector2 startPosition;
    private int speed;

    void Start()
    {
        startPosition = transform.position;
        speed = 3;
    }

    void Update()
    {
        transform.position =
            new Vector2(startPosition.x + Mathf.Sin(Time.time * speed), transform.position.y);
    }
}
    