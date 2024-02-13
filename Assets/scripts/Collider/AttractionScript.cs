using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractionScript : MonoBehaviour
{
    public GameObject armoire;
    public float attractionForce = 10f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 direction = (armoire.transform.position - transform.position).normalized;
        rb.AddForce(direction * attractionForce);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == armoire)
        {
            // L'objet a atteint l'armoire, vous pouvez ajouter un code supplémentaire ici
            Debug.Log("L'objet est arrivé à l'intérieur de l'armoire !");
            // Par exemple, vous pouvez désactiver le script pour arrêter l'attraction
            enabled = false;
        }
    }
}
