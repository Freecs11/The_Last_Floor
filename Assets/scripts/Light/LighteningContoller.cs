using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighteningContoller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject lightening;
    //clignotement de la lumiere
        

    void Start()
    {
       StartCoroutine("Lightening");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         
    }

    IEnumerator Lightening()
    {
        while (true)
        {
            
        
        // use time deltatime to make the lightening more realistic
        // also use random range to make the lightening more realistic
        yield return new WaitForSeconds(Random.Range(0.3f, 1f));
        lightening.SetActive(true);
        yield return new WaitForSeconds(Random.Range(0.3f, 1f));
        lightening.SetActive(false);
}

        
    }


}
