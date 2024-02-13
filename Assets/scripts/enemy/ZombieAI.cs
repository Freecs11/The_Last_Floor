using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class ZombieAI : MonoBehaviour
{
    public NavMeshAgent ai;
    public List<Transform> destinations;
    public Animator aiAnim;
    public float walkSpeed, chaseSpeed, minIdleTime, maxIdleTime, idleTime, sightDistance, catchDistance, chaseTime, minChaseTime, maxChaseTime, jumpscareTime, attackDelay;
    public bool walking, chasing;
    public Transform player;
    Transform currentDest;
    Vector3 dest;
    int randNum;
    public int destinationAmount;
    public Vector3 rayCastOffset;
    public string deathScene;
    public GameObject plyer;
    public AudioClip zombieLullaby;
    public AudioClip zombieScream;
    public AudioClip zombieAttack;
    private AudioSource audioSource;
    public float maxDistance = 20.0f;
    public float minDistance = 1.0f ;
    public float maxVolume = 1.0f ;
    public float minVolume = 0.0f;
    private bool hasPlayedScream = false;
    private bool hasPlayedAttack = false;
    
   public ChangerAudio changerAudio;

    void Start()
    {
        walking = true;
        chasing = false;
        currentDest = destinations[Random.Range(0, destinations.Count)];
        audioSource = GetComponent<AudioSource>();
        
        
    }
    void Update()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        RaycastHit hit;
        if(Physics.Raycast(transform.position + rayCastOffset, direction, out hit, sightDistance))
        {
            if(hit.collider.gameObject.tag == "Player")
            {
                walking = false;
                StopCoroutine("stayIdle");
                StopCoroutine("chaseRoutine");
                StartCoroutine("chaseRoutine");
                chasing = true;
            }
        }
        if(chasing == true)
        {
            if(plyer.GetComponent<player>().isHiding )
            {
                audioSource.Stop();
                chasing = false;
                walking = true;
                StopCoroutine("chaseRoutine");
                currentDest = destinations[Random.Range(0, destinations.Count)];
                
            }
             if (!hasPlayedScream && plyer.GetComponent<player>().isHiding == false)
                {
                    audioSource.Stop();
                    audioSource.PlayOneShot(zombieScream);

                    hasPlayedScream = true;
                }
                if (!hasPlayedAttack && plyer.GetComponent<player>().isHiding == false)
                {
                    //stop lullaby
                    
                    audioSource.PlayOneShot(zombieAttack);
                    hasPlayedAttack = true;
                }
            dest = player.position;
            ai.destination = dest;
            ai.speed = chaseSpeed;
            aiAnim.ResetTrigger("walk");
            aiAnim.ResetTrigger("idle");
            aiAnim.ResetTrigger("attack");
            aiAnim.SetTrigger("sprint");
            //attack player here
            if(ai.remainingDistance <= catchDistance)
            {
                StopCoroutine("Attack");
                StartCoroutine("Attack");
                
            }
           
        }
        if(walking == true)
        {
            hasPlayedScream = false;
            hasPlayedAttack = false;
            if (!audioSource.isPlaying && changerAudio.isPlayingEtage )
                audioSource.PlayOneShot(zombieLullaby);
            dest = currentDest.position;
            ai.destination = dest;
            ai.speed = walkSpeed;
            aiAnim.ResetTrigger("sprint");
            aiAnim.ResetTrigger("idle");
            aiAnim.ResetTrigger("attack");
            aiAnim.SetTrigger("walk");
            
            if (ai.remainingDistance <= ai.stoppingDistance)
            {
                aiAnim.ResetTrigger("sprint");
                aiAnim.ResetTrigger("walk");
                aiAnim.ResetTrigger("attack");
                aiAnim.SetTrigger("idle");
                ai.speed = 0;
                Debug.Log("currentDest");
                StopCoroutine("stayIdle");
                StartCoroutine("stayIdle");
                walking = false;
            }
        }
    }
    public void stopChase()
    {
        chasing = false;
        walking = true;
        StopCoroutine("chaseRoutine");
        currentDest = destinations[Random.Range(0, destinations.Count)];
        

    }
   
    IEnumerator stayIdle()
    {
        idleTime = Random.Range(minIdleTime, maxIdleTime);
        yield return new WaitForSeconds(idleTime);
        walking = true;
        Debug.Log("currentDest");
        currentDest = destinations[Random.Range(0, destinations.Count)];
    }
    IEnumerator chaseRoutine()
    {
        chaseTime = Random.Range(minChaseTime, maxChaseTime);
        //play scream sound
        
        yield return new WaitForSeconds(chaseTime);
        stopChase();
        
    }
    IEnumerator Attack()
{
    // Play attack animation
    
    aiAnim.ResetTrigger("walk");
    aiAnim.ResetTrigger("idle");
    aiAnim.ResetTrigger("sprint");
    aiAnim.SetTrigger("attack");
    
   
    // Wait for a certain duration before the next attack
    yield return new WaitForSeconds(attackDelay);
    aiAnim.ResetTrigger("attack");
    
}
   
}
