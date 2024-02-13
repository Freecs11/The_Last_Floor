using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public float timeValue = 90;
    public Text timeText;
      
    
    private void Update() {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue =0;
        }
        

        DisplayTime(timeValue);
    }
    void DisplayTime(float timeToDisplay){
        if (timeToDisplay <0)
        {
            timeToDisplay = 0;
        }
        float minutes = Mathf.FloorToInt(timeToDisplay/60);
        float seconds = Mathf.FloorToInt(timeToDisplay%60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes , seconds);
        if (minutes == 0)
        {
            timeText.color=Color.red;
        }
    }

    // if time runs out then the player will be sent to the game over screen
    private void OnGUI() {
        if (timeValue == 0)
        {
            Application.LoadLevel("GameOver");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
     



}
