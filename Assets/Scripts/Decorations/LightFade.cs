using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightFade : MonoBehaviour
{
    public float minIntensity;
    public float maxIntensity;
    public float delay;
    public bool startAtMin;

    private Light myLight;

    private float timeElapsed;

    private void Awake()
    {
        myLight = this.GetComponentInChildren<Light>();

        if (myLight != null)
        {
            myLight.intensity = startAtMin ? minIntensity : maxIntensity;
            myLight.color = UnityEngine.Color.red;
        }
    }

    private void Update()
    {
        if (myLight != null)
        {
            timeElapsed += Time.deltaTime;

            if (timeElapsed >= delay)
            {
                timeElapsed = 0;
                ToggleLight();
            }
        }
    }

    private void ToggleLight()
    {
        if (myLight != null)
        {
            if (myLight.intensity == minIntensity)
            {
                myLight.intensity = maxIntensity;
            }

            else if (myLight.intensity == maxIntensity)
            {
                myLight.intensity = minIntensity;
            }
        }
    }
}
