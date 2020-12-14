using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    Animator door;

    // Start is called before the first frame update
    void Start()
    {
        door = this.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //open Door
            print("Open Sesame");
            door.SetTrigger("Approach");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //close Door
            print("Close Sesame");
            door.SetTrigger("Leave");
        }
    }
}
