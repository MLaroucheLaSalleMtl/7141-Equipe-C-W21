using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveBoard : MonoBehaviour
{
    private Rigidbody rb;
    public PhysicMaterial boardMaterial;
    public GameObject movingSphere;

    private Vector3 previousFramePosition = Vector3.zero;
    public float speed;

    bool slowingDown;
    bool turningLeft;
    public void OnSpeedUp(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            rb.AddForce(Vector3.back * 10, ForceMode.Force);
        }
    }
    public void OnSlowDown(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            slowingDown = true;
        }
        else
        {
            slowingDown = false;
        }
        
    }
    public void OnTurnLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            turningLeft = true;
        }
        else
        {
            turningLeft = false;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        Vector3 leftdirection = new Vector3(transform.position.x + 1, transform.position.y + 0.3f, transform.position.z);

        if (slowingDown) {
            boardMaterial.dynamicFriction += 0.7f * Time.deltaTime;
        }
        else if(!slowingDown)
        {
            boardMaterial.dynamicFriction = 0.3f;
        }

        if (turningLeft && speed > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, leftdirection, step);
        }
        if (!slowingDown)
        {
            transform.position = Vector3.MoveTowards(transform.position, movingSphere.transform.position, 0.1f);
        }
    }

    private void FixedUpdate()
    {
        CheckVelocity();
    }
    private void CheckVelocity()
    {
        
        float movementPerFrame = Vector3.Distance(previousFramePosition, transform.position);
        speed = movementPerFrame / Time.deltaTime;
        previousFramePosition = transform.position;
        
    }
}
