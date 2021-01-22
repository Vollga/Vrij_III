using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    #region Singleton
    public static PlayerController Player;
    #endregion


    public float speed = 6.0F;
    public float runSpeed = 1.5f;
    public float gravity = 20.0F;

    public Animator playerAnimator;
    private Vector3 moveDirection = Vector3.zero;

    CharacterController character;

    void Awake()
    {
        Player = this;
    }

    private void Start()
    {
        character = this.GetComponent<CharacterController>();
        StartCoroutine(PlayerReset());
    }



    void Update()
    {
        if (character.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            playerAnimator.SetFloat("Dir X", Input.GetAxis("Horizontal"));
            playerAnimator.SetFloat ("Dir Y", Input.GetAxis("Vertical"));
            if (moveDirection != Vector3.zero)
            {
                playerAnimator.SetBool("walking", true);
                //print("walking");
            }
            else
            {
                playerAnimator.SetBool("walking", false);
            }
            //print((int)moveDirection.normalized.x + ", " + (int)moveDirection.normalized.z);   
            moveDirection = Vector3.ClampMagnitude(moveDirection, 1.0f);
            if (Input.GetButton("Run"))
            {
                moveDirection *= runSpeed;
            }
            moveDirection = transform.TransformDirection(moveDirection);
            
            moveDirection *= speed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        character.Move(moveDirection * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(PlayerReset());
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    IEnumerator PlayerReset()
    {
        character.enabled = false;

        yield return new WaitForSeconds(.1f);

        transform.position = GameObject.Find("TargetPortal").transform.position + new Vector3 (0,0.2f,0);
        playerAnimator.SetTrigger("teleport");
        
        yield return new WaitForSeconds(2f);
        
        character.enabled = true;
        
        yield break;
    }

}
