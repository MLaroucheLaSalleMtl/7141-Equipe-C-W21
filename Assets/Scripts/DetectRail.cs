using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectRail : MonoBehaviour
{
    private Jump jmp;
    // Start is called before the first frame update
    void Start()
    {
        jmp = GameObject.FindGameObjectWithTag("Player").GetComponent<Jump>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Rail")
        {
            jmp.onRail = true;
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Rail")
        {
            jmp.onRail = false;
        }
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
