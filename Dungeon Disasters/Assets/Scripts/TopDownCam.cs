﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class TopDownCam : MonoBehaviour
{
    
    [Range(0.0f, 1.0f)]
    public float cameraSpeed = 1;
    public float maxJoystickOffset = 1;

    [Header("Offset")]
    public Vector3 offsetPos = new Vector3(0,40,-14);
    public Vector3 offsetAngle = new Vector3(70, 0,0);
    
    Transform target;
    private Vector3 velocity = Vector3.zero;
    private Vector3 joystickPos = Vector3.zero;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = new Vector3(target.position.x,0,target.position.z) + offsetPos;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        joystickPos = new Vector3(Input.GetAxis("HorizontalR"), 0, Input.GetAxis("VerticalR")) * maxJoystickOffset;
        Vector3 finalPos = new Vector3(target.position.x, 0, target.position.z) + offsetPos + joystickPos;
        Vector3 smoothPos = Vector3.SmoothDamp(transform.position, finalPos,ref velocity, cameraSpeed);
        transform.position = smoothPos;
        transform.eulerAngles = offsetAngle;
    }
}
