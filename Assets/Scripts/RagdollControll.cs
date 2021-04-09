using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class RagdollControll : MonoBehaviour
{
    private IK ik;
    private Animator anim;
     private Rigidbody[] rb;
    private Collider[] col;
    public bool isDead;
    private Collider sc;
    private PlayerBehaviorDisabler pbd;
    public Text getUpTXT;
    private bool canGetUp;
        // Start is called before the first frame update
    void Start()
    {
        ik = GetComponent<IK>();
        anim = GetComponent<Animator>();
        rb = GetComponentsInChildren<Rigidbody>();
        col = GetComponentsInChildren<Collider>();
        sc = GetComponent<BoxCollider>();
        pbd = GetComponent<PlayerBehaviorDisabler>();
        getUpTXT.enabled = false;
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
            sc.isTrigger = false;
            foreach (Rigidbody rigid in rb)
            {
                rigid.isKinematic = false;
            }
            foreach (Collider collider in col)
            {
                collider.enabled = true;
            }
            StartCoroutine(GetUpSequence());
        }
    }
    public void OnRespawn(InputAction.CallbackContext context)
    {
        if (isDead && canGetUp)
        {
            isDead = false;
            anim.enabled = true;
            ik.enabled = true;
            sc.isTrigger = true;
            foreach (Rigidbody rigid in rb)
            {
                rigid.isKinematic = true;
            }
            foreach (Collider collider in col)
            {
                collider.enabled = false;
            }
            pbd.Revive();
            getUpTXT.enabled = false;
            canGetUp = false;
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
    IEnumerator GetUpSequence()
    {
        canGetUp = false;
        yield return new WaitForSeconds(5);
        canGetUp = true;
        getUpTXT.enabled = true;
    }
}
