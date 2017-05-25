using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSpells : Magic
{
    public GameObject Fireball;
    public float FireballCost, FireballCooldown;

    public GameObject Lightning;
    public float LightningCost, LightningCooldown;

    void Update ()
    {
       
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Cast(Fireball, FireballCost, FireballCooldown);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            Cast(Lightning, LightningCost, LightningCooldown);
        }
    }
}
