using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IK : MonoBehaviour
{

    public Animator anim;
    public float ikWeight = 1;
    //prend 2 objets pour garder les pieds en place
    public Transform leftIKTarget;
    public Transform rightIKTarget;

    public MoveTarget2 mt2;

    public Vector3 hipOffset; //va permettre de contrôler le centre de masse/placement du bassin

    public Transform lookAtTarget;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(mt2.angle);
        Debug.Log(Input.GetAxis("Horizontal"));
    }

    public void OnAnimatorIK(int layerIndex)
    {
        
        if (anim)
        {
            //solution temporaire pour ajouter du mouvement en fonction de l'input
            anim.bodyPosition += new Vector3(-(Input.GetAxis("Horizontal"))/2, 0, 0);
            /*if(mt2.angle < 0)
            {
                anim.bodyPosition += new Vector3(0.5f, 0, 0);
            }
            else if(mt2.angle > 0)
            {
                anim.bodyPosition += new Vector3(-0.5f, 0, 0);
            }*/
            //anim.bodyPosition += hipOffset;


            anim.SetLookAtWeight(1f, .25f, .9f, 1f, 1f);
            anim.SetLookAtPosition(lookAtTarget.position);
            //pos
            anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, ikWeight);
            anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, ikWeight);

            anim.SetIKPosition(AvatarIKGoal.LeftFoot, leftIKTarget.position);
            anim.SetIKPosition(AvatarIKGoal.RightFoot, rightIKTarget.position);
            //rot
            //anim.SetIKRotation(AvatarIKGoal.LeftFoot, leftIKTarget.rotation);
            //anim.SetIKRotation(AvatarIKGoal.RightFoot, rightIKTarget.rotation);

            //anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, ikWeight);
            //anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, ikWeight);
            //anim.SetBoneLocalRotation(HumanBodyBones.Hips, Quaternion);
        }

    }
}
