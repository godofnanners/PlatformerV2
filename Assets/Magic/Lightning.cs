﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : Spell
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.SendMessageUpwards("Damage", damage);
            Destroy(gameObject);
        }
        else if (other.tag == "Platform")
        {
            Destroy(gameObject);
        }
        else if (other.tag == "Player")
        {
            Cast();
        }
    }
}
