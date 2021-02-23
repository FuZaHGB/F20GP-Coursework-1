using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarDestroyerParent : MonoBehaviour
{
    public GameObject generator1;
    public GameObject generator2;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (generator1.GetComponent<StarDestroyerGenerator>().isDestroyed && generator2.GetComponent<StarDestroyerGenerator>().isDestroyed)
        {
            anim.SetBool("isDestroyed", true);
        }
    }
}
