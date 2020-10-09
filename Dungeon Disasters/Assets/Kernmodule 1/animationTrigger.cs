using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;
using UnityEngine.VFX;

public class animationTrigger : MonoBehaviour
{
    public VisualEffect vfx;
    public string eventName;
    public bool trigger = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    void playEffect()
    {
        vfx.SendEvent(eventName);
    }
    // Update is called once per frame
}
