using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public float health = 15;

	void Start ()
    {
		
	}
	
	void Update () 
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
	}
    public void Damage(float damage)
    {
        health -= damage;
    }
}
