using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TopDownCam : MonoBehaviour
{
    public Transform target;
    [Range(0.0f, 1.0f)]
    public float cameraSpeed = 1;

    [Header("Offset")]
    public Vector3 offsetPos = new Vector3(0,40,-14);
    public float _angle = 70;

    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        transform.position = new Vector3(target.position.x,0,target.position.z) + offsetPos;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 finalPos = new Vector3(target.position.x, 0, target.position.z) + offsetPos;
        Vector3 smoothPos = Vector3.SmoothDamp(transform.position, finalPos,ref velocity, cameraSpeed);
        transform.position = smoothPos;
        transform.eulerAngles = new Vector3( _angle,0,0);
    }
}
