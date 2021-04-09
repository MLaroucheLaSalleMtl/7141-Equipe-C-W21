using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Allo
public class JumpList : MonoBehaviour
{
    public Jump jmp;
    public List<GameObject> jmpList;
    private GameObject player;
    private GameObject incomingJump;
    private float distance;
    public bool approchingJump;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //jmpList = GetComponentsInChildren<GameObject>();
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Jump"))
        {
            jmpList.Add(g);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < jmpList.Count; i++) {
            distance = Vector3.Distance(player.transform.position, jmpList[i].transform.position);
            if (distance < 10)
            {
                incomingJump = jmpList[i];
                approchingJump = true;
                jmp.grounded = true;
            }
          }
        if(Vector3.Distance(player.transform.position, incomingJump.transform.position) > 10)
        {
            approchingJump = false;
        }
    }
}
