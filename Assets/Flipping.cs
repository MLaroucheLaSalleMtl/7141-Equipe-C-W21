using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Flipping : MonoBehaviour
{
    // private Jumping jmp;
    public GameObject rollBall;
    private Jump jmp;
    public GameObject board;
    public GameObject com; //Center of mass
    public bool isFlipping = false;
    private bool isFlippingRight = false;
    private bool isFlippingLeft= false;
    private bool isFlippingForward = false;
    public bool isFlippingBackwards = false;

    private BoardPosition bp;
    public void FlipRight(InputAction.CallbackContext context)
    {
       if (context.performed && !jmp.grounded)
        {
            isFlipping = true;
            isFlippingRight = true;
        }else if (context.canceled)
        {
            isFlipping = false;
            isFlippingRight = false;
        }


    }

    public void FlipLeft(InputAction.CallbackContext context)
    {
        if (context.performed && !jmp.grounded)
        {
            isFlipping = true;
            isFlippingLeft = true;
        }
        else if (context.canceled)
        {
            isFlipping = false;
            isFlippingLeft = false;
        }


    }
    public void FlipForward(InputAction.CallbackContext context)
    {
        if (context.performed && !jmp.grounded)
        {
            isFlipping = true;
            isFlippingForward = true;
        }
        else if (context.canceled)
        {
            isFlipping = false;
            isFlippingForward = false;
        }


    }
    public void FlipBackwards(InputAction.CallbackContext context)
    {
        if (context.performed && !jmp.grounded)
        {
            isFlipping = true;
            isFlippingBackwards = true;
        }
        else if (context.canceled)
        {
            isFlipping = false;
            isFlippingBackwards = false;
        } 


    }
    private void Start()
    {

        jmp = rollBall.GetComponent<Jump>();
        bp = GetComponent<BoardPosition>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isFlippingBackwards)
        {
            transform.position = rollBall.transform.position;
            transform.RotateAround(rollBall.transform.position, -transform.forward, 400 * Time.deltaTime);

        } if (isFlippingForward)
        {
            transform.position = rollBall.transform.position;
            transform.RotateAround(rollBall.transform.position, transform.forward, 400 * Time.deltaTime);
        }if (isFlippingRight)
        {
            transform.position = rollBall.transform.position;
            transform.RotateAround(rollBall.transform.position, transform.up, 400 * Time.deltaTime);
        }if (isFlippingLeft)
        {
            transform.position = rollBall.transform.position;
            transform.RotateAround(rollBall.transform.position, -transform.up, 400 * Time.deltaTime);
        }
    }
}
