using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Flipping : MonoBehaviour
{
    private Jumping jmp;
    private Rigidbody rb;
    public GameObject com; //Center of mass
    public bool isFlipping = false;
    private bool isFlippingRight = false;
    private bool isFlippingLeft= false;
    private bool isFlippingForward = false;
    private bool isFlippingBackwards = false;

    public void FlipRight(InputAction.CallbackContext context)
    {
        if (context.performed && !jmp.isGrounded)
        {
            isFlippingRight = true;
            isFlipping = true;
        }else if (context.canceled)
        {
            isFlippingRight = false;
            isFlipping = false;
            Debug.Log("Stopped Flip");
        }


    }

    public void FlipLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
        {

        }
        else if (context.canceled)
        {

        }


    }
    public void FlipForward(InputAction.CallbackContext context)
    {
        if (context.performed)
        {

        }
        else if (context.canceled)
        {

        }


    }
    public void FlipBackwards(InputAction.CallbackContext context)
    {
        if (context.performed)
        {

        }
        else if (context.canceled)
        {

        }


    }
    private void Start()
    {
        jmp = GetComponent<Jumping>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!jmp.isGrounded)
        {
            rb.constraints = RigidbodyConstraints.None;
           if (isFlippingRight)
            {
                transform.RotateAround(com.transform.position, Vector3.right, 200 * Time.deltaTime);
            }

        }
    }
}
