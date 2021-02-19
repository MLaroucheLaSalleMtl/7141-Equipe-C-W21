using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    public Animator anim;
    public Rigidbody rb;
    public Jumping jumping; //référence pour utiliser les bools
    public Jumping isGrounded; //référence pour utiliser les bools
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //snowBoarderRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Jump"))
        {
            //anim.Play("JumpUp");
            anim.SetTrigger("isJumping");
        }

        if (rb.velocity.magnitude > 0.2f)
        {
            //anim.Play("Slide");
            anim.SetTrigger("isSliding");
            //Debug.Log(rb.velocity.magnitude);
        }
        else if(rb.velocity.magnitude == 0f)
        {
            Debug.Log("not recognized ");
        }
    }

    public void ChangeAnim(string state)
    {
        anim.Play(state);
    }
}
