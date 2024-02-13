using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarDrawerController1 : MonoBehaviour
{
    private Animator doorAnim;

    [SerializeField] private AudioSource doorOpenAudioSource = null;
    [SerializeField] private float openDelay = 0;

    [SerializeField] private AudioSource doorCloseAudioSource = null;
    [SerializeField] private float closeDelay = 0.8f;

    private bool doorOpen = false;

    private void Awake()
    {
        doorAnim =  gameObject.GetComponent<Animator>();
    }
    public void PlayAnimation()
    {
        if(!doorOpen)
        {
            doorAnim.Play("OpenDrawer1", 0, 0.0f);
            doorOpen = true;
            doorOpenAudioSource.PlayDelayed(openDelay);
        }
        else
        {
            doorAnim.Play("CloseDrawer1", 0, 0.0f);
            doorOpen = false;
            doorCloseAudioSource.PlayDelayed(closeDelay);
        }
    }
}