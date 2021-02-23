using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarDestroyerGenerator : AttackCollisionTrigger
{
    public float objectHealth;
    public float playerDamageVal;
    public bool isDestroyed;
    
    protected override void TriggerEvent()
    {
        Debug.Log("DestroyableObject TriggerEvent called");
        if (playerDamageVal == 0)
        {
            Debug.Log("Need to set PlayerDamageVal!");
        }

        if (!isDestroyed)
        {
            if (objectHealth > 0)
            {
                objectHealth -= playerDamageVal;
                Debug.Log(transform + " Object Health = " + objectHealth);
            }
            else
            {
                Debug.Log("Object Destroyed");
                isDestroyed = true;

                destroyGenerator();
            }
        }
    }

    private void destroyGenerator()
    {
        GameObject explosion = this.transform.Find("Explosion_A").gameObject;
        GameObject fire = this.transform.Find("Fire_B").gameObject;
        GameObject smoke = this.transform.Find("smoke_thick").gameObject;

        explosion.SetActive(true);
        fire.SetActive(true);
        smoke.SetActive(true);
    }
}
