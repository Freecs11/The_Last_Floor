using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class HealthController : MonoBehaviour
{
    //declare health variables
    [Header("Player Health ")]
    public float currentPlayerHealth=100.0f;
    private float maxPlayerHealth=100.0f;
    [Header("Splatter Image ")]
    [SerializeField] private Image redSplatterImage=null;
    [Header("Hurt Image ")]
    [SerializeField] private Image hurtImage=null;
    [SerializeField] private float hurtTimer=1.1f;
    [Header("Audio Name ")]
    [SerializeField] private AudioClip hurtAudio=null;
    private AudioSource healthAudioSource;

     [Header("Health Regeneration")]
    [SerializeField] private float regenerationDelay = 1.0f;
    [SerializeField] private float regenerationAmount = 5.0f;
    private Coroutine regenerationCoroutine;
    private GameObject player;

    private void Awake() {
        player = GameObject.Find("player");
    }

    // Start is called before the first frame update
    void Start()
    {
        healthAudioSource = GetComponent<AudioSource>();
        hurtImage.enabled=false;
        UpdateHealth();
        StartHealthRegeneration();
    }

    void UpdateHealth(){
        Color splatterAlpha=redSplatterImage.color;
        splatterAlpha.a=1-(currentPlayerHealth/maxPlayerHealth);
        redSplatterImage.color=splatterAlpha;
    }

    private IEnumerator HealthRegenerationCoroutine()
    {
        yield return new WaitForSeconds(regenerationDelay);
        while (currentPlayerHealth < maxPlayerHealth)
        {
            currentPlayerHealth += regenerationAmount;
            UpdateHealth();
            yield return new WaitForSeconds(regenerationDelay);
        }
    }

    public IEnumerator HurtFlash(){
    hurtImage.enabled = true;

    // shake player camera on hurt
    player.GetComponent<player>().shakeCamera();
    
    
    yield return new WaitForSeconds(hurtTimer);
    hurtImage.enabled=false;
    }

    private void StartHealthRegeneration()
    {
        StopHealthRegeneration(); // Stop previous regeneration coroutine if running
        regenerationCoroutine = StartCoroutine(HealthRegenerationCoroutine());
    }
    private void StopHealthRegeneration()
    {
        if (regenerationCoroutine != null)
        {
            StopCoroutine(regenerationCoroutine);
        }
    }
    public void TakeDamage(){
    if(currentPlayerHealth >=0){
        //can regenerate
        //hurt effect
        StartCoroutine(HurtFlash());
        
        UpdateHealth();
        //cooldowns
        StartHealthRegeneration();}
    }
    // Update is called once per frame
    void Update()
    {


        if(currentPlayerHealth<=0){
            //player is dead
            //game over
            SceneManager.LoadScene("GameOver");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            //restart game  or load menu scene 
        }
    }
}
