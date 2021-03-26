using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollControll : MonoBehaviour
{
    private IK ik;
    private Animator anim;
     private Rigidbody[] rb;
    private Collider[] col;
    public bool isDead;
    private SphereCollider sc;
     // Start is called before the first frame update
    void Start()
    {
        ik = GetComponent<IK>();
        anim = GetComponent<Animator>();
        rb = GetComponentsInChildren<Rigidbody>();
        col = GetComponentsInChildren<Collider>();
        sc = GetComponent<SphereCollider>();
        foreach (Rigidbody rigid in rb)
        {
            rigid.isKinematic = true;
        }
        foreach (Collider collider in col)
        {
            collider.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            anim.enabled = false;
            ik.enabled = false;
            isDead = true;
            foreach (Rigidbody rigid in rb)
            {
                rigid.isKinematic = false;
            }
            foreach (Collider collider in col)
            {
                collider.enabled = true;
            }
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!sc.enabled)
        {
            sc.enabled = true;
        }
    }
}
