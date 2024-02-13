using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomClipboardPosition : MonoBehaviour
{
    public GameObject[] locations;
    public GameObject hint;

    private void Awake() {
        int random = Random.Range(0, locations.Length);
        hint.transform.parent = locations[random].transform;
        hint.transform.position = locations[random].transform.position;
    }
}

