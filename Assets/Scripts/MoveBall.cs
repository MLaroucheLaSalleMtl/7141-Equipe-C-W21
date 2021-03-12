using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//Allo
public class MoveBall : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject targetSphere;
    public GameObject motherSphere;
    private MoveTarget2 mt;
    public Jump jmp;
    public JumpList jl;

    public bool isSpeedingUp = false;
    private bool isSlowingDown = false;
    private bool isTurningRight = false;
    private bool isTurningLeft = false;

    public float speed;
    public float maxSpeed;
    public float currentSpeed;

    public Vector3 direction = new Vector3();

    private Vector3 dir = new Vector3();
    private Vector3 dirLeft = new Vector3();
    private Vector3 dirRight = new Vector3();
    private void PerpendStopping() {
        float perpSpeed = speed / 3;
        dir = (transform.position - targetSphere.transform.position).normalized;
        dirRight = Vector3.Cross(dir, Vector3.up).normalized;
        dirLeft = -dirRight;
        if (isTurningLeft)
        {
            rb.AddForce(dirLeft * perpSpeed, ForceMode.Force);
        }
        else if (isTurningRight)
        {
            rb.AddForce(dirRight * perpSpeed, ForceMode.Force);
        }
        SlippageCorrection();
    }   

    private void SlippageCorrection()
    {
        int frame = 1;
        Vector3 firstPos = new Vector3();
        Vector3 secPos = new Vector3();
        Vector3 slipDir = new Vector3();
        Vector3 invSlipDir = new Vector3();

        if (frame == 1)
        {
            firstPos = transform.position;
            frame++;
        }else if (frame == 2)
        {
            secPos = transform.position;
            frame--;
        }

        slipDir = (firstPos - secPos).normalized;
        invSlipDir = Vector3.Cross(slipDir, Vector3.up).normalized;
        if (jmp.grounded)
        {
            rb.AddForce(-slipDir * currentSpeed/2, ForceMode.Force);
        }else if (jl.approchingJump || !jmp.grounded)
        {
            rb.AddForce(-slipDir * currentSpeed/5, ForceMode.Force);
        }
        Debug.DrawLine(transform.position, transform.position + invSlipDir * 3, Color.green, Mathf.Infinity);
        Debug.DrawLine(transform.position, transform.position + slipDir * 3, Color.red, Mathf.Infinity);
        Debug.DrawLine(transform.position, transform.position + -slipDir * 3, Color.yellow, Mathf.Infinity);


    }
    
public void OnForward(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isSpeedingUp = true;

        } else if (context.canceled)
        {
            isSpeedingUp = false;
        }
    }
    public void OnSlowDown(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isSlowingDown = true;
        } else if (context.canceled)
        {
            isSlowingDown = false;
        }
    }

    public void OnTurnRight(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isTurningRight = true;
        }
        else if (context.canceled)
        {
            isTurningRight = false;
        }
    }
    public void OnTurnLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isTurningLeft = true;
        }
        else if (context.canceled)
        {
            isTurningLeft = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mt = targetSphere.GetComponent<MoveTarget2>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mSDir = new Vector3();
        mSDir = (motherSphere.transform.position - transform.position).normalized;
        PerpendStopping();
        direction = (targetSphere.transform.position - transform.position).normalized;
        Vector3 leftDir = Vector3.Cross(direction, Vector3.up).normalized;
        Vector3 rightDir = Vector3.Cross(direction, Vector3.down).normalized;

        currentSpeed = rb.velocity.magnitude;
        if (isSpeedingUp && !mt.upSlope)
        {
            rb.AddForce(direction * speed*2, ForceMode.Acceleration);

        } if (isSlowingDown && rb.velocity.magnitude > 0)
        {
            rb.AddForce(direction * -speed*0.3f, ForceMode.Acceleration);

        } if (isTurningRight)
        {
            rb.AddForce(rightDir * speed, ForceMode.Acceleration); 
           // rb.AddForce(mSDir * speed/2, ForceMode.Acceleration);
            //direction = Vector3.left;
        } if (isTurningLeft)
        {
            rb.AddForce(leftDir * speed, ForceMode.Acceleration);
           // rb.AddForce(mSDir * speed / 2, ForceMode.Acceleration);
            //direction = Vector3.right;
        } 
    }
    private void FixedUpdate()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }
    }

    



        



    
        
}
