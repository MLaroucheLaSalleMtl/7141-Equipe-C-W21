using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    public Jump jump;//R�f�rence au script responsable du saut

    public GameObject snowboard;//R�f�rence au snowboard

    public TrailRenderer snowTrail;//R�f�rence au trail renderer

    public LayerMask groundLayer;//R�f�rence au sol

    // Start is called before the first frame update
    void Start()
    {
        snowTrail = GetComponent<TrailRenderer>();//r�cup�re le trail
    }


    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, 0.25f, groundLayer))//v�rifie si le snowboard/joueur touche le sol

        {
            snowTrail.emitting = true; //Active l'�mission du trail
        }
        else
        {
            snowTrail.emitting = false;//D�sactive l'�mission du trail
        }
    }
}
