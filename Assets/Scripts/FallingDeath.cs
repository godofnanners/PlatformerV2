using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingDeath : MonoBehaviour
{
    public Transform gameObjectpos;
    public bool Player;

    void Start()
    {
    }

    void Update()
    {
        if (gameObjectpos.position.y < -50)
        {
            if (Player)
            {
                SceneManager.LoadScene("Level 1");
            }

            Destroy(gameObject);
        }
    }
}
