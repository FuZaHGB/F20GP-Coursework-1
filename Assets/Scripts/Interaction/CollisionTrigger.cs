using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Need a sphereCollider to detect a collision.
[RequireComponent(typeof(SphereCollider))]
public abstract class CollisionTrigger : MonoBehaviour
{
    private bool _playerInsideTrigger = false;
    
    private void Awake()
    {
        if (!GetComponent<SphereCollider>().isTrigger)
        {
            Debug.LogError("Ensure that vehicle's Sphere Collider is set to Trigger");
            enabled = false;
            return;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        //Debug.Log("Update called!");
        if (_playerInsideTrigger)
        {
            TriggerEvent();
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("OnTriggerEnter triggered");
        if (!collider.CompareTag("Player")) return;
        _playerInsideTrigger = true;
        Debug.Log(_playerInsideTrigger);
    }

    //public virtual void TriggerEvent()
    //{
    //    Debug.Log("TriggerEvent occurred in Parent Class");
    // }
    protected abstract void TriggerEvent();

    private void OnTriggerExit(Collider collider)
    {
        if (!collider.CompareTag("Player")) return;
        _playerInsideTrigger = false;
    }
}
