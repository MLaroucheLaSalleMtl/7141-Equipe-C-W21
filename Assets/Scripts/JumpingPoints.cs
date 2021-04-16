using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpingPoints : MonoBehaviour
{
    public Jump jmp; //Référence vers script jump
    public LevelSystem level; //référence vers le level system

    public float maxHeight = 0; //point le plus haut d'un jump
    private float distance; //distance du jump
    public Text pointsTxt; //texte pour les points
    public Text multiplierTxt; //texte pour le multiplier
    public bool started; //bool jump à commencer
    private Vector3 origPos = new Vector3(); //position au début du jump
   
    float multiplier; //multiplier points
    float pointsToGive; //points total 
    public int pointsToGiveInt; //total points en int
    public Animator anim; //animator

    //Séquence pour sauter
    IEnumerator JumpSequence()
    {
        yield return new WaitUntil(() => jmp.grounded); //attends que le joueur attérisse
        started = false; //jump fini
        
        distance = Vector3.Distance(origPos, transform.position); //calcul la distance parcourue
        
        GivePoints(); //Donne les points
        anim.SetTrigger("Landed"); //Animation des points à l'atterissage
        pointsTxt.text =  pointsToGive.ToString(); //Ajuste le texte de points
        multiplierTxt.text =  multiplier.ToString() + "X"; //Ajuste le texte de multiplier
        
    }
    // Update is called once per frame
    void Update()
    {
       
       if (!jmp.grounded && !started) //Quand le joueur saute
        {
            maxHeight = 0f; //Hauteur remise à 0
            
            started = true;
            
            origPos = transform.position; //Enregistre la position de départ
            StartCoroutine(JumpSequence()); //Commence la coroutine
            
        }
       if (started) //Durant le saut
        {
           
            //Trouve la distance entre le joueur et le sol, pour le multiplier
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -Vector3.up, out hit))
            {
               if (hit.distance > maxHeight) //Prends la hauteur la plus grande
                {
                    maxHeight = hit.distance;
                    if (maxHeight < 1) { maxHeight = 1; } //Multiplier ne peux pas etre 0
                    multiplier = maxHeight / 2; 
                }
                
            }
            pointsTxt.text = Vector3.Distance(origPos, transform.position).ToString("F0"); //Affiche les points

        }

        if (multiplier < 1) { multiplier = 1; } 
        multiplierTxt.text =  multiplier.ToString("F0") + "X"; //Affichge les points durant le saut
        
    }

    //Donne les points total au joueur
    public void GivePoints()
    {
        multiplier =(int) maxHeight / 2;
        if (multiplier == 0)
        {
            multiplier = 1;
        }
        if (multiplier <= 15)//Sauter de la montagne la plus haute(Freemode 3) donnait multipler de x50 et un total de 20000 scores donc 20000 exp
        {
            pointsToGive = (int)distance * multiplier; //Calcul avec le multiplier
            pointsToGiveInt = (int)Mathf.Round(pointsToGive); //Transferer le float en int pour le LevelSystem
            level.AddExperience(pointsToGiveInt); //Appel AddExperience pour les player prefs
        }
    }
    
}
