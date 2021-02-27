using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxSlope : MonoBehaviour
{
    private MoveBall mb;

    private float groundAngle;
    private bool grounded;

    private Vector3 forward;
    RaycastHit hitInfo;
    private LayerMask ground;
    // Start is called before the first frame update
    void Start()
    {
        mb = GetComponent<MoveBall>();
    }

    private void CalculateForward()
    {
        forward = Vector3.Cross(hitInfo.normal, -transform.right);
    }
    private void CalculateDirection()
    {

    }
    private void CalculateGroundAngle()
    {
        groundAngle = Vector3.Angle(hitInfo.normal, transform.forward);
    }
    private void DrawDebug()
    {
        Debug.DrawLine(transform.position, transform.position + forward * 2, Color.red);
       // Debug.DrawLine(transform.position, transform.position - Vector3.up * 0.5f, Color.green);
    }

    private void CheckGround()
    {
        if (Physics.Raycast(transform.position, -Vector3.up, out hitInfo, 1, ground))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        ground = LayerMask.GetMask("Ground"); ;
        CheckGround();
        CalculateForward();
        CalculateGroundAngle();
        DrawDebug();
    }
}
