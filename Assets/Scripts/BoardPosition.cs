using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Allo
public class BoardPosition : MonoBehaviour
{
    public GameObject rollB; //référence vers ball roller
    
    private Vector3 boardPos = new Vector3(); //Position du snowboard

    // Update is called once per frame
    void Update()
    {
            //Trouve la position voulue et ajuste la position du snowboard
            boardPos = new Vector3(rollB.transform.position.x, rollB.transform.position.y - 0.48f, rollB.transform.position.z);
            if (transform.position != boardPos)
            {
                transform.position = boardPos;
            }
        
        
        
    }
}
