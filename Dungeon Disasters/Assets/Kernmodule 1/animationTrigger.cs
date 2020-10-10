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

    public AudioClip grunt;
    public AudioClip smash;
    public AudioClip foot;
    public AudioClip intro;
    public AudioClip[] stab;
    public float volume = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void playStab()
    {
        this.GetComponent<AudioSource>().PlayOneShot(stab[Random.Range(0, stab.Length)],volume);
    }

    void playIntroClip()
    {
        this.GetComponent<AudioSource>().clip = intro;
        this.GetComponent<AudioSource>().volume = volume;
        this.GetComponent<AudioSource>().PlayOneShot(intro, volume  * 1.2f);

    }

    void playAudio()
    {
        this.GetComponent<AudioSource>().clip = grunt;
        this.GetComponent<AudioSource>().volume = volume * 0.8f;
        this.GetComponent<AudioSource>().PlayOneShot(grunt,volume * 0.8f);
    }
    void footfall()
    {
        this.GetComponent<AudioSource>().PlayOneShot(foot, volume * 0.5f);
    }

    void playEffect()
    {
        vfx.SendEvent(eventName);
        this.GetComponent<AudioSource>().PlayOneShot(smash,volume);

    }
    // Update is called once per frame
}
