using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Flipping : MonoBehaviour
{
   
    public GameObject rollBall; //Référence vers la balle de controle
    private Jump jmp; //Référence vers le script jump
    public GameObject board; //Référence vers le snowboard
    public GameObject com; //Center of mass
    public bool isFlipping = false; //Bool pour faire un flip

    private bool isFlippingForward = false; //Bool pour faire un frontflip
    public bool isFlippingBackwards = false; //Bool pour faire un backflip

    //Input system pour front flip
    public void FlipForward(InputAction.CallbackContext context)
    {
        if (context.performed && !jmp.grounded && !jmp.onRail)
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

    //Input system pour backflip
    public void FlipBackwards(InputAction.CallbackContext context)
    {
        if (context.performed && !jmp.grounded && !jmp.onRail)
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
        
    }

    // Update is called once per frame
    void Update()
    {
        //Fait rotationner le personnage avec RotateAround pour les flips
        if (isFlippingBackwards)
        {
            transform.position = rollBall.transform.position;
            transform.RotateAround(rollBall.transform.position, -transform.forward, 400 * Time.deltaTime);

        } if (isFlippingForward)
        {
            transform.position = rollBall.transform.position;
            transform.RotateAround(rollBall.transform.position, transform.forward, 400 * Time.deltaTime);
        }
    }
}
