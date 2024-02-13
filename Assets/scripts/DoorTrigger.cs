using UnityEngine;
using UnityEngine.AI;

public class DoorTrigger : MonoBehaviour
{
    public Animator doorAnim;
    public GameObject door;
    private bool doorOpen = false;
    private MyDoorController doorController;

    void Start()
    {
        doorController = door.GetComponent<MyDoorController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<NavMeshAgent>(out NavMeshAgent agent) )
        {
            if (!doorController.doorOpen)
            {
            door.GetComponent<MeshCollider>().enabled = false;
            // anim
            doorAnim.Play("DoorOpen", 0, 0.0f);
            doorController.doorOpen = true;}
        }
}

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<NavMeshAgent>(out NavMeshAgent agent))
        {
            // if you do not want to automatically close doors, do not implement this method
            if (doorController.doorOpen)
            {   
                door.GetComponent<MeshCollider>().enabled = true;
                doorAnim.Play("DoorClose", 0, 0.0f);
                doorController.doorOpen = false;
            }
        }
    }
}