using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Allo
public class LookAtTarget2 : MonoBehaviour
{
    public Transform target;
    private Flipping flip;

    private Vector3 dir = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        flip = GetComponent<Flipping>();
       
    }

    // Update is called once per frame
    void Update()
    {
        //dir = (transform.position - target.transform.position).normalized;
        if (!flip.isFlipping)
        {
            Vector3 relativePos = (target.position + new Vector3(0, 0.5f, 0)) - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);

            Quaternion current = transform.localRotation;

            transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime * 4);

        }
    }
}
