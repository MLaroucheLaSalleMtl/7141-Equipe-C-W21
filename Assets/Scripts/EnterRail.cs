using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterRail : MonoBehaviour
{
    private GameObject player;//référence vers le joueur
    public GameObject endRail; //object end rail
    private MoveBall mb; //script moveball
    private bool onRail; //quand le joueur est sur une rail
    
    private Vector3 origPos;    // position originale du joueur
    private Jump jmp; //script jump
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        origPos = transform.position; //initialisation de la position 
        mb = player.GetComponent<MoveBall>();
        jmp = player.GetComponent<Jump>();
    }

    
    //quand le joueur entre sur la rail
    private void OnTriggerEnter(Collider other)
    {
        onRail = true; 
        jmp.onRail = true;
        transform.position = player.transform.position; //position se place sur le joueur
        player.transform.position = transform.position;
    }

    private void FixedUpdate()
    {
        //Référence pour l'aide: https://docs.unity3d.com/ScriptReference/Vector3.MoveTowards.html
        if (onRail) //quand le joueur est sur la rail
        {
            float step = mb.currentSpeed * Time.fixedDeltaTime; //temps pour le déplacement
            if (player.transform.position != transform.position) //joueur toujours attaché sur l'objet
            {
                player.transform.position = transform.position;
            }
            transform.position = Vector3.MoveTowards(transform.position, endRail.transform.position, step); //bouge l'object vers la fin du rail (joueur attaché sur l'object)
            if (Vector3.Distance(transform.position, endRail.transform.position) < 0.2f) //si object proche de la fin
            {
                transform.position = origPos;//object retourne à sa position original
                onRail = false;//joeur n'est plus sur la rail
            }
            if (jmp.isJumping) //si le joueur saute quand il est sur la rail
            {
                
                transform.position = origPos; //objet retourne a sa position original
                onRail = false; //nest plus sur la rail
                
            }
            if (player.transform.position != endRail.transform.position) //si le joeur est sur la rail mais n'a pas terminé la rail
            {
                jmp.onRail = true; //on rail = true
            }
            else
            {
                jmp.onRail = false; //sinon faut
            }
            jmp.railDir = (endRail.transform.position - transform.position).normalized; //trouve la direction de la rail
        }
      
           

      
        

        
    }
}
