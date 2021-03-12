using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//Allo
public class MoveTarget2 : MonoBehaviour
{
    public GameObject board;
    public GameObject motherSphere;
    public MoveBall moveBall;
    public GameObject ball;
    private Jump jmp;

    public float angle;
    public bool stopped = false;

    private bool turningRight = false;
    private bool turningLeft = false;

    private Vector3 origPos = new Vector3();

    public bool upSlope = false;

    RaycastHit hitInfo;
    private Vector3 pos = new Vector3();
    private Vector3 prevpos = new Vector3();
    private void Ground()
    {

        if (Physics.Raycast(transform.position + Vector3.up + Vector3.up, Vector3.down, out hitInfo, 50))
        {
            pos.y = hitInfo.point.y;
        }
    }
    public void OnTurnLeft(InputAction.CallbackContext context)
    {

        if ( context.performed)
        {
            turningLeft = true;
        }else if (context.canceled)
        {
            turningLeft = false;
        }
    }

    public void OnTurnRight(InputAction.CallbackContext context)
    {
        
            if (context.performed)
            {
            turningRight = true;
            }else if (context.canceled)
        {
            turningRight = false;
        }
       
    }

    // Start is called before the first frame update
    void Start()
    {
        moveBall = ball.GetComponent<MoveBall>();
        jmp = GameObject.FindGameObjectWithTag("Player").GetComponent<Jump>();
    }

    // Update is called once per frame
    void Update()
    {
        origPos = motherSphere.transform.position;
        if (turningRight && jmp.grounded )
        {
            
                transform.RotateAround(board.transform.position, Vector3.up, 120 * Time.deltaTime);
            angle++;
            
        }else if (turningRight && !jmp.grounded){
            transform.RotateAround(board.transform.position, Vector3.up, 300 * Time.deltaTime);
        }
        if (turningLeft  && jmp.grounded)
        {
            
                transform.RotateAround(board.transform.position, Vector3.down, 120 * Time.deltaTime);
            angle--;

        }else if (turningLeft && !jmp.grounded){
            transform.RotateAround(board.transform.position, Vector3.down, 300 * Time.deltaTime);
        }
       
        Ground();
        transform.position = new Vector3(transform.position.x, pos.y, transform.position.z);

        if (Vector3.Distance(transform.position, board.transform.position) < 10)
        {
            float dist = Vector3.Distance(transform.position, board.transform.position);
            float missing = 10 - dist;
            transform.position += new Vector3(moveBall.direction.x, moveBall.direction.y, moveBall.direction.z) ;
        }
        
        if (transform.position.y > board.transform.position.y + 1)
        {
            upSlope = true;
        }
        else
        {
            upSlope = false;
        }
    }
}
