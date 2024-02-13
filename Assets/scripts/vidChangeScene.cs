using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class vidChangeScene : MonoBehaviour

{
    public string gameSceneName; // Nom de la scène de jeu
    public float Duration;

    private void Start()
    {
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        // Attendre la durée de la cinématique ou tout autre événement nécessaire avant de passer à la scène de jeu
        yield return new WaitForSeconds(Duration);
        if (gameSceneName == "menu")
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Debug.LogError("Veuillez entrer le nom de la scène de jeu dans l'inspecteur");
            yield break;
        }
        // Charger la scène de jeu
        SceneManager.LoadScene(gameSceneName);
    }
}
