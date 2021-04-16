using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviorDisabler : MonoBehaviour
{
    private RagdollControll rc; //r�f�rence vers le script ragdollcontroll

    private GameObject player; //r�f�rence vers le joueur (sphere)
    public Rigidbody snowboardRb; //rigidbody du snowboard
    public LookAtTarget2 lat; //script look at target
    public BoardPosition bp; //script boardposition
    public MoveTarget2 mt; //script movetarget
    public CapsuleCollider snowboardCollider; //collider du snowboard

    private List<Behaviour> componentsList = new List<Behaviour>(); //liste des components � disable
    // Start is called before the first frame update
    void Start()
    {
        rc = GetComponent<RagdollControll>();
        player = GameObject.FindGameObjectWithTag("Player");
        snowboardCollider.enabled = false; //disable le collider au depart
        AddToList(lat, mt, bp); //ajoute les componenets � la liste (components qui servent au controle du joueur)
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (rc.isDead) //quand le joueur tombe (activ� par un collider trigger)
        {
            player.SetActive(false); //les controles du joueur sont d�sactiv�s
           
            snowboardCollider.enabled = true; //collider du snowboard est activ�

            for (int i= 0; i < componentsList.Count; i++) //tous les components de la liste sont d�sactiv�
            {
                componentsList[i].enabled = false;
                
            }
            snowboardRb.useGravity = true; // snowboard utilise la gravit�
        }
    }

    // fonction qui ajoute un component � la liste
    void AddToList(params Behaviour[] cmp)
        {
            for (int i = 0; i < cmp.Length; i++)
            {
                componentsList.Add(cmp[i]);
            }
        }

    //Fonction pour r�animer le joueur (appel� par RagdollControll)
    public void Revive()
    {
        player.SetActive(true); //Active le joeur

        snowboardCollider.enabled = false; //enl�ve le collider

        for (int i = 0; i < componentsList.Count; i++) //R�active les controles
        {
            componentsList[i].enabled = true;

        }
        snowboardRb.useGravity = false ;
    }
}
