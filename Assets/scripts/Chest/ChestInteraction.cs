using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestInteraction : MonoBehaviour
{
    private GameObject Player;
    public Animation chestAnimation;
    public AudioSource chestAudioSource; // Audio source component for the chest sound
    public AudioClip openSound; // Sound clip for opening the chest
    public AudioClip closeSound; // Sound clip for closing the chest
    public float interactionDistance = 2f; // Distance maximale pour interagir avec le coffre

    public GameObject actionText; // GameObject containing the Text component for displaying interaction prompts

    private void Start()
    {
        // Assurez-vous d'avoir référencé l'animation du coffre dans l'inspecteur Unity
        chestAnimation = GetComponent<Animation>();
        chestAudioSource = GetComponent<AudioSource>();
        Player = GameObject.FindGameObjectWithTag("Player");

        actionText.SetActive(false); // Disable the action text initially
    }

    private void Update()
    {
        
            // Vérifier si le joueur est à proximité du coffre
            if (IsPlayerNearby())
            {
                if (Input.GetKeyDown(KeyCode.E))
                     {
                        // Si la touche E est enfoncée et que le joueur est à proximité, jouer l'animation du coffre et le son
                chestAnimation.Play("ChestAnim");
                chestAudioSource.PlayOneShot(openSound);
                actionText.SetActive(false); // Disable the action text after interaction
            }
            if (Input.GetKeyUp(KeyCode.E))
        {
            // Arrêter l'animation du coffre lorsque la touche E est relâchée et jouer le son
            chestAnimation.Stop("ChestAnim");
            chestAudioSource.PlayOneShot(closeSound);
        }
        }

        
    }

    private bool IsPlayerNearby()
    {
        // Lancer un raycast depuis le joueur
        RaycastHit hit;
        if (Physics.Raycast(Player.transform.position, transform.position, out hit, interactionDistance))
        {
            // Vérifier si le raycast a touché le coffre
            if (hit.collider.CompareTag("Player"))
            {
             
                actionText.SetActive(true); // Enable the action text
                return true; // Le joueur est à proximité du coffre
            }
            
        }
           

        actionText.SetActive(false); // Disable the action text if the player is not nearby
        return false; // Le joueur n'est pas à proximité du coffre
    }
}
