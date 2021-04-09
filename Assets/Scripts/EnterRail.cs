using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterRail : MonoBehaviour
{
    private GameObject player;
    public GameObject endRail;
    private MoveBall mb;
    private bool onRail;
    private Vector3 direction;
    private Vector3 origPos;    // Start is called before the first frame update
    private Jump jmp;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        direction = (transform.position - endRail.transform.position).normalized;
        origPos = transform.position;
        mb = player.GetComponent<MoveBall>();
        jmp = player.GetComponent<Jump>();
    }

    

    private void OnTriggerEnter(Collider other)
    {
        onRail = true;
        jmp.onRail = true;
        transform.position = player.transform.position;
        player.transform.position = transform.position;
    }

    private void FixedUpdate()
    {
        if (onRail)
        {
            float step = mb.currentSpeed * Time.fixedDeltaTime;
            if (player.transform.position != transform.position)
            {
                player.transform.position = transform.position;
            }
            transform.position = Vector3.MoveTowards(transform.position, endRail.transform.position, step);
            if (Vector3.Distance(transform.position, endRail.transform.position) < 0.2f)
            {
                transform.position = origPos;
                onRail = false;
                
                
            }
            if (jmp.isJumping)
            {
                
                transform.position = origPos;
                onRail = false;
                
            }
            if (player.transform.position != endRail.transform.position)
            {
                jmp.onRail = true;
            }
            else
            {
                jmp.onRail = false;
            }
            jmp.railDir = (endRail.transform.position - transform.position).normalized;
        }
        
      
        

        
    }
}
