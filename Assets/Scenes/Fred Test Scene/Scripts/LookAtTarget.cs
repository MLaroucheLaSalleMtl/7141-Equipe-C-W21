using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookAtTarget : MonoBehaviour
{
    private Rigidbody rb;
    public MoveTarget moveTarget;

    public Transform target;

    public float currentSpeed = 0f;
    public float maxSpeed = 20f;

    public bool speedingUp = false;
    public GameObject spherePosition;
    private Flipping flip;
    private Jumping jmp;
    public void OnForward(InputAction.CallbackContext context)
    {
        if (!speedingUp)
        {
            speedingUp = true;
            moveTarget.stopped = false;
            moveTarget.angle = 0;
            moveTarget.SpeedingUp();
           
        }
       }

    public void OnSlowDown(InputAction.CallbackContext context)
    {
        if (speedingUp && !flip.isFlipping)
        {
            speedingUp = false;
            moveTarget.stopped = true;
            moveTarget.StoppingTurn();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        moveTarget = target.GetComponent<MoveTarget>();
        rb = GetComponent<Rigidbody>();
        flip = GetComponent<Flipping>();
        jmp = GetComponent<Jumping>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!flip.isFlipping)
        {
            Vector3 relativePos = (target.position + new Vector3(0, 0.5f, 0)) - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);

            Quaternion current = transform.localRotation;

            transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime);

        }
        //transform.Translate(0, 0, currentSpeed * Time.deltaTime);
        

        if (speedingUp)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, maxSpeed, 0.5f * Time.deltaTime);
            
            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
            
        }
        else if (!speedingUp )
        {
            currentSpeed = Mathf.Lerp(currentSpeed, 0, 0.5f * Time.deltaTime);
            //transform.Translate( currentSpeed * Time.deltaTime,0,0);
            transform.position += new Vector3(0, 0, -currentSpeed * Time.deltaTime);
           
            
          
        }  
    }
}
