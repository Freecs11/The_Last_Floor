using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DistanceBasedSound : MonoBehaviour
{

    private AudioSource audioSource;
    private Transform player;
    private float maxDistance = 20.0f;
    private float minDistance = 1.0f ;
    private float maxVolume = 1.0f ;
    private float minVolume = 0.0f;

private void Awake() {
    audioSource = GetComponent<AudioSource>();
    player = GameObject.FindWithTag("Player").transform;
    audioSource.minDistance = minDistance;
    audioSource.maxDistance = maxDistance;
}
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindWithTag("Player").transform;
        
        audioSource.minDistance = minDistance;
        audioSource.maxDistance = maxDistance;

    }
    
    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        float volume = Mathf.Lerp(maxVolume, minVolume, distance / maxDistance);
        audioSource.volume = volume;
    }

}


