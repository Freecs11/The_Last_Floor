using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseSystem : MonoBehaviour
{
    private GameObject player;
    public GameObject pauseCanvas;
    private void Start() {
        player = GameObject.Find("player");
    }
    public void onCalledResume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        pauseCanvas.SetActive(false);
    }

    public void onCalledQuit()
    {
        Time.timeScale = 1;
        player.GetComponent<player>().inventory.Container.Clear();
        player.GetComponent<player>().inventory.Save();
        SceneManager.LoadScene("menu");
    }
}
