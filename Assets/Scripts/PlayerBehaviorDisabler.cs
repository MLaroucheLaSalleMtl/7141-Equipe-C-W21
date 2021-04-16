using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviorDisabler : MonoBehaviour
{
    private RagdollControll rc; //référence vers le script ragdollcontroll

    private GameObject player; //référence vers le joueur (sphere)
    public Rigidbody snowboardRb; //rigidbody du snowboard
    public LookAtTarget2 lat; //script look at target
    public BoardPosition bp; //script boardposition
    public MoveTarget2 mt; //script movetarget
    public CapsuleCollider snowboardCollider; //collider du snowboard

    private List<Behaviour> componentsList = new List<Behaviour>(); //liste des components à disable
    // Start is called before the first frame update
    void Start()
    {
        rc = GetComponent<RagdollControll>();
        player = GameObject.FindGameObjectWithTag("Player");
        snowboardCollider.enabled = false; //disable le collider au depart
        AddToList(lat, mt, bp); //ajoute les componenets à la liste (components qui servent au controle du joueur)
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (rc.isDead) //quand le joueur tombe (activé par un collider trigger)
        {
            player.SetActive(false); //les controles du joueur sont désactivés
           
            snowboardCollider.enabled = true; //collider du snowboard est activé

            for (int i= 0; i < componentsList.Count; i++) //tous les components de la liste sont désactivé
            {
                componentsList[i].enabled = false;
                
            }
            snowboardRb.useGravity = true; // snowboard utilise la gravité
        }
    }

    // fonction qui ajoute un component à la liste
    void AddToList(params Behaviour[] cmp)
        {
            for (int i = 0; i < cmp.Length; i++)
            {
                componentsList.Add(cmp[i]);
            }
        }

    //Fonction pour réanimer le joueur (appelé par RagdollControll)
    public void Revive()
    {
        player.SetActive(true); //Active le joeur

        snowboardCollider.enabled = false; //enlève le collider

        for (int i = 0; i < componentsList.Count; i++) //Réactive les controles
        {
            componentsList[i].enabled = true;

        }
        snowboardRb.useGravity = false ;
    }
}
