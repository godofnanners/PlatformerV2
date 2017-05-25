using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{


    private float startPosY;

    public float distance = 4;
    private float activeSpeed;
    public float dirSpeed = 2;

    void Start()
    {

        startPosY = transform.position.y;
        activeSpeed = -dirSpeed;

    }


        void Update()
    {



        if (startPosY - transform.position.y > distance)
        {
            activeSpeed = dirSpeed;
        }
        else if (startPosY - transform.position.y < -distance)
        {
            activeSpeed = -dirSpeed;
        }
        transform.Translate(0, activeSpeed * Time.deltaTime, 0);


    }
}
