using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : CollisionTrigger
{
    public GameObject leftDoor;
    public GameObject rightDoor;
    public bool DoorOpened;
    public bool isInteriorDoor;

    private float maximumOpening = 3.0f;
    private float doorMovementSpeed = 1.0f;

    protected override void TriggerEvent()
    {
        
        //Debug.Log("XXXXEvent Triggerred!XXXXXXXXX");
        if (Input.GetKey(KeyCode.F))
        {
            
            if (!DoorOpened)
            {
                Debug.Log("OpenDoor Called");
                OpenDoor();
                DoorOpened = true;
            }
        }
    }

    private void OpenDoor()
    {
        if (!isInteriorDoor)
        {
            if (leftDoor.transform.localPosition.z == 0)
            {
                Debug.Log("Both doors are at 0");
                while (leftDoor.transform.localPosition.z < maximumOpening && rightDoor.transform.localPosition.z > -maximumOpening)
                {
                    leftDoor.transform.Translate(0f, 0f, doorMovementSpeed * Time.deltaTime);
                    rightDoor.transform.Translate(0f, 0f, -doorMovementSpeed * Time.deltaTime);
                }
                GameObject fireEffect = this.transform.Find("Fire_A").gameObject;
                fireEffect.SetActive(true);
            }
        }
        else
        {
            Animator m_Animator = this.GetComponentInParent<Animator>();
            m_Animator.SetTrigger("character_nearby");
            Debug.Log("Attempted to open door");
        }
    }
}
