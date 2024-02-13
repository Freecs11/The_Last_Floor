using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuLightAnimation : MonoBehaviour
{
    // simple rotation of the light , this is attached to the light in the main menu so just launch a coroutine to rotate it
    // use this to also tick few lights off and on , will be passed by editor
    public Light light1;
    public Light light2;
    public Light light3;

    void Start()
    {
        StartCoroutine(rotateLight());
        StartCoroutine(toggleLight1());
        StartCoroutine(toggleLight2());
        StartCoroutine(toggleLight3());

    }

    IEnumerator rotateLight()
    {
        while (true)
        {
            transform.Rotate(0.1f, 0.1f, 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator toggleLight1()
    {
        while (true)
        {
            // make it abit random so it doesnt look like a pattern
            yield return new WaitForSeconds(Random.Range(0.1f, 1.5f));
            light1.enabled = !light1.enabled;
            
        }
    }

    IEnumerator toggleLight2()
    {
        while (true)
        {
            // make it abit random so it doesnt look like a pattern
            yield return new WaitForSeconds(Random.Range(0.1f, 1.5f));
            light2.enabled = !light2.enabled;

        }
    }
    IEnumerator toggleLight3()
    {
        while (true)
        {
            // make it abit random so it doesnt look like a pattern
            yield return new WaitForSeconds(Random.Range(0.1f, 1.5f));
            light3.enabled = !light3.enabled;

        }
    }
}
