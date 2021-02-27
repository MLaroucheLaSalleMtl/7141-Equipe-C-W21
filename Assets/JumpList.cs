using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpList : MonoBehaviour
{
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
            if (distance < 30)
            {
                incomingJump = jmpList[i];
                approchingJump = true;
            }
          }
        if(Vector3.Distance(player.transform.position, incomingJump.transform.position) > 50)
        {
            approchingJump = false;
        }
    }
}
