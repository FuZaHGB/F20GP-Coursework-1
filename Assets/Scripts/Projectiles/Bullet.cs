using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float projectileSpeed = 12f;
    public float projectileLifespan = 2f;

    private float projectileLifeTimer;

    void Start ()
    {
        projectileLifeTimer = projectileLifespan;
    }
    // Update is called once per frame
    void Update()
    {
        // Update Bullet Position
        transform.position += transform.forward * projectileSpeed * Time.deltaTime;

        // Check if bullet has outlasted its lifespan
        projectileLifeTimer -= Time.deltaTime;
        if (projectileLifeTimer <= 0f)
        {
            Destroy(transform.gameObject);
        }
    }
}
