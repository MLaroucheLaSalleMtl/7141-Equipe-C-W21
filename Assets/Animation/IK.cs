using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IK : MonoBehaviour
{
    public MaxSlope slope;
    public Flipping flipping;
    public Jump jump;
    public Animator anim;
    public float ikWeight = 1;
    //prend 2 objets pour garder les pieds en place
    public Transform leftFootTarget;
    public Transform rightFootTarget;

    public Transform rightHandTarget;
    public Transform leftHandTarget;

    public Transform leftElbow;
    public Transform rightElbow;
    public MoveTarget2 mt2;

    public Vector3 hipOffset; //va permettre de contrôler le centre de masse/placement du bassin

    public float hipPos = Mathf.Clamp(0, -0.5f, 0.5f);

    public float hip
    {
        get { return _hip; }
        set { _hip = Mathf.Clamp(value, -0.5f, 0.3f); }
    }

    public float _hip { get; private set; }

    public Transform lookAtTarget;
    public Transform whenFlipping;
    public Rigidbody rb;
    public float currentVel;
    public Transform target;
    public float timer = 0f;

    public MoveBall ball;

    // Start is called before the first frame update
    void Start()
    {
        //currentVel += rb.velocity.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(mt2.angle);
        //Debug.Log(Input.GetAxis("Horizontal"));
        //Debug.Log(jump.grounded);
        //Debug.Log(rb.velocity.magnitude);

        //if (jump.isJumping) 
        //{
        //    currentVel += rb.velocity.magnitude;
        //}
        //RaycastHit hit;

        //if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        //{
        //    Debug.Log("distance to ground: "+ hit.collider.bounds.extents.y);
        //}
        //else
        //{
        //    Debug.Log("in the air");
        //}

        if (!jump.grounded)
        {
            hip += Time.deltaTime;
        }
        else
        {
            hip = 0f;
        }
        Debug.Log(ball.currentSpeed);  
    }

    public void OnAnimatorIK()
    {
        
        if (anim)
        {
            if (!jump.grounded)
            {
                anim.SetBool("inAir", true);
                anim.bodyPosition += new Vector3(0, hip, 0);
            }

            /*if(rb.velocity.magnitude > currentVel)
            {
                anim.bodyPosition += new Vector3(0, 1f, 0);
            }*/


            if(flipping.isFlippingBackwards && !jump.grounded)
            {
                //Debug.Log("the conditions are met");
                anim.SetLookAtPosition(whenFlipping.position);
                anim.bodyPosition += new Vector3(0, 0.35f, 0);
            }
            else if(flipping.isFlipping && !jump.grounded)
            {
                Debug.Log("the conditions are met");
                anim.bodyPosition += new Vector3(0, -0.15f, 0);
            }
            else
            {
                anim.bodyPosition += new Vector3(-(Input.GetAxis("Horizontal"))/3, 0, 0);
            }
            


            anim.SetLookAtWeight(1f, .25f, .9f, 1f, 1f);
            anim.SetLookAtPosition(lookAtTarget.position);
            //pos
            anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, ikWeight);
            anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, ikWeight);
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, ikWeight/2);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, ikWeight/2);

            anim.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, ikWeight);
            anim.SetIKHintPositionWeight(AvatarIKHint.RightElbow, ikWeight);

            anim.SetIKHintPosition(AvatarIKHint.LeftElbow, leftElbow.position);
            anim.SetIKHintPosition(AvatarIKHint.RightElbow, rightElbow.position);

            anim.SetIKPosition(AvatarIKGoal.LeftFoot, leftFootTarget.position);
            anim.SetIKPosition(AvatarIKGoal.RightFoot, rightFootTarget.position);
            

            anim.SetIKPosition(AvatarIKGoal.RightHand, rightHandTarget.position);
            anim.SetIKPosition(AvatarIKGoal.LeftHand, leftHandTarget.position);

            /*if (flipping.isFlipping)
            {
                anim.SetIKPosition(AvatarIKGoal.RightHand, rightHandTarget.position);
            }*/

            //rot
            //anim.SetIKRotation(AvatarIKGoal.LeftFoot, leftIKTarget.rotation);
            //anim.SetIKRotation(AvatarIKGoal.RightFoot, rightIKTarget.rotation);

            //anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, ikWeight);
            //anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, ikWeight);
            //anim.SetBoneLocalRotation(HumanBodyBones.Hips, Quaternion);
        }

    }
}
