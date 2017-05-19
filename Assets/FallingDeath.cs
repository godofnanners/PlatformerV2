using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDeath : MonoBehaviour
{
    public Transform gameObjectpos;

    void Start()
    {
    }

    void Update()
    {
        if (gameObjectpos.position.y < -50)
        {
            Destroy(gameObject);
        }
    }
}
