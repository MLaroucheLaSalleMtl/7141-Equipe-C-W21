using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookAtTarget : MonoBehaviour
{
    public Transform target;

    public float currentSpeed = 0f;
    public float maxSpeed = 20f;

    private bool speedingUp = false;
    public void OnForward(InputAction.CallbackContext context)
    {
        speedingUp = true;
       
       }

    public void OnSlowDown(InputAction.CallbackContext context)
    {
        speedingUp = false;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 relativePos = (target.position + new Vector3(0, 0.5f, 0)) - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);

        Quaternion current = transform.localRotation;

        transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime);

        transform.Translate(0, 0, currentSpeed * Time.deltaTime);

        if (speedingUp)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, maxSpeed, 0.5f * Time.deltaTime);
        }
        else
        {
            currentSpeed = Mathf.Lerp(currentSpeed, 0, 0.5f * Time.deltaTime);
        }
    }
}
