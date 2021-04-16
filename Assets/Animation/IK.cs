using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IK : MonoBehaviour
{
    public Flipping flipping; //référence au script responsable du flipping
    public Jump jump; //référence au script responsable du saut
    public Animator anim; //Référence à l'animator
    public float ikWeight = 1; //valeur constante pour le "poids" du IK, 
    
    //prend 2 objets pour garder les pieds en place
    public Transform leftFootTarget;
    public Transform rightFootTarget;
    //2 targets pour les mains les ajuster en cas de rotation
    public Transform rightHandTarget;
    public Transform leftHandTarget;
    //2 targets pour les coudes pour les garder en place
    public Transform leftElbow;
    public Transform rightElbow;
    public MoveTarget2 mt2;


    public float hipPos = Mathf.Clamp(0, -0.5f, 0.5f);

    public float hip //valeur de position du hip du joueur
    {
        get { return _hip; }
        set { _hip = Mathf.Clamp(value, -0.5f, 0.3f); } //clamp la valeur pour ne pas qu'elle monte ou descente en dessous/dessus d'un certain seuil
    }

    public float _hip { get; private set; }

    public Transform lookAtTarget; //Ou doit regarder le joueur si au sol
    public Transform whenFlipping; //Ou regarde le joueur si en train de flipper
    public Rigidbody rb; //référence au rigidbody du board


    void Update()
    {

        if (!jump.grounded)
        {
            hip += Time.deltaTime;//Change la valeur du hip quand on est dans les airs pour donner l'impression de sauter
        }
        else
        {
            hip = 0f;//remet la valeur à 0 quand on est au sol
        }
    }

    public void OnAnimatorIK() //Script natif responsable du IK
    {
        
        if (anim) //S'assure qu'on a un animtor
        {
            if (!jump.grounded) //S'assure qu'on soit dans les airs
            {
                anim.bodyPosition += new Vector3(0, hip, 0); //change le bassin du joueur en fonction de la valeur hip
            }

            
            if(flipping.isFlippingBackwards && !jump.grounded)//si dans les airs et entrain de flipper backwards
            {
                anim.SetLookAtPosition(whenFlipping.position);//change l'endroit ou regarde le plus si en train de slipper
                anim.bodyPosition += new Vector3(0, 0.35f, 0); //bouge le bassin pour simuler l'animation d'un flip
            }
            else if(flipping.isFlipping && !jump.grounded)//si dans les airs et entrain de flipper forward
            {
                anim.bodyPosition += new Vector3(0, -0.15f, 0);//bouge le bassin pour simuler l'animation d'un flip
            }
            else //Si joueur au sol et pas en train de flipper ou sauter
            {
                anim.bodyPosition += new Vector3(-(Input.GetAxis("Horizontal"))/3, 0, 0);//bouge le bassin en fonction de la valeur des inputs horizontaux
            }
            

            //Setup général du IK
            anim.SetLookAtWeight(1f, .25f, .9f, 1f, 1f); //setup du LookAt
            anim.SetLookAtPosition(lookAtTarget.position); //fait que la tête tourne vers le target (sphere qui dirige la rotation du board)
            
            //weight des mains et des pieds, le "weight" contrôle à quel point le IK influencer l'animation
            anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, ikWeight);
            anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, ikWeight);
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, ikWeight/2);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, ikWeight/2);
            //Setup du hint qui sert à contrôler le placement joints par rapport aux limbs
            anim.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, ikWeight);
            anim.SetIKHintPositionWeight(AvatarIKHint.RightElbow, ikWeight);

            anim.SetIKHintPosition(AvatarIKHint.LeftElbow, leftElbow.position);
            anim.SetIKHintPosition(AvatarIKHint.RightElbow, rightElbow.position);

            //S'assure que les pieds sont toujours sur le board
            anim.SetIKPosition(AvatarIKGoal.LeftFoot, leftFootTarget.position);
            anim.SetIKPosition(AvatarIKGoal.RightFoot, rightFootTarget.position);
            
            //S'assure que les mains ont une même position
            anim.SetIKPosition(AvatarIKGoal.RightHand, rightHandTarget.position);
            anim.SetIKPosition(AvatarIKGoal.LeftHand, leftHandTarget.position);

        }

    }
}
