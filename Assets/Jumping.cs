using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jumping : MonoBehaviour
{
    private LookAtTarget lat;
    public bool isJumping = false;
    public bool isGrounded = true;
    private bool jumpFinished = true;
    private Rigidbody rb;
    public float distanceGround = 0;
    public GameObject moveTarget;
    public void OnJump(InputAction.CallbackContext context)
    {
        isJumping = true;
        jumpFinished = false;
        StartCoroutine(JumpSequence());
        Debug.Log("Test");
    }

    IEnumerator JumpSequence()
    { 
        isGrounded = false;
        yield return new WaitForSeconds(0.3f);
        isJumping = false;
        jumpFinished = true; 
    } 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lat = GetComponent<LookAtTarget>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isJumping && isGrounded)
        {
           rb.AddForce(new Vector3(0,200, 0), ForceMode.Impulse);
        }
    }

    void Update()
    {
        isGrounded = isSnowboardGrounded();
        //jumpFinished = isSnowboardGrounded();
       /* if (!isGrounded && !isJumping && jumpFinished)
        {
            transform.Translate(Vector3.down * 9.81f * Time.deltaTime);
           // rb.AddForce(Vector3.down * Time.deltaTime, ForceMode.Impulse);
        } */
        if (!isGrounded)
        {
            lat.speedingUp = false;
            
        }
    }

    private bool isSnowboardGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, distanceGround);
        
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    } */
}
