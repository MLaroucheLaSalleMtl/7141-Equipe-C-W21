using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookAtTarget : MonoBehaviour
{
    public MoveTarget moveTarget;

    public Transform target;

    public float currentSpeed = 0f;
    public float maxSpeed = 20f;

    private bool speedingUp = false;
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
        if (speedingUp)
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
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 relativePos = (target.position + new Vector3(0, 0.5f, 0)) - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);

        Quaternion current = transform.localRotation;

        transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime);


        //transform.Translate(0, 0, currentSpeed * Time.deltaTime);
        

        if (speedingUp)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, maxSpeed, 0.5f * Time.deltaTime);
            transform.Translate(0, 0, currentSpeed * Time.deltaTime);
        }
        else
        {
            currentSpeed = Mathf.Lerp(currentSpeed, 0, 0.5f * Time.deltaTime);
            //transform.Translate( currentSpeed * Time.deltaTime,0,0);
            transform.position += new Vector3(-currentSpeed * Time.deltaTime, 0, 0);
        }
    }
}
