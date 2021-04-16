using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Jump : MonoBehaviour
{
    private Rigidbody rb; //Rigidbody de la balle

    public bool isJumping = false; //Bool pour activer le saut
    [SerializeField] private float jmpForce; //Force de saut
    public bool grounded; //Bool pour savoir si le personnage est au sol 
    private LayerMask ground; //Layers du terrain
    public bool onRail;//Bool pour savoir si le personnag est sur une ¨Rail¨
    public JumpList jmpList; //Script JumpList
    public Vector3 railDir = new Vector3(); //Direction de la rail

    //Input system
    public void OnJump(InputAction.CallbackContext context)
    {
        if (grounded || onRail || jmpList.approchingJump)
        {
            StartCoroutine(JumpSequence());
        }
    }

    //Coroutine pour activer isJumping
    IEnumerator JumpSequence()
    {
        isJumping = true;
        yield return new WaitForSeconds(0.1f);
        isJumping = false;
    }

    //Raycast pour savoir si le personnage est au sol
    private void CheckGround()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, -Vector3.up, out hitInfo, 1, ground))
        {
            grounded = true;
            onRail = false; //Enleve le onRail, car personnage au sol
        }
        else
        {
            grounded = false;
           
        }
    }

    private void Update()
    {
        if (grounded && isJumping)
        {
            rb.AddForce(Vector3.up * jmpForce, ForceMode.Impulse); //Force pour sauter
        }else if (onRail && isJumping)
        {
            //Sauter quand il est sur une rail
            onRail = false;
            rb.AddForce(railDir * jmpForce , ForceMode.Impulse);
            rb.AddForce(Vector3.up * jmpForce , ForceMode.Impulse);
        }
        CheckGround(); //Check ground à chaque update
    }

  

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ground = LayerMask.GetMask("Ground");
        
    }
}
