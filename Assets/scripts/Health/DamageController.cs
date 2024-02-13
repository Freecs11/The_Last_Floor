using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private float damage=10.0f;

    [SerializeField] private GameObject ennemy = null ;

    [SerializeField] private HealthController _healthController = null;
    private AudioSource ennemyAudioSource;
    [SerializeField] private AudioClip hurtAudio;

    [SerializeField] private float pushBackForce = 10.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        ennemyAudioSource = GetComponent<AudioSource>();
    }
    
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Player"))
        {
           
            _healthController.currentPlayerHealth -= damage;
            _healthController.TakeDamage();
           
            PushBack(ennemy.transform);
            PushBack(other.gameObject.transform);
            
        }
    }
    
     private void PushBack(Transform pushedObject)
    {
        Vector3 pushDirection = new Vector3((pushedObject.position.x - transform.position.x), 0, (pushedObject.position.z - transform.position.z)).normalized;
        pushDirection *= pushBackForce*2f;
        Rigidbody pushedRB = pushedObject.GetComponent<Rigidbody>();
        pushedRB.velocity = Vector3.zero;
        pushedRB.AddForce(pushDirection, ForceMode.Impulse);        
    }

}
