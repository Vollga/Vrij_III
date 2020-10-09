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

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    private bool _paused = false;

    void Start()
    {
        //Set Cursor to not be visible
        Cursor.visible = false;
    }

    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch += speedV * Input.GetAxis("Mouse Y");

        cameraPivot.transform.eulerAngles = new Vector3(Mathf.Clamp(pitch,-10.0f,5.0f), yaw, 0.0f);

        if (Input.GetKeyDown("d") | Input.GetKeyDown(KeyCode.RightArrow))
        {
            animationsPivot.SetTrigger("toRight");
        }
        if (Input.GetKeyDown("a") | Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animationsPivot.SetTrigger("toLeft");
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            blendAnimator.SetTrigger("DoAction");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _paused = !_paused;
            introAnimator.enabled = _paused;
            blendAnimator.enabled = _paused;
            anticipationAnimator.enabled = _paused;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }




}
