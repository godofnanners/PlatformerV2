using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour {
    public float health = 15;
	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
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
