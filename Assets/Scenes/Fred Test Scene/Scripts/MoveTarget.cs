using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveTarget : MonoBehaviour
{
    public GameObject board;
    public GameObject motherSphere;
    public Jumping jmp;

    public int angle;
    public bool stopped = false;
   
    public void OnTurnLeft(InputAction.CallbackContext context)
    {

        if (angle < 80)
        {
            transform.RotateAround(board.transform.position, Vector3.down, 10);
            angle += 10;
        }
    }

    public void OnTurnRight(InputAction.CallbackContext context)
    {
        if (jmp.isGrounded)
        {
            if (angle > -80)
            {
                transform.RotateAround(board.transform.position, Vector3.up, 10);
                angle -= 10;
            }
        }
    }

    public void StoppingTurn()
    {
        transform.position = new Vector3(board.transform.position.x -10, board.transform.position.y, board.transform.position.z );
        board.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

    }

    public void SpeedingUp()
    {
        transform.position = motherSphere.transform.position;
        board.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }
    // Start is called before the first frame update
    void Start()
    {
        angle = 0;
        jmp = GameObject.FindGameObjectWithTag("Snowboard").GetComponent<Jumping>();
        //motherSphere = GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
