using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class RagdollControll : MonoBehaviour
{
    public MoveBall ball; //Reference vers le script MoveBall
    private IK ik; //R�f�rence vers le script ik
    private Animator anim; //animator
     private Rigidbody[] rb; //Rigidbody array
    private Collider[] col;  // array de colliders
    public bool isDead; // joeur est mort
    private Collider sc; // collider tete joueur
    private PlayerBehaviorDisabler pbd; //script PBD
    public Text getUpTXT; //Texte pour se relever
    private bool canGetUp; //Bool pour savoir quand le joueur peut se relever
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

        //D�sactive le ragdoll
        foreach (Rigidbody rigid in rb)// Active tout les rigidbody
        {
            rigid.isKinematic = true; 
        }
        foreach (Collider collider in col) //d�sactive les colliders
        {
            collider.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground") //quand la tete touche le sol
        {
            anim.enabled = false; // animator d�sactiv�
            ik.enabled = false; //ik d�sactiv�
            isDead = true; //joueur mort
            sc.isTrigger = false; //collider n'est plus trigger

            //Ragdoll activ�
            foreach (Rigidbody rigid in rb)//D�sactive les rigidbodys
            {
                rigid.isKinematic = false;
            }
            foreach (Collider collider in col)//active les colliders
            {
                collider.enabled = true;
            }
            StartCoroutine(GetUpSequence()); //Coroutine commence pour se relever
        }
    }

    //quand le joueur se rel�ve Input System
    public void OnRespawn(InputAction.CallbackContext context)
    {
        if (isDead && canGetUp) //quand le joueur est tomb�  et qu'il peut se relever
        {
            ball.snowSound.Play(); //Recommence le son du snowboard lorsque le joueur se releve
            isDead = false; //joueur n'est plus mort
            anim.enabled = true; //animator r�activ�
            ik.enabled = true; //ik r�activ�
            sc.isTrigger = true; //collider redevient trigger

            //d�sactive le ragdoll
            foreach (Rigidbody rigid in rb)
            {
                rigid.isKinematic = true;//active les rigidbodys
            }
            foreach (Collider collider in col)
            {
                collider.enabled = false; //d�sactive les colliders
            }
            pbd.Revive(); //appel Revive dans script PBD
            getUpTXT.enabled = false; //texte activ�
            canGetUp = false; //joueur peut pas se relever avant d'avoir tomb�
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!sc.enabled) //collider de la tete toujours activ�
        {
            sc.enabled = true;
        }
    }
    IEnumerator GetUpSequence() //attends 5 secoandes avant de se relever
    {
        canGetUp = false;
        yield return new WaitForSeconds(5);
        canGetUp = true;
        getUpTXT.enabled = true;
    }
}
