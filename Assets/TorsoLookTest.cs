using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorsoLookTest : MonoBehaviour
{
    public GameObject spine;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spine.transform.LookAt(target.transform, Vector3.forward);
        
    }
}
