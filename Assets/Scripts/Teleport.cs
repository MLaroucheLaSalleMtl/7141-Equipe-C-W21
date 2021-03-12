using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Allo
public class Teleport : MonoBehaviour
{
    public Transform destination;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        player.position = destination.transform.position;
    }
}
