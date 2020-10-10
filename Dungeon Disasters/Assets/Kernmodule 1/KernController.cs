using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class KernController : MonoBehaviour
{
    public GameObject cameraPivot;
    public Animator animationsPivot;
    public Animator blendAnimator;
    public Animator introAnimator;
    public Animator anticipationAnimator;
    public Camera cam;

    public float speedH = 2.0f;
    public float speedV = 2.0f;
    public float speedS = 3.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private Vector3 zoom;

    private bool _paused = false;

    void Start()
    {
        //Set Cursor to not be visible
        Cursor.visible = false;
    }

    void Update()
    {
        zoom = cam.transform.localPosition;
        zoom.z -= speedS * Input.GetAxis("Mouse ScrollWheel");
        zoom.z = Mathf.Clamp(zoom.z, 2f, 4.5f);
        cam.transform.localPosition = zoom;

        yaw += speedH * Input.GetAxis("Mouse X");
        pitch += speedV * Input.GetAxis("Mouse Y");

        cameraPivot.transform.eulerAngles = new Vector3(Mathf.Clamp(pitch,-10.0f,5.0f), yaw, 0.0f);

        if (Input.GetKeyDown("d") | Input.GetKeyDown(KeyCode.RightArrow))
        {
            animationsPivot.SetTrigger("toRight");
        }
        else if (Input.GetKeyDown("a") | Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animationsPivot.SetTrigger("toLeft");
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            blendAnimator.SetTrigger("DoAction");
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            _paused = !_paused;
            introAnimator.enabled = _paused;
            blendAnimator.enabled = _paused;
            anticipationAnimator.enabled = _paused;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if ((animationsPivot.gameObject.transform.eulerAngles.y > 110.0f)&&(animationsPivot.gameObject.transform.eulerAngles.y < 130.0f))
        {
            //print("smash");
            anticipationAnimator.GetComponent<AudioSource>().mute = false;
            introAnimator.GetComponent<AudioSource>().mute = true;
            blendAnimator.GetComponent<AudioSource>().mute = true;
        }
        else if ((animationsPivot.gameObject.transform.eulerAngles.y > -10.0f) && (animationsPivot.gameObject.transform.eulerAngles.y < 10.0f))
        {
            //print("intro");

            anticipationAnimator.GetComponent<AudioSource>().mute = true;
            introAnimator.GetComponent<AudioSource>().mute = false;
            blendAnimator.GetComponent<AudioSource>().mute = true;
        }
        else if ((animationsPivot.gameObject.transform.eulerAngles.y > 230.0f) && (animationsPivot.gameObject.transform.eulerAngles.y < 250.0f))
        {
            //print("blend");

            anticipationAnimator.GetComponent<AudioSource>().mute = true;
            introAnimator.GetComponent<AudioSource>().mute = true;
            blendAnimator.GetComponent<AudioSource>().mute = false;
        }
    }




}
