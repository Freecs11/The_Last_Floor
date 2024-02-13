using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangerAudio : MonoBehaviour
{
    public AudioClip audioEtage1; // Audio de l'étage 1
    public AudioClip audioEtage2; // Audio de l'étage 2
 //  public AudioSource monstreAudio;
   public AudioSource clockAudio;
   public AudioSource pianoAudio;
    public GameObject porte; // GameObject de la porte
    private AudioSource audioSource;
    private bool porteEtage2Ouverte = false;
    private bool joueurDepassePorte = false;
 public GameObject FadeScreenIn;
    public GameObject TextBox;
  public  bool isPlayingEtage = false;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
      
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Vérifier si le joueur entre dans l'étage 2
            if (porte.activeSelf && !porteEtage2Ouverte)
            {
                // Changer l'audio pour l'étage 2
                audioSource.clip = audioEtage2;
                audioSource.Play();
                porteEtage2Ouverte = true;
                isPlayingEtage = true;
                 StartCoroutine(ScenePlayer());
            //   monstreAudio.enabled = false;
              
                clockAudio.enabled = false;
                pianoAudio.enabled = false;

             
                
            }
        }
    }
    IEnumerator ScenePlayer()
    {    FadeScreenIn.SetActive(true);
                 yield return new WaitForSeconds(3f);
                FadeScreenIn.SetActive(false);
                TextBox.GetComponent<Text>().text = "I need to get out of here!";
                yield return new WaitForSeconds(3f);
                TextBox.GetComponent<Text>().text = "What is this weird voice?, i better be careful.";
                TextBox.GetComponent<Text>().text = "";

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag==("Player"))
        {
            // Vérifier si le joueur a dépassé la porte
            if (!porte.activeSelf && porteEtage2Ouverte)
            {
                // Changer l'audio pour l'étage 1
                audioSource.clip = audioEtage1;
                audioSource.Play();
                joueurDepassePorte = true;
          //     monstreAudio.enabled = false;
                   clockAudio.enabled = true;
                pianoAudio.enabled = true;
                  isPlayingEtage = false;
            }
        }
    }

    private void Update()
    {
        // Réinitialiser l'état de la porte et du joueur lorsqu'une nouvelle interaction peut se produire
        if (porteEtage2Ouverte && joueurDepassePorte)
        {
            porteEtage2Ouverte = false;
            joueurDepassePorte = false;
           
        }
    }
}
