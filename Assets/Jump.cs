using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    private Rigidbody rb;

    public bool isJumping = false;
    [SerializeField] private float jmpForce;
    public bool grounded;
    private LayerMask ground;
    
    public void OnJump(InputAction.CallbackContext context)
    {
        if (grounded)
        {
            StartCoroutine(JumpSequence());
        }
    }

    IEnumerator JumpSequence()
    {
        isJumping = true;
        yield return new WaitForSeconds(0.1f);
        isJumping = false;
    }
    private void CheckGround()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, -Vector3.up, out hitInfo, 1, ground))
        {
            grounded = true;
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
            rb.AddForce(Vector3.up * jmpForce, ForceMode.Impulse);
        }
        CheckGround();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ground = LayerMask.GetMask("Ground");
    }
}
