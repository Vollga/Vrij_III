using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    public Animator target;
    public string engageTrigger;
    public string disengageTrigger;

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //open Door
            //print("Open Sesame");
            target.SetTrigger(engageTrigger);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //close Door
            //print("Close Sesame");
            target.SetTrigger(disengageTrigger);
        }
    }
}
