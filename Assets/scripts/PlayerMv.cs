using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Vitesse de déplacement du joueur

    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Récupérer les entrées de mouvement horizontal et vertical
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculer le vecteur de mouvement
        Vector3 movement = transform.right * moveHorizontal + transform.forward * moveVertical;
        movement.Normalize(); // Normaliser pour éviter le mouvement plus rapide en diagonale

        // Appliquer le mouvement au CharacterController
        controller.Move(movement * speed * Time.deltaTime);
    }
}
