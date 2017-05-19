using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSpells : Magic
{
    public GameObject projectile;
    public float ManaCost, Cooldown, ProjectileLife;

	void Update ()
    {
        //Lägga all gameplay skit för combat
        if (Input.GetKey(KeyCode.F))
        {
            Cast(projectile, ManaCost, Cooldown, ProjectileLife);
        }
    }
}
