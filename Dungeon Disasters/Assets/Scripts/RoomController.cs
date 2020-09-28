using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public GameObject tileGroup;
    // Start is called before the first frame update
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tileGroup.SetActive(true);
            print("Enabled Room");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tileGroup.SetActive(false);
            print("Disabled Room");

        }
    }
}
