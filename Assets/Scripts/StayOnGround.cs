using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Allo
public class StayOnGround : MonoBehaviour
{
    private Vector3 previousPos = new Vector3();    
        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool isGrounded;
        isGrounded = isSnowboardGrounded();

        if (isGrounded)
        {
            previousPos = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z); ;
        }
        else
        {
            transform.position = previousPos;
        }

    }

    private bool isSnowboardGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 0.5f);

    }
}
