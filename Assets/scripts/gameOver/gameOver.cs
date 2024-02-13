using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameOver : MonoBehaviour
{
    // this is attached to a TextMeshPro object that has the text YOU LOST on it
    // i want this to be animated so that it starts small and grows to a certain size then fades out 
    // and then load the menu scene
    
    public TextMeshProUGUI youLost;
    private void Start() {
        StartCoroutine(animateText());
    }

    private IEnumerator animateText(){
        youLost.transform.localScale = new Vector3(0.2f,0.2f,0.2f);
        // red color
        youLost.color =  new Color(1,0,0,0);
        float time = 0;
        while(time < 1){
            youLost.transform.localScale = new Vector3(0.1f + time,0.1f + time,0.1f + time);
            youLost.color = new Color(1,0,0,time);
            time += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("menu");
    }

    /*
    // disable the player movement
            player.GetComponent<player>().enabled = false;
            player.GetComponent<FirstPersonController>().playerCanMove = false;
            player.GetComponent<FirstPersonController>().enableJump = false;
            player.GetComponent<FirstPersonController>().enableCrouch = false;
    */
}
