using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveTarget : MonoBehaviour
{
    public GameObject board;
    public void OnTurnLeft(InputAction.CallbackContext context)
    {
        //transform.position = new Vector3(transform.position.x , transform.position.y, transform.position.z - 3);

        transform.RotateAround(board.transform.position, Vector3.down, 10);
    }

    public void OnTurnRight(InputAction.CallbackContext context)
    {
        //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 3);
        transform.RotateAround(board.transform.position, Vector3.up, 10);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
