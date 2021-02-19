using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveTarget2 : MonoBehaviour
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
        
            if (angle > -80)
            {
                transform.RotateAround(board.transform.position, Vector3.up, 10);
                angle -= 10;
            }
       
    }

    // Start is called before the first frame update
    void Start()
    {
        angle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
