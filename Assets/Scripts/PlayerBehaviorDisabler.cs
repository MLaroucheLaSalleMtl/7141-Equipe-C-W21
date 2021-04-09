using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviorDisabler : MonoBehaviour
{
    private RagdollControll rc;

    private GameObject player;
    

    public Rigidbody snowboardRb;
    public LookAtTarget2 lat;
    public BoardPosition bp;
    public MoveTarget2 mt;
    public CapsuleCollider snowboardCollider;

    private List<Behaviour> componentsList = new List<Behaviour>();
    // Start is called before the first frame update
    void Start()
    {
        rc = GetComponent<RagdollControll>();
        player = GameObject.FindGameObjectWithTag("Player");

        
        


        snowboardCollider.enabled = false;

        AddToList(lat, mt, bp);
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (rc.isDead)
        {
            
            player.SetActive(false);
           
            snowboardCollider.enabled = true; 

            for (int i= 0; i < componentsList.Count; i++)
            {
                componentsList[i].enabled = false;
                
            }
            snowboardRb.useGravity = true;
        }
    }

        void AddToList(params Behaviour[] cmp)
        {
            for (int i = 0; i < cmp.Length; i++)
            {
                componentsList.Add(cmp[i]);
            }
        }

    public void Revive()
    {
        player.SetActive(true);

        snowboardCollider.enabled = false;

        for (int i = 0; i < componentsList.Count; i++)
        {
            componentsList[i].enabled = true;

        }
        snowboardRb.useGravity = false ;
    }
}
