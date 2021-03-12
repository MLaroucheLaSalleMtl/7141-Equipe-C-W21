using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Allo
public class Position : MonoBehaviour
{
    public GameObject target;
    private Vector3 positionAhead = new Vector3();
    RaycastHit hitInfo;
    private Vector3 pos = new Vector3();
    private void Ground()
    {
        
        if (Physics.Raycast(transform.position + Vector3.up +Vector3.up ,Vector3.down, out hitInfo, 100))
        {
            pos.y = hitInfo.point.y;
        }
    }
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Ground();
        transform.position = new Vector3(target.transform.position.x, pos.y, target.transform.position.z -10);
       /*
        if (transform.position != positionAhead)
        {
            transform.position = positionAhead;
        } */
    }
}
