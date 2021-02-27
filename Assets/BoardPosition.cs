using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardPosition : MonoBehaviour
{
    public GameObject rollB;
    private Flipping flip;
    public GameObject com;
    private Vector3 boardPos = new Vector3();
    private Vector3 topRollB = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        flip = GetComponent<Flipping>();
    }

    // Update is called once per frame
    void Update()
    {
       
            boardPos = new Vector3(rollB.transform.position.x, rollB.transform.position.y - 0.43f, rollB.transform.position.z);
            if (transform.position != boardPos)
            {
                transform.position = boardPos;
            }
        
        
        
    }
}
