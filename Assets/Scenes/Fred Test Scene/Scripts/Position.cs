using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Position : MonoBehaviour
{
    public GameObject target;
    private Vector3 positionAhead = new Vector3();

    
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        positionAhead = new Vector3(target.transform.position.x , target.transform.position.y -2, target.transform.position.z - 10);

        if (transform.position != positionAhead)
        {
            transform.position = positionAhead;
        }
    }
}
