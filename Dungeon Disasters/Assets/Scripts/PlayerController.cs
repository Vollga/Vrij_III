using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 6.0F;
    public float gravity = 20.0F;

    public Animator playerAnimator;
    private Vector3 moveDirection = Vector3.zero;

    CharacterController character;

    private void Start()
    {
        character = this.GetComponent<CharacterController>();
    }



    void LateUpdate()
    {
        if (character.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            playerAnimator.SetInteger("Dir X", (int)moveDirection.normalized.x);
            playerAnimator.SetInteger("Dir Y", (int)moveDirection.normalized.z);
            if (moveDirection != Vector3.zero)
            {
                playerAnimator.SetBool("walking", true);
                print("walking");
            }
            else
            {
                playerAnimator.SetBool("walking", false);
            }
            print((int)moveDirection.normalized.x + ", " + (int)moveDirection.normalized.z);            
            moveDirection = Vector3.ClampMagnitude(moveDirection, 1.0f);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        character.Move(moveDirection * Time.deltaTime);
    }
}
