using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    public Animator anim;
    public Rigidbody rb;
    public LookAtTarget lat;

    public Transform spherePos;

    public float distanceToBoard;
    //  public Jumping jumping; //référence pour utiliser les bools
    //public Jumping isGrounded; //référence pour utiliser les bools
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        /*if (Input.GetButtonDown("Jump"))
        {
            anim.Play("JumpUp");
            //anim.SetTrigger("isJumping");
        }*/

        if (lat.currentSpeed > 2f)
        {
            //anim.Play("Slide");
            anim.SetTrigger("isSliding");
            /*transform.LookAt(spherePos);*/
            Debug.Log(lat.currentSpeed);
        }
        /*else if(lat.currentSpeed < 2f)
        {
            //anim.Play("Idle");
            anim.CrossFade("Idle", 0.5f);
        }*/
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (anim) //s'assure qu'on a bien un animateur
        {
            anim.SetLookAtWeight(1f, .25f, .9f, 1f, 1f);
            anim.SetLookAtPosition(spherePos.position);


            anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1f);
            anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1f);

            /*RaycastHit hit;
            Ray ray = new Ray(anim.GetIKPosition(AvatarIKGoal.LeftFoot) + Vector3.up, Vector3.down);
            if (Physics.Raycast(ray, out hit, distanceToBoard + 1f))
            {
                if (hit.transform.tag == "Snowboard")
                {
                    Vector3 footPosition = hit.point;
                    footPosition.y += distanceToBoard;
                    anim.SetIKPosition(AvatarIKGoal.LeftFoot, footPosition);
                    anim.SetIKPosition(AvatarIKGoal.RightFoot, footPosition);
                }
            }*/
        }
    }

    /*public void ChangeAnim(string state)
    {
        anim.Play(state);
    }*/
}
