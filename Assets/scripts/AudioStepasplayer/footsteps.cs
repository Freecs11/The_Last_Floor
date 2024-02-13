using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour
{
    public AudioSource footstepAudioSource; // Composant AudioSource pour les sons de pas
    public AudioSource runningAudioSource; // Composant AudioSource pour le son de course
    public AudioSource jumpAudioSource; // Composant AudioSource pour le son de saut

    private bool isButtonPressed = false; // Variable pour vérifier si le bouton de déplacement est enfoncé
    private bool isRunning = false; // Variable pour vérifier si le personnage court

    void Update()
    {
        // Vérifier si le bouton de déplacement est enfoncé
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) ||
            Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            isButtonPressed = true;
        }

        // Vérifier si le bouton de déplacement est relâché
        if (Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D) ||
            Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            isButtonPressed = false;
        }

        // Vérifier si les touches Shift et UpArrow sont enfoncées pour activer le mode de course
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.UpArrow))
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        // Activer ou désactiver l'audio source en fonction de l'état du bouton
        footstepAudioSource.enabled = isButtonPressed && !isRunning;
        runningAudioSource.enabled = isButtonPressed && isRunning;

        // Vérifier si la touche Espace (Space) est enfoncée pour activer le son de saut
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpAudioSource.enabled = true;
        }else
        {
            jumpAudioSource.enabled = false;
        }
    }
}
