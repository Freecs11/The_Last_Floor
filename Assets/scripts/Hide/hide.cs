using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class hide : MonoBehaviour
{
    // this script will be used to hide the player when they are in the locker , place the player in the locker ( player has to press E to enter the locker) and then the player will be hidden from the monster
    private GameObject player;
    private bool isHiding = false;
    public GameObject lockerInsidePosition;
    public TextMeshPro hideText;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        // hide the text
        hideText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
       // if player is looking at the locker , then show the text to press E to hide
         if(isHiding == false){
              if(Vector3.Distance(player.transform.position,transform.position) < 2f){
                // show the text
                hideText.enabled = true;
                // if the player presses E then hide the player
                if(Input.GetKeyDown(KeyCode.E)){
                    // move the player to the locker
                    player.transform.position = lockerInsidePosition.transform.position ;
                    // player is facing the locker so rotate the player
                    player.transform.rotation = lockerInsidePosition.transform.rotation;
                    player.GetComponent<player>().isHiding = true;
                    // disable the text
                    hideText.enabled = false;
                    // set isHiding to true
                    isHiding = true;
                }
              }else{
                // hide the text
                hideText.enabled = false;
              }
        }
        // if the player is hiding then show the text to press E to exit
        else {
            // show the text
            hideText.enabled = true;
            // if the player presses E then exit the locker
            if(Input.GetKeyDown(KeyCode.E)){
                // move the player out of the locker
                player.transform.position = transform.position + transform.forward * 2;
                player.GetComponent<player>().isHiding = false;
                // disable the text
                hideText.enabled = false;
                // set isHiding to true
                isHiding = false;
            }
        }
       
    }
}
