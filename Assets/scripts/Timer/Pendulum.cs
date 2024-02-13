using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1.5f;
    public float angle = 30f;
    public float offset = 0f;
  
    

    void Start()
    {
        
    StartCoroutine(PendulumMotion());
    }

   IEnumerator PendulumMotion()
    {
        while (true)
        {
            transform.rotation = Quaternion.Euler(0, 0, offset + angle * Mathf.Sin(Time.time * speed));
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
