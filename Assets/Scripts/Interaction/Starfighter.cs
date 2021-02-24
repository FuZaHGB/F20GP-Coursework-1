using Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class Starfighter : CollisionTrigger
{

    protected override void TriggerEvent()
    {
        Debug.Log("XXXXEvent Triggerred!XXXXXXXXX");
        GameObject cam = GameObject.Find("Main Camera");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject starfighter = GameObject.FindGameObjectWithTag("Starfighter");

        /// If player is pressing F inside the trigger volume, it means they want control of Starfighter.
        /// MouseLook + Playermovement scripts are disabled, and starfighter control scripts are enabled instead.
        if (Input.GetKey(KeyCode.F))
        {
            cam.GetComponent<MouseLook>().enabled = false;
            cam.GetComponent<CameraFlightFollow>().enabled = true;
            cam.GetComponent<CustomPointer>().enabled = true;

            starfighter.GetComponent<PlayerFlightControl>().enabled = true;
            starfighter.GetComponent<Rigidbody>().useGravity = false;

            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<Animator>().enabled = false;
            Renderer[] renders = player.GetComponentsInChildren<Renderer>();
            foreach (Renderer render in renders)
            {
                render.enabled = false;
            }
        }
    }
}
