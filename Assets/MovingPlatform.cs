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


    //void ConnectToPlayer(Rigidbody2D player)
    //{
    //    SliderJoint2D joint = GetComponent<SliderJoint2D>();
    //    joint.connectedBody = player;

    //}

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.gameObject.tag == ("Player"))
    //    {
    //        Debug.Log("hbuoawd");

           
    //        ConnectToPlayer(collision.collider.GetComponent<Rigidbody2D>());
    //    }


    //    }

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
