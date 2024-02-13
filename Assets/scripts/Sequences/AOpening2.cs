using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AOpening2 : MonoBehaviour
{
    private GameObject ThePlayer;
    public GameObject FadeScreenIn;
    public GameObject TextBox;
    private CharacterController characterController;
    private bool canMove = false;

    // Start is called before the first frame update
    void Start()
    {
        ThePlayer = GameObject.FindGameObjectWithTag("Player");
        characterController = ThePlayer.GetComponent<CharacterController>();
        StartCoroutine(ScenePlayer());
    }

    IEnumerator ScenePlayer()
    {
        yield return new WaitForSeconds(1.5f);
        FadeScreenIn.SetActive(false);
        TextBox.GetComponent<Text>().text = "I need to get out of here!";
        yield return new WaitForSeconds(3f);
        TextBox.GetComponent<Text>().text = "You can take out the flashlight by pressing G and turn it on by pressing F.";
        yield return new WaitForSeconds(3f);
        TextBox.GetComponent<Text>().text = "Be careful, the batteries are limited. recharge them by pressing R.";
        yield return new WaitForSeconds(3f);
        TextBox.GetComponent<Text>().text = "";
        canMove = true;
    }
}
